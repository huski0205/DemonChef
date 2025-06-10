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
    private float delayAfterTimeOver = 3f;
    private float timeOverElapsed = 0f;

    [Header("점수계산")]
    public GameObject ovenL; //인스펙터에서 할당
    public GameObject ovenR; //인스펙터에서 할당
    private Oven ovenScriptL; //오븐스크립트
    private Oven ovenScriptR; //오븐스크립트

    public GameObject winL;
    public GameObject loseL; 
    public GameObject winR;
    public GameObject loseR;
    public TextMeshProUGUI replayQuit;


    [Header("사운드")]
    public AudioSource bgm_audio;
    public AudioSource timeOver_audio;

    void Start()
    {
        remainingTime = timeLimit;

        ovenScriptL = ovenL.GetComponent<Oven>();
        ovenScriptR = ovenR.GetComponent<Oven>();


        winL.SetActive(false);
        loseL.SetActive(false);
        winR.SetActive(false);
        loseR.SetActive(false);
        replayQuit.enabled = false;
    }

    void Update()
    {
        if (isTimeOver)
        {
            timeOverElapsed += Time.deltaTime;
            if (timeOverElapsed >= delayAfterTimeOver)
            {
                QuitOrReplay();
            }
            return;
        }

        // 시간 감소
        remainingTime -= Time.deltaTime;

        // 시간 표시
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();
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
        timeOverElapsed = 0f; // ← 꼭 초기화 해주기
        Debug.Log("게임 오버!");
        bgm_audio.Pause();
        timeOver_audio.Play();
        DecideWinner();
        replayQuit.enabled = true;

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
    void QuitOrReplay()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // 게임 종료
                Application.Quit();

                // 에디터에서는 Quit이 작동 안 하므로, 테스트할 땐 아래 로그로 확인
                Debug.Log("게임 종료됨");
            }
            else
            {
                // 리플레이 (현재 씬 다시 로드)
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
                );
            }
        }
    }
}

