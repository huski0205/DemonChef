using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [Header("시간제한")]
    public float timeLimit = 60f; // 제한 시간 (초)
    private float remainingTime;
    public TextMeshProUGUI timerText; // UI 텍스트에 시간 표시 (선택사항)

    private bool isTimeOver = false;

    [Header("점수계산")]
    public GameObject ovenL; //인스펙터에서 할당
    public GameObject ovenR; //인스펙터에서 할당
    private Oven ovenScriptL; //오븐스크립트
    private Oven ovenScriptR; //오븐스크립트

    public GameObject winL;
    public GameObject loseL; 
    public GameObject winR;
    public GameObject loseR;

    void Start()
    {
        remainingTime = timeLimit;

        ovenScriptL = ovenL.GetComponent<Oven>();
        ovenScriptR = ovenR.GetComponent<Oven>();


        winL.SetActive(false);
        loseL.SetActive(false);
        winR.SetActive(false);
        loseR.SetActive(false);
    }

    void Update()
    {
        if (isTimeOver)
            return;

        // 시간 감소
        remainingTime -= Time.deltaTime;

        // 시간 표시
        if (timerText != null)
        {
            timerText.text =  Mathf.CeilToInt(remainingTime).ToString();
        }

        // 시간이 다 되면 게임 오버 처리
        if (remainingTime <= 0)
        {
            TimeOver();
        }
    }

    void TimeOver()
    {
        isTimeOver = true;
        Debug.Log("게임 오버!");
        DecideWinner();

    }

    void DecideWinner()
    {
        int scoreL = ovenScriptL.Score; //oven.cs의 게터 호출
        int scoreR = ovenScriptR.Score;

        if (scoreL > scoreR)
        { //왼쪽이 승자
            Debug.Log("왼쪽이 우승!");
            winL.SetActive(true);
            loseR.SetActive(true);
        }
        else if (scoreL < scoreR)
        { //왼쪽이 승자
            Debug.Log("왼쪽이 우승!");
            loseL.SetActive(true);
            winR.SetActive(true);       
        }
        else {
            Debug.Log("무승부!");
            loseL.SetActive(true);
            loseR.SetActive(true);
        }
    }
}

