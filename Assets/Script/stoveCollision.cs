using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Shift 키를 누른 "순간"만 감지
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //Debug.Log("조리대앞에서 Shift 키가 눌렸습니다!");
                StoveManager.Instance.ToOven("meat");
            }
        }
    }
}