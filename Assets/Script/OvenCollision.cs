using UnityEngine;

public class OvenCollision : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("����տ��� Shift Ű�� ���Ƚ��ϴ�!");
                Oven oven = GetComponentInParent<Oven>();
                if (oven != null)
                {
                    oven.TryCook(); // �θ��� �Լ� ȣ��
                }
            }
        }
    }
}

