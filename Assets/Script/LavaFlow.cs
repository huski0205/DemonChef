using UnityEngine;

public class LavaFlow : MonoBehaviour
{
    public float scrollSpeedX = 0.1f;  // X축 방향 속도
    public float scrollSpeedY = 0.0f;  // Y축 방향 속도

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset.x += scrollSpeedX * Time.deltaTime;
        offset.y += scrollSpeedY * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
