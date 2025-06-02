using UnityEngine;

public class Oven : MonoBehaviour
{
    public int requiredN = 3; 
    private int currentN = 0; 
    private bool playerInRange = false;
    private string[] currentIngredients = new string[3];
    void Update()
    {
    }

    public void TryCook()
    {
        if (currentN >= requiredN)
        {
            Debug.Log("�丮 ����!");
            currentN = 0; // �丮 �� ��� �ʱ�ȭ
        }
        else
        {
            Debug.Log("���� ��ᰡ �����մϴ�.");
        }
    }

    public void AddIngredient(string food)
    {
        if (currentN < requiredN)
        {
            currentIngredients[currentN] = food;
            currentN++;
            Debug.Log($"{food}��(��) ���쿡 �߰��߽��ϴ�. (���� {currentN}��)");
        }
        else {
            Debug.Log($"������ �����ֽ��ϴ�! ����Ḧ �ֱ���, �丮�ϼ���!");
        }
    }

    // �÷��̾ ���� �տ� ���� ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // �÷��̾ ���� �տ��� ���� ��
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
