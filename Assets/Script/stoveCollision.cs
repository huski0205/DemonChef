using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"플레이어가 {this.name}에 들어왔습니다!");
        }
    }

    private void OnTriggerExit(Collider other) {

        Debug.Log($"플레이어가 {this.name}에서 나갔습니다!");

    }
}