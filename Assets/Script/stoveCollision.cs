using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Shift Ű�� ���� "����"�� ����
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //Debug.Log("������տ��� Shift Ű�� ���Ƚ��ϴ�!");
                StoveManager.Instance.ToOven("meat");
            }
        }
    }
}