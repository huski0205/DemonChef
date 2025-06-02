using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"�÷��̾ {this.name}�� ���Խ��ϴ�!");
        }
    }

    private void OnTriggerExit(Collider other) {

        Debug.Log($"�÷��̾ {this.name}���� �������ϴ�!");

    }
}