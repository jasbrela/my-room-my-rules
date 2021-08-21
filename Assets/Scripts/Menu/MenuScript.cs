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

    [SerializeField]
    private GameObject loadingText;
    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);
        loadingText.SetActive(false);
    }

    public void PlayButtonClick()
    {
        if (!loadingText.activeSelf)
        {
            Invoke("loadingActive", 0.2f);
        }
        Invoke("LoadGame", 1.1f);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void loadingActive()
    {
        loadingText.SetActive(true);

    }
}
