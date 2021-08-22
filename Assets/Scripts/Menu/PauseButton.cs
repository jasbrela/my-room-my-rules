using UnityEngine;

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
