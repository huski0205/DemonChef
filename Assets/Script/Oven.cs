using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Oven : MonoBehaviour
{
    public int requiredN = 3; 
    private int currentN = 0; 
    private string[] currentIngredients = new string[3];

    public TextMeshProUGUI ovenText;  // 인스펙터에서 연결

    public TextMeshProUGUI scoreText;  // 인스펙터에서 연결
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
            ovenText.text = "cooking success!";
            //Debug.Log("요리 성공!");
            currentN = 0; // 요리 후 재료 초기화

            score += good;
            UpdateScoreText();
        }
        else
        {
            ovenText.text = "need more ingredient...";
            //Debug.Log("아직 재료가 부족합니다.");
        }
    }

    public void AddIngredient(string food)
    {
        if (currentN < requiredN)
        {
            currentIngredients[currentN] = food;
            currentN++;
            ovenText.text = $"{food} added to oven. (count:{currentN})";
            //Debug.Log($"{food}을(를) 오븐에 추가했습니다. (현재 {currentN}개)");
        }
        else {
            ovenText.text = "oven is full! cook before adding new ingredients";
            //Debug.Log($"오븐이 꽉차있습니다! 새재료를 넣기전, 요리하세요!");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
