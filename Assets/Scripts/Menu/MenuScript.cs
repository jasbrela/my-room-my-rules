using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField]
    private GameObject configButton;

    [SerializeField]
    private GameObject creditButton;

    [SerializeField]
    private GameObject backButton;

    [SerializeField]
    private GameObject loadingText;

    [SerializeField]
    private GameObject configCanva;

    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);
        configButton.SetActive(true);
        creditButton.SetActive(true);
        backButton.SetActive(false);

        loadingText.SetActive(false);

        configCanva.SetActive(false);
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

    public void ConfigButtonClick()
    {
        gameObject.SetActive(false);
        configCanva.SetActive(true);
    }

    public void CreditsButtonClick()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        configButton.SetActive(false);
        creditButton.SetActive(false);

        backButton.SetActive(true);
    }

    public void BackButtonClick()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);
        configButton.SetActive(true);
        creditButton.SetActive(true);
        
        backButton.SetActive(false);
    }
}
