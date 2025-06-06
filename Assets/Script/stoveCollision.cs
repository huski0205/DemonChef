using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public StoveManager StoveManager;

    public KeyCode actionKey;
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
        if (isPlayerInTrigger && Input.GetKeyDown(actionKey))
        {
            Debug.Log("������ �տ��� Shift Ű�� ���Ƚ��ϴ�!");
            StoveManager.ToOven("meat");
        }
    }
}
