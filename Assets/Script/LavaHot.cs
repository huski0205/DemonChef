using UnityEngine;

public class LavaHot : MonoBehaviour
{
    int burnGauge = 0;
    bool inLava = false;
    private void Update()
    {
        if (inLava)
        {
            burnGauge++;
            Debug.Log($"Lava�� ��� �ִ� ��...: {burnGauge}");
        }
        else {
            inLava = false;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            inLava = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            inLava = false;
        }
    }
}
