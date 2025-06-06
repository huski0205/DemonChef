using UnityEngine;

public class IngredientMovement : MonoBehaviour
{
    public GameObject visualPrefab;
    public string ingredientName = "meat";  // 필수: 재료 이름

    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = collision.gameObject;

        if (player.CompareTag("Player_R"))
        {
            TryPlaceOnStove("StoveManager_R");
        }
        else if (player.CompareTag("Player_L"))
        {
            TryPlaceOnStove("StoveManager_L");
        }
    }

    void TryPlaceOnStove(string stoveManagerObjectName)
    {
        StoveManager manager = GameObject.Find(stoveManagerObjectName).GetComponent<StoveManager>();
        Transform slot = manager.GetNextEmptySlot(ingredientName);

        if (slot != null)
        {
            if (visualPrefab != null)
            {
                GetComponent<RiverFlow>().enabled = false;
                Instantiate(visualPrefab, slot.position, visualPrefab.transform.rotation);
            }

            manager.MarkSlotFilled(slot);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{stoveManagerObjectName}에 빈 스토브 슬롯이 없습니다!");
        }
    }
}
