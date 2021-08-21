using UnityEngine;

public class IncreaseColor : MonoBehaviour
{
    public static int colorStage = 0; // 0 for 1, 1 for 2, 2 for 3

    void onClick()
    {
        if (colorStage < 2)
        {
            colorStage++;
        }
    }
}
