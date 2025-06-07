using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string playerTag;  // "L" �Ǵ� "R"
    public KeyCode grabKey;   // LeftShift �Ǵ� RightShift
    public float moveSpeed = 5f;
    private Animator animator;
    private bool isCollidingWithOther = false;
    private GameObject opponent;
    private static bool isSomeoneGrabbed = false;
    private bool isGrabbed = false;
    public float grabDuration = 2f; // ������ ������ �� ���ߴ� �ð�
    private float grabTimer = 0f;

    public GameObject smoke_fx; // ���� ������ �� ������ ���� ����Ʈ (�ν����� ����)

    void Start()
    {
        animator = GetComponent<Animator>();

        if (smoke_fx != null)
            smoke_fx.SetActive(false); // ������ ���� ���α�
    }

    void Update()
    {
        if (isGrabbed)
        {
            grabTimer -= Time.deltaTime;

            // ���� ������ �� smoke_fx �ѱ�
            if (smoke_fx != null && !smoke_fx.activeSelf)
                smoke_fx.SetActive(true);

            if (grabTimer <= 0f)
            {
                isGrabbed = false;
                Debug.Log($"{playerTag} released");

                // Ǯ�� �� smoke_fx ����
                if (smoke_fx != null && smoke_fx.activeSelf)
                    smoke_fx.SetActive(false);
            }
            return; // �̵� �Ұ�
        }
        else
        {
            // ������ �ʾ��� �� smoke_fx ���� (Ȥ�� �����ִٸ�)
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

        // ismove �Ķ���Ϳ� ���� ������ ���� ����
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

            // ���� �ð� �� Ǯ�� ó��
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
            Debug.Log("�浹 ����");
            isCollidingWithOther = true;
            opponent = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == opponent)
        {
            Debug.Log("�浹 ��");
            isCollidingWithOther = false;
            opponent = null;
        }
    }
}
