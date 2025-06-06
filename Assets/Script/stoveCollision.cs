using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public StoveManager StoveManager;
    public GameObject ovenObject;
    public KeyCode actionKey;
    public int stoveIndex;

    public GameObject Ingredient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_R") || other.CompareTag("Player_L"))
        {
            isPlayerInTrigger = true;
        }
        if (other.CompareTag("Ingredient"))
        {
            Ingredient = other.gameObject;
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
        Oven oven = ovenObject.GetComponent<Oven>();
        if (isPlayerInTrigger && Input.GetKeyDown(actionKey) && !oven.isFull)
        {
            StoveManager.ToOven(stoveIndex);
           
            // 재료 오브젝트 삭제
            if (Ingredient != null)
            {
                Destroy(Ingredient);
                Ingredient = null; // 참조도 초기화
            }
        }
    }


}
