using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string playerTag;  // "L" 또는 "R"
    public KeyCode grabKey;   // LeftShift 또는 RightShift
    public float moveSpeed = 5f;
    private Animator animator;
    private bool isCollidingWithOther = false;
    private GameObject opponent;
    private static bool isSomeoneGrabbed = false;
    private bool isGrabbed = false;
    public float grabDuration = 2f; // 상대방이 잡혔을 때 멈추는 시간
    private float grabTimer = 0f;

    public GameObject smoke_fx; // 잡힘 상태일 때 보여줄 연기 이펙트 (인스펙터 연결)

    void Start()
    {
        animator = GetComponent<Animator>();

        if (smoke_fx != null)
            smoke_fx.SetActive(false); // 시작할 때는 꺼두기
    }

    void Update()
    {
        if (isGrabbed)
        {
            grabTimer -= Time.deltaTime;

            // 잡힌 상태일 때 smoke_fx 켜기
            if (smoke_fx != null && !smoke_fx.activeSelf)
                smoke_fx.SetActive(true);

            if (grabTimer <= 0f)
            {
                isGrabbed = false;
                Debug.Log($"{playerTag} released");

                // 풀릴 때 smoke_fx 끄기
                if (smoke_fx != null && smoke_fx.activeSelf)
                    smoke_fx.SetActive(false);
            }
            return; // 이동 불가
        }
        else
        {
            // 잡히지 않았을 때 smoke_fx 끄기 (혹시 켜져있다면)
            if (smoke_fx != null && smoke_fx.activeSelf)
                smoke_fx.SetActive(false);
        }

        HandleMovement();
        HandleGrab();
    }

    void HandleMovement()
    {
        Vector3 moveDir = Vector3.zero;

        if (playerTag == "L")
        {
            if (Input.GetKey(KeyCode.W)) moveDir += Vector3.forward;
            if (Input.GetKey(KeyCode.S)) moveDir += Vector3.back;
            if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;
            if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) moveDir += Vector3.forward;
            if (Input.GetKey(KeyCode.DownArrow)) moveDir += Vector3.back;
            if (Input.GetKey(KeyCode.LeftArrow)) moveDir += Vector3.left;
            if (Input.GetKey(KeyCode.RightArrow)) moveDir += Vector3.right;
        }

        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
            transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
        bool isMove = moveDir != Vector3.zero;

        // ismove 파라미터에 현재 움직임 여부 전달
        animator.SetBool("ismove", isMove);
    }

    void HandleGrab()
    {
        if (isCollidingWithOther && !isSomeoneGrabbed && Input.GetKeyDown(grabKey))
        {
            Debug.Log($"{playerTag} grabbed {opponent.name}");
            isSomeoneGrabbed = true;

            PlayerController opponentScript = opponent.GetComponent<PlayerController>();
            if (opponentScript != null)
            {
                opponentScript.GetGrabbed(grabDuration);
            }

            // 일정 시간 후 풀림 처리
            Invoke(nameof(ResetGrab), grabDuration);
        }
    }

    public void GetGrabbed(float duration)
    {
        isGrabbed = true;
        grabTimer = duration;
        Debug.Log($"{playerTag} is grabbed for {duration} seconds");
    }

    void ResetGrab()
    {
        isSomeoneGrabbed = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_R") || collision.gameObject.CompareTag("Player_L"))
        {
            Debug.Log("충돌 시작");
            isCollidingWithOther = true;
            opponent = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == opponent)
        {
            Debug.Log("충돌 끝");
            isCollidingWithOther = false;
            opponent = null;
        }
    }
}
