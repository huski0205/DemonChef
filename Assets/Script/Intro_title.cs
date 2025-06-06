using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro_title : MonoBehaviour
{
    public GameObject canvas;  
    public float delaySeconds; // �� �� �ڿ� �����
    public string nextSceneName; // ��ȯ�� �� �̸�

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
