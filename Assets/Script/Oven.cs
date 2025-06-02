using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Oven : MonoBehaviour
{
    public int requiredN = 3; 
    private int currentN = 0; 
    private bool playerInRange = false;
    private string[] currentIngredients = new string[3];

    public TextMeshProUGUI scoreText;  // �ν����Ϳ��� ����
    private int score = 0;
    public int bad = -1;
    public int good = 1;
    public int perfect = 2;

    void Start()
    {
        UpdateScoreText();
    }
    void Update()
    {
    }

    public void TryCook()
    {
        if (currentN >= requiredN)
        {
            Debug.Log("�丮 ����!");
            currentN = 0; // �丮 �� ��� �ʱ�ȭ

            score += good;
            UpdateScoreText();
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

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
