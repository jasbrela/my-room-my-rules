using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static int ColorStage { get; private set; }


    public void onClick()
    {
        IncreaseColor();
    }

    public static void IncreaseColor()
    {
        if (ColorStage < 2)
        {
            ColorStage++;
        }
        else
        {
            SceneManager.LoadScene(3); 
        }
    }

    public static void DecreaseColor()
    {
        if (ColorStage > 0)
        {
            ColorStage--;
        }
    }
    
}
