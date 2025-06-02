using System;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static StoveManager Instance { get; private set; }

    public string[] storedFood;
    public int stoveSize = 5;

    public GameObject ovenObject;

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지하고 싶다면
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }

        // 배열 초기화
        storedFood = new string[stoveSize];
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";
        }
    }

    void Start()
    {
        /*
        // 테스트용 슬롯 채우기
        ToSlot("grain");
        ToSlot("meat");
        ToSlot("fruit");
        ToSlot("grain");
        ToSlot("grain");
        ToSlot("meat"); // <- 실패해야 됨
        */
    }

    public void ToSlot(string food)
    {
        for (int i = 0; i <= stoveSize; i++)
        {
            if (i == stoveSize)
            {
                Debug.Log($"{food}넣기 실패: 조리대가 꽉차있습니다!");
            }
            else if (storedFood[i] == "")
            {
                storedFood[i] = food;
                Debug.Log($"{i}번째 조리대에 {food}이 들어갔습니다!");
                break;
            }
        }
    }
    public void ToOven(string food)
    {
        ovenObject.GetComponent<Oven>().AddIngredient("meat");

    }
}
