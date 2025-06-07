using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Oven : MonoBehaviour
{
    public int requiredN = 3;
    private int currentN = 0;
    private string[] currentIngredients = new string[3];

    public TextMeshProUGUI ovenText;          // �ν����Ϳ��� ����
    public OvenCanvas ovenCanvas;
    public TextMeshProUGUI scoreText;         // �ν����Ϳ��� ����
    public Slider cooldownSlider;              // �ν����Ϳ��� ���� (��Ÿ�� ǥ�ÿ�)
    public GameObject oven_fire_fx;            // �ν����Ϳ��� ���� (��Ÿ�� ȭ�� ����Ʈ)

    private int score = 0;
    public int bad = -1;
    public int good = 1;
    public int perfect = 2;

    public bool isFull;

    public bool canCook = true;
    private float cookCooldown = 10f;
    private float cookTimer = 0f;

    void Start()
    {
        UpdateScoreText();

        if (cooldownSlider != null)
        {
            cooldownSlider.maxValue = cookCooldown;
            cooldownSlider.value = 0;
        }

        if (oven_fire_fx != null)
            oven_fire_fx.SetActive(false);
    }

    void Update()
    {
        if (!canCook)
        {
            cookTimer -= Time.deltaTime;

            if (cooldownSlider != null)
                cooldownSlider.value = cookTimer;  // 10 -> 0 ���� ����

            if (oven_fire_fx != null)
                oven_fire_fx.SetActive(true);

            if (cookTimer <= 0f)
            {
                canCook = true;
                ovenText.text = "Oven is ready to cook again!";
                if (cooldownSlider != null)
                    cooldownSlider.value = 0;

                if (oven_fire_fx != null)
                    oven_fire_fx.SetActive(false);
            }
        }
        else
        {
            if (oven_fire_fx != null && oven_fire_fx.activeSelf)
                oven_fire_fx.SetActive(false);
        }
    }

    public void TryCook()
    {
        if (!canCook)
        {
            ovenText.text = $"Oven is cooling down... ({cookTimer:F1}s left)";
            return;
        }

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
                else if (ingredient == "speciel_meat" || ingredient == "speciel_grain" || ingredient == "speciel_vegitable")
                {
                    specialCount++;
                }
            }

            if (hasBad)
            {
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

            // ��Ÿ�� ����
            canCook = false;
            cookTimer = cookCooldown;
            if (cooldownSlider != null)
            {
                cooldownSlider.maxValue = cookCooldown;
                cooldownSlider.value = cookCooldown;
            }
        }
        else
        {
            ovenText.text = "Need more ingredients to cook.";
        }
    }

    public void AddIngredient(string food)
    {
        if (!canCook)
        {
            ovenText.text = $"Oven is cooling down... ({cookTimer:F1}s left)";
            return;
        }

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

            ovenCanvas?.ShowIngredientImage(food, currentN - 1);

            if (currentN == requiredN)
            {
                isFull = true;
            }
        }
        else
        {
            ovenText.text = "Oven is full! Cook before adding new ingredients.";
            Debug.Log("������ �����ֽ��ϴ�! �� ��Ḧ �ֱ� ��, �丮�ϼ���!");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public int Score
    {
        get { return score; }
    }
}
