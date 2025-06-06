using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OvenCanvas : MonoBehaviour
{


    [Header("UI 이미지")]
    public Image ingredientImage1;
    public Image ingredientImage2;
    public Image ingredientImage3;

    [Header("재료별 스프라이트 매핑")]
    public Sprite boneSprite;
    public Sprite skullSprite;
    public Sprite specialMeatSprite;
    public Sprite specialGrainSprite;
    public Sprite specialVegetableSprite;
    public Sprite meatSprite;
    public Sprite grainSprite;
    public Sprite vegetableSprite;

    private Dictionary<string, Sprite> spriteMap;

    void Start()
    {
        // 문자열 키로 스프라이트 매핑
        spriteMap = new Dictionary<string, Sprite>
        {
            { "bone", boneSprite },
            { "skull", skullSprite },
            { "speciel_meat", specialMeatSprite },
            { "speciel_grain", specialGrainSprite },
            { "speciel_vegitable", specialVegetableSprite },
            { "meat", meatSprite },
            { "grain", grainSprite },
            { "vegitable", vegetableSprite }
        };

        ClearAllImages();
    }

    public void ShowIngredientImage(string ingredientName, int slotIndex)
    {
        if (!spriteMap.ContainsKey(ingredientName))
        {
            Debug.LogWarning($"[OvenCanvas] Unknown ingredient: {ingredientName}");
            return;
        }

        Sprite sprite = spriteMap[ingredientName];

        switch (slotIndex)
        {
            case 0:
                ingredientImage1.sprite = sprite;
                ingredientImage1.enabled = true;
                break;
            case 1:
                ingredientImage2.sprite = sprite;
                ingredientImage2.enabled = true;
                break;
            case 2:
                ingredientImage3.sprite = sprite;
                ingredientImage3.enabled = true;
                break;
            default:
                Debug.LogWarning("[OvenCanvas] Invalid slot index.");
                break;
        }
    }

    public void ClearAllImages()
    {
        ingredientImage1.enabled = false;
        ingredientImage2.enabled = false;
        ingredientImage3.enabled = false;
    }
}
