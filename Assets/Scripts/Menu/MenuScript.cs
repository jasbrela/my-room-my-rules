using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;

    [SerializeField]
    private GameObject exitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void PlayButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
