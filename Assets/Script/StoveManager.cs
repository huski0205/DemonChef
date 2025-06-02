using System;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    string[] storedFood; //0,1,2,3,4번 
    int stoveSize = 5;
    void Start()
    {
        storedFood = new string[stoveSize];
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";  // 각 슬롯을 빈 문자열로 초기화
        }

        AssignToSlot("grain");
        AssignToSlot("meat");
        AssignToSlot("fruit");
        AssignToSlot("grain");
        AssignToSlot("grain");
        AssignToSlot("meat");//<-실패해야됨
    }


    void Update()
    {
    }

    public void AssignToSlot(string food) {
        for (int i = 0; i<= stoveSize;i++)
        {
            if(i == stoveSize)
            {
                Debug.Log("조리대가 꽉차있습니다!");
            }
            else if (storedFood[i] == "")
            {
                storedFood[i] = food;
                Debug.Log($"{i}번째 조리대에 {food}이 들어갔습니다!");

                break;
            }
        }
    }

}
