using System;
using TMPro;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    public string[] storedFood; // � ������ ����Ǿ��ִ��� �̸����� ���� 
    public int stoveSize = 5;

    public GameObject ovenObject;
    public TextMeshProUGUI stoveText;

    public Transform[] stoveSlots; // ������ ������ ��ġ 
    private bool[] isFilled; // ��ġ�� ����ִ��� üũ 

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
        // ���� �迭�� ����� ���� �ʱ�ȭ
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

            storedFood[slotIndex] = "";  // �迭���� �ش� ���� ����
            isFilled[slotIndex] = false;  // ���� �����

            stoveText.text = $"{food} sent to oven from slot {slotIndex}!";
        }
        else
        {
            stoveText.text = $"Slot {slotIndex} is already empty!";
        }
    }
}
