using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro_title : MonoBehaviour
{
    public GameObject canvas;  
    public float delaySeconds; // 몇 초 뒤에 띄울지
    public string nextSceneName; // 전환할 씬 이름

    void Start()
    {
        canvas.gameObject.SetActive(false);
        Invoke(nameof(ShowTitle), delaySeconds);
    }

    void ShowTitle()
    {
        canvas.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
