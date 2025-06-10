using UnityEngine;
using System.Collections;

public class FinishFood : MonoBehaviour
{
    public Renderer foodRenderer;
    public Texture badTexture;
    public Texture goodTexture;
    public Texture perfectTexture;

    private Texture originalTexture;

    void Start()
    {
        if (foodRenderer != null)
        {
            originalTexture = foodRenderer.material.mainTexture;
        }

        gameObject.SetActive(false); // 처음엔 비활성화
    }

    public void SetTextureByResult(string resultType)
    {
        if (foodRenderer == null) return;

        switch (resultType)
        {
            case "bad":
                foodRenderer.material.mainTexture = badTexture;
                break;
            case "good":
                foodRenderer.material.mainTexture = goodTexture;
                break;
            case "perfect":
                foodRenderer.material.mainTexture = perfectTexture;
                break;
            default:
                foodRenderer.material.mainTexture = originalTexture;
                break;
        }

        gameObject.SetActive(true); // 오브젝트 보이기
        StopAllCoroutines();        // 중복 방지
        StartCoroutine(HideAfterSeconds(2f));
    }

    private IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
