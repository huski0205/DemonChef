using UnityEngine;

public class LavaHot : MonoBehaviour
{
    public GameObject smoke_fx;
    private PlayerController playerController;
    int burnGauge = 0;
    bool inLava = false;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController ������Ʈ�� ã�� �� �����ϴ�!");
        }
    }
    private void Update()
    {
        if (inLava)
        {
            burnGauge++;
            Debug.Log($"Lava�� ��� �ִ� ��...: {burnGauge}");
        }
        else
        {
            inLava = false;
        }
        CheckTooHot();
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            inLava = true;
        }
        else if (collision.gameObject.CompareTag("Floor")){
            inLava = false;
            burnGauge = 0;
            smoke_fx.SetActive(false);
            if (playerController != null)
                playerController.moveSpeed = 5f;

        }
    }

    void CheckTooHot()
    {
        if (burnGauge > 0)
        {
            smoke_fx.SetActive(true);
            if (playerController != null)
                playerController.moveSpeed = 2f;
        }
    }
}
