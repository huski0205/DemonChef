using UnityEngine;

public class stoveCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"�÷��̾ {this.name}�� ���Խ��ϴ�!");
        }
    }

    private void OnTriggerExit(Collider other) { 
    
    
    }
}