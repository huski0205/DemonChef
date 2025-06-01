using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isLeft = true;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 moveDir = Vector3.zero;

        if (isLeft)
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

        bool isMove = moveDir != Vector3.zero;

        // ismove 파라미터에 현재 움직임 여부 전달
        animator.SetBool("ismove", isMove);

        if (isMove)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);

            transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
