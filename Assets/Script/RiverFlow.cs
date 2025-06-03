using UnityEngine;

public class RiverFlow : MonoBehaviour
{
    public float flowSpeed = 2f;
    public float deleteposition_z =-20f;

    void Update()
    {
        // -Z �������� �帣�� �ϱ�
        Vector3 flowDirection = Vector3.back; // (0, 0, -1)
        transform.Translate(flowDirection * flowSpeed * Time.deltaTime, Space.World);

        if (transform.position.z < deleteposition_z) // z�� -20���� �۾����� ����
        {
            Destroy(gameObject);
        }
    }
}
