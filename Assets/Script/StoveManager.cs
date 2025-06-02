using System;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    string[] storedFood; //0,1,2,3,4�� 
    int stoveSize = 5;
    void Start()
    {
        storedFood = new string[stoveSize];
        for (int i = 0; i < stoveSize; i++)
        {
            storedFood[i] = "";  // �� ������ �� ���ڿ��� �ʱ�ȭ
        }

        AssignToSlot("grain");
        AssignToSlot("meat");
        AssignToSlot("fruit");
        AssignToSlot("grain");
        AssignToSlot("grain");
        AssignToSlot("meat");//<-�����ؾߵ�
    }


    void Update()
    {
    }

    public void AssignToSlot(string food) {
        for (int i = 0; i<= stoveSize;i++)
        {
            if(i == stoveSize)
            {
                Debug.Log("�����밡 �����ֽ��ϴ�!");
            }
            else if (storedFood[i] == "")
            {
                storedFood[i] = food;
                Debug.Log($"{i}��° �����뿡 {food}�� �����ϴ�!");

                break;
            }
        }
    }

}
