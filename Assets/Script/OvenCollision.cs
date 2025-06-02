using UnityEngine;

public class OvenCollision : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("오븐앞에서 Shift 키가 눌렸습니다!");
                Oven oven = GetComponentInParent<Oven>();
                if (oven != null)
                {
                    oven.TryCook(); // 부모의 함수 호출
                }
            }
        }
    }
}

