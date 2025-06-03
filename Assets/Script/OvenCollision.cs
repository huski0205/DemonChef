using UnityEngine;

public class OvenCollision : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public KeyCode actionKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_R")|| other.CompareTag("Player_L"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player_R") || other.CompareTag("Player_L"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        //Debug.Log($"{this.name} �� ovenCollison.cs �۵���");

        if (isPlayerInTrigger && Input.GetKeyDown(actionKey))
        {
            Debug.Log("���� �տ��� Ű�� ���Ƚ��ϴ�!");
            Oven oven = GetComponentInParent<Oven>();
            if (oven != null)
            {
                oven.TryCook(); // �θ� ������Ʈ�� �Լ� ȣ��
            }
        }
    }
}
