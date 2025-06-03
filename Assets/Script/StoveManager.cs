using System;
using TMPro;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    //public static StoveManager Instance { get; private set; }

    public string[] storedFood;
    public int stoveSize = 5;

    public GameObject ovenObject;

    public TextMeshProUGUI stoveText;  // �ν����Ϳ��� ����

    void Awake()
    {
        isFilled = new bool[stoveSlots.Length];
        storedFood = new string[stoveSize];
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";
        }
    }
    public Transform[] stoveSlots;
    private bool[] isFilled;

    public Transform GetNextEmptySlot()
    {
        for (int i = 0; i < stoveSlots.Length; i++)
        {
            if (!isFilled[i])
                return stoveSlots[i];
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

    void Start()
    {
    }


    public void ToSlot(string food)
    {
        for (int i = 0; i <= stoveSize; i++)
        {
            if (i == stoveSize)
            {
                stoveText.text = $"{food} adding FAILED: stove is full";
                //Debug.Log($"{food}�ֱ� ����: �����밡 �����ֽ��ϴ�!");
            }
            else if (storedFood[i] == "")
            {
                storedFood[i] = food;

                stoveText.text = $"{food} add to stove {i}";
                //Debug.Log($"{i}��° �����뿡 {food}�� �����ϴ�!");
                break;
            }
        }
    }
    public void ToOven(string food)
    {
        ovenObject.GetComponent<Oven>().AddIngredient("meat");

    }
}
