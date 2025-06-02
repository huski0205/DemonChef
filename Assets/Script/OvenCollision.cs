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
            Debug.Log("���� �տ��� Shift Ű�� ���Ƚ��ϴ�!");
            Oven oven = GetComponentInParent<Oven>();
            if (oven != null)
            {
                oven.TryCook(); // �θ� ������Ʈ�� �Լ� ȣ��
            }
        }
    }
}
