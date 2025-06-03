using UnityEngine;

public class RiverFlow : MonoBehaviour
{
    public float flowSpeed = 2f;
    public float deleteposition_z =-20f;

    void Update()
    {
        // -Z 방향으로 흐르게 하기
        Vector3 flowDirection = Vector3.back; // (0, 0, -1)
        transform.Translate(flowDirection * flowSpeed * Time.deltaTime, Space.World);

        if (transform.position.z < deleteposition_z) // z축 -20보다 작아지면 삭제
        {
            Destroy(gameObject);
        }
    }
}
