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

        gameObject.SetActive(false); // ó���� ��Ȱ��ȭ
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

        gameObject.SetActive(true); // ������Ʈ ���̱�
        StopAllCoroutines();        // �ߺ� ����
        StartCoroutine(HideAfterSeconds(2f));
    }

    private IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
