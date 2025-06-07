using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
    public int requiredN = 3;
    private int currentN = 0;
    private string[] currentIngredients = new string[3];

    public TextMeshProUGUI ovenText;
    public OvenCanvas ovenCanvas;
    public TextMeshProUGUI scoreText;
    public Slider cooldownSlider;
    public GameObject oven_fire_fx;

    private int score = 0;
    public int bad = -1;
    public int good = 1;
    public int perfect = 1;

    public bool isFull;
    public bool canCook = true;

    private float cookCooldown = 10f;
    private float cookTimer = 0f;

    // ⬇️ 새로운 점수 보류용 변수
    private int pendingScore = 0;
    private string pendingMessage = "";
    private bool hasPendingResult = false;

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
                cooldownSlider.value = cookTimer;

            if (oven_fire_fx != null)
                oven_fire_fx.SetActive(true);

            if (cookTimer <= 0f)
            {
                canCook = true;

                if (hasPendingResult)
                {
                    score += pendingScore;
                    ovenText.text = pendingMessage;
                    UpdateScoreText();
                    hasPendingResult = false;
                }
                else
                {
                    ovenText.text = "Oven is ready to cook again!";
                }

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
            canCook = false;
            cookTimer = cookCooldown;

            if (cooldownSlider != null)
            {
                cooldownSlider.maxValue = cookCooldown;
                cooldownSlider.value = cookCooldown;
            }

            bool hasBad = false;
            int specialCount = 0;

            for (int i = 0; i < currentIngredients.Length; i++)
            {
                string ingredient = currentIngredients[i];

                if (ingredient == "bone" || ingredient == "skull")
                {
                    hasBad = true;
                }
                else if (ingredient.StartsWith("speciel_"))
                {
                    specialCount++;
                }
            }

            if (hasBad)
            {
                pendingScore = 0;
                pendingMessage = "Cooking failed: bad ingredient detected (bone/skull).";
            }
            else if (specialCount > 0)
            {
                pendingScore = specialCount + 1;
                pendingMessage = $"Perfect cook! {specialCount} special ingredient(s): +{pendingScore} points!";
            }
            else
            {
                pendingScore = good;
                pendingMessage = "Cooking success: +1 point.";
            }

            hasPendingResult = true;

            currentN = 0;
            isFull = false;
            currentIngredients = new string[3];
            ovenCanvas?.ClearAllImages();
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
            Debug.Log($"{food}을(를) 오븐에 추가했습니다. (현재 {currentN}개)");

            ovenCanvas?.ShowIngredientImage(food, currentN - 1);

            if (currentN == requiredN)
            {
                isFull = true;
            }
        }
        else
        {
            ovenText.text = "Oven is full! Cook before adding new ingredients.";
            Debug.Log("오븐이 꽉차있습니다! 새 재료를 넣기 전, 요리하세요!");
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
