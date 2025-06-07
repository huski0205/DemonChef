using System;
using TMPro;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    public string[] storedFood; // 어떤 음식이 저장되어있는지 이름으로 저장 
    public int stoveSize = 5;

    public GameObject ovenObject;
    public TextMeshProUGUI stoveText;

    public Transform[] stoveSlots; // 음식이 떨어질 위치 
    private bool[] isFilled; // 위치가 비어있는지 체크 

    void Awake()
    {
        isFilled = new bool[stoveSlots.Length];
        storedFood = new string[stoveSize];
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";
        }
    }

    void Start()
    {
        // 슬롯 배열과 저장된 음식 초기화
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";
            if (i < isFilled.Length)
            {
                isFilled[i] = false;
            }
        }

        if (stoveText != null)
        {
            stoveText.text = "Stove initialized.";
        }
    }

    public Transform GetNextEmptySlot(string food)
    {
        for (int i = 0; i < stoveSlots.Length; i++)
        {
            if (!isFilled[i])
            {
                storedFood[i] = food;
                return stoveSlots[i];
            }
        }
        return null;
    }

    public void MarkSlotFilled(Transform slot)
    {
        for (int i = 0; i < stoveSlots.Length; i++)
        {
            if (stoveSlots[i] == slot)
            {
                isFilled[i] = true;
                return;
            }
        }
    }

    public void ToOven(int slotIndex)
    {
        
        if (slotIndex < 0 || slotIndex >= stoveSize)
        {
            stoveText.text = "Invalid slot index!";
            return;
        }
        Oven oven = ovenObject.GetComponent<Oven>();
        if (oven.isFull)
        {
            stoveText.text = "Oven is full! Please cook before adding more.";
            return;
        }
        if (isFilled[slotIndex] && oven.canCook)
        {
            string food = storedFood[slotIndex];
            ovenObject.GetComponent<Oven>().AddIngredient(food);

            storedFood[slotIndex] = "";  // 배열에서 해당 음식 삭제
            isFilled[slotIndex] = false;  // 슬롯 비워줌

            stoveText.text = $"{food} sent to oven from slot {slotIndex}!";
        }
        else
        {
            stoveText.text = $"Slot {slotIndex} is already empty!";
        }
    }
}
