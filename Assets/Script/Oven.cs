using UnityEngine;

public class Oven : MonoBehaviour
{
    public int requiredN = 3; 
    private int currentN = 0; 
    private bool playerInRange = false;
    private string[] currentIngredients = new string[3];
    void Update()
    {
        //if (playerInRange && Input.GetKeyDown(KeyCode.LeftShift))
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            TryCook();
        }
    }

    void TryCook()
    {
        if (currentN >= requiredN)
        {
            Debug.Log("요리 성공!");
            currentN = 0; // 요리 후 재료 초기화
        }
        else
        {
            Debug.Log("아직 재료가 부족합니다.");
        }
    }

    public void AddIngredient(string food)
    {
        if (currentN < requiredN)
        {
            currentIngredients[currentN] = food;
            currentN++;
            Debug.Log($"{food}을(를) 오븐에 추가했습니다. (현재 {currentN}개)");
        }
        else {
            Debug.Log($"오븐이 꽉차있습니다!요리하세요!");
        }
    }

    // 플레이어가 오븐 앞에 들어올 때
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // 플레이어가 오븐 앞에서 나갈 때
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
