using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Oven : MonoBehaviour
{
    public int requiredN = 3; 
    private int currentN = 0; 
    private string[] currentIngredients = new string[3];

    public TextMeshProUGUI ovenText;  // �ν����Ϳ��� ����
    public OvenCanvas ovenCanvas;
    public TextMeshProUGUI scoreText;  // �ν����Ϳ��� ����
    private int score = 0;
    public int bad = -1;
    public int good = 1;
    public int perfect = 2;

    public bool isFull;

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
            bool hasBad = false;
            int specialCount = 0;

            for (int i = 0; i < currentIngredients.Length; i++)
            {
                string ingredient = currentIngredients[i];

                if (ingredient == "bone" || ingredient == "skull")
                {
                    hasBad = true;
                }
                else if (ingredient == "speciel_meat"|| ingredient == "speciel_grain"|| ingredient == "speciel_vegitable")
                {
                    specialCount++;
                }
            }

            if (hasBad)
            {
                score += 0;
                ovenText.text = "Cooking failed: bad ingredient detected (bone/skull).";
            }
            else if (specialCount > 0)
            {
                int gained = perfect * specialCount;
                score += gained;
                ovenText.text = $"Perfect cook! {specialCount} special ingredient(s): +{gained} points!";
            }
            else
            {
                score += good;
                ovenText.text = "Cooking success: +1 point.";
            }

            // �ʱ�ȭ
            currentN = 0;
            isFull = false;
            currentIngredients = new string[3];
            ovenCanvas?.ClearAllImages();
            UpdateScoreText();
        }
        else
        {
            ovenText.text = "Need more ingredients to cook.";
        }
    }

    public void AddIngredient(string food)
    {
        if (currentN < requiredN)
        {
            currentIngredients[currentN] = food;
            currentN++;
            ovenText.text = $"{food} added to oven. (count:{currentN})";
            Debug.Log($"{food}��(��) ���쿡 �߰��߽��ϴ�. (���� {currentN}��)");

            string ingredientList = "���� ���� ���: ";
            for (int i = 0; i < currentN; i++)
            {
                ingredientList += currentIngredients[i];
                if (i < currentN - 1) ingredientList += ", ";
            }
            Debug.Log(ingredientList);
            ovenCanvas?.ShowIngredientImage(food, currentN-1);
            if (currentN == requiredN)
            {
                isFull = true;
            }
        }
        else {
            ovenText.text = "oven is full! cook before adding new ingredients";
            Debug.Log($"������ �����ֽ��ϴ�! ����Ḧ �ֱ���, �丮�ϼ���!");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
