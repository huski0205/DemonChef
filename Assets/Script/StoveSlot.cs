using UnityEngine;

public class StoveSlot : MonoBehaviour
{
    public Transform[] stoveSlots;
    private bool[] isFilled;

    void Awake()
    {
        isFilled = new bool[stoveSlots.Length];
    }

    public Transform GetNextEmptySlot()
    {
        for (int i = 0; i < stoveSlots.Length; i++)
        {
            if (!isFilled[i])
                return stoveSlots[i];
        }
        return null;
    }

    public void MarkSlotFilled(Transform slot)
    {
        for (int i = 0; i < stoveSlots.Length; i++)
        {
            if (stoveSlots[i] == slot)
            {
                isFilled[i] = true;
                return;
            }
        }
    }
}
