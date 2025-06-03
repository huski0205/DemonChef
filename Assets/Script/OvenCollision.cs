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
        //Debug.Log($"{this.name} 의 ovenCollison.cs 작동중");

        if (isPlayerInTrigger && Input.GetKeyDown(actionKey))
        {
            Debug.Log("오븐 앞에서 키가 눌렸습니다!");
            Oven oven = GetComponentInParent<Oven>();
            if (oven != null)
            {
                oven.TryCook(); // 부모 오브젝트의 함수 호출
            }
        }
    }
}
