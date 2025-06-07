using UnityEngine;

public class LavaHot : MonoBehaviour
{
    public GameObject smoke_fx;
    int burnGauge = 0;
    bool inLava = false;
    private void Update()
    {
        if (inLava)
        {
            burnGauge++;
            //Debug.Log($"Lava에 닿아 있는 중...: {burnGauge}");
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

        }
    }

    void CheckTooHot()
    {
        if (burnGauge > 300)
        {
            smoke_fx.SetActive(true);
        }
    }
}
