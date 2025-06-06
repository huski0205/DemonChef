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
            Debug.Log("조리대 앞에서 Shift 키가 눌렸습니다!");
            StoveManager.ToOven("meat");
        }
    }
}
