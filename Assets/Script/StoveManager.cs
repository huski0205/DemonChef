using System;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static StoveManager Instance { get; private set; }

    public string[] storedFood;
    public int stoveSize = 5;

    public GameObject ovenObject;

    void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �����ϰ� �ʹٸ�
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }

        // �迭 �ʱ�ȭ
        storedFood = new string[stoveSize];
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";
        }
    }

    void Start()
    {
        /*
        // �׽�Ʈ�� ���� ä���
        ToSlot("grain");
        ToSlot("meat");
        ToSlot("fruit");
        ToSlot("grain");
        ToSlot("grain");
        ToSlot("meat"); // <- �����ؾ� ��
        */
    }

    public void ToSlot(string food)
    {
        for (int i = 0; i <= stoveSize; i++)
        {
            if (i == stoveSize)
            {
                Debug.Log($"{food}�ֱ� ����: �����밡 �����ֽ��ϴ�!");
            }
            else if (storedFood[i] == "")
            {
                storedFood[i] = food;
                Debug.Log($"{i}��° �����뿡 {food}�� �����ϴ�!");
                break;
            }
        }
    }
    public void ToOven(string food)
    {
        ovenObject.GetComponent<Oven>().AddIngredient("meat");

    }
}
