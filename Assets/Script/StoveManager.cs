using System;
using TMPro;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    //public static StoveManager Instance { get; private set; }

    public string[] storedFood;
    public int stoveSize = 5;

    public GameObject ovenObject;

    public TextMeshProUGUI stoveText;  // 인스펙터에서 연결

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
                //Debug.Log($"{food}넣기 실패: 조리대가 꽉차있습니다!");
            }
            else if (storedFood[i] == "")
            {
                storedFood[i] = food;

                stoveText.text = $"{food} add to stove {i}";
                //Debug.Log($"{i}번째 조리대에 {food}이 들어갔습니다!");
                break;
            }
        }
    }
    public void ToOven(string food)
    {
        ovenObject.GetComponent<Oven>().AddIngredient("meat");

    }
}
