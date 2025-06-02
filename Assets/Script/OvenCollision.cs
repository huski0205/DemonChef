using UnityEngine;

public class OvenCollision : MonoBehaviour
{
    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("오븐 앞에서 Shift 키가 눌렸습니다!");
            Oven oven = GetComponentInParent<Oven>();
            if (oven != null)
            {
                oven.TryCook(); // 부모 오브젝트의 함수 호출
            }
        }
    }
}
