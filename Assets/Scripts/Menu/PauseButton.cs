using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Canvas configCanva;

    [SerializeField]
    private Canvas originalCanva;

    public void pauseButtonClick()
    {
        configCanva.gameObject.SetActive(true);
        originalCanva.gameObject.SetActive(false);
    }
}
