using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ParentsController : MonoBehaviour
{
    public bool finishedGameplay;

    [Header("Variável que chama o evento pais")] 
    public bool callher; // se ela terminou de jogar
    
    AudioSource audio_;

    GameObject paisgo, paisemoji; // reacao pais
    public GameObject choice1, choice2;
    public Sprite[] emojis, emojisR;
    public Sprite[] emojisCerto;
    public Sprite[] emojisErrado;

    GameObject choicem, obj_qte, emoji1, emoji2;

    int loop;
    public string nameC = "";
    GameObject livro;

    void Awake()
    {
        audio_ = GetComponent<AudioSource>();
        choice1 = GameObject.Find("Escolha1");
        choice2 = GameObject.Find("Escolha2");
        paisgo = GameObject.FindWithTag("DPais");
        paisemoji = GameObject.Find("Reacaopais");
        emoji1 = GameObject.Find("Emoji1");
        emoji2 = GameObject.Find("Emoji2");
        paisgo.SetActive(false);
        choicem = GameObject.Find("Escolha1");
        obj_qte = GameObject.Find("QTE");
        livro = GameObject.Find("BookQTE");
        
    }

    void Update()
    {
        if (callher == true && loop < 4) 
        {
            
            loop += 1;
            audio_.Play(0); // som bate na porta
            finishedGameplay = true;
            callher = false; // por hora resolve o bug no audio da porta
        }

        if (finishedGameplay)
        {
            Dialogo();
        }
        else
        {
            x = false;
            y = false;
            z = false;
        }
    }

    bool x, y;
    void Dialogo()
    {
        if (x == false)
        {
            paisemoji.GetComponent<Image>().sprite = emojis[Random.Range(0, emojis.Length)];
            emoji1.GetComponent<Image>().sprite = emojisErrado[Random.Range(0, emojisErrado.Length)];
            emoji2.GetComponent<Image>().sprite = emojisCerto[Random.Range(0, emojisCerto.Length)];
            x = true;
        }

        if (y == false)
        {
            switch (nameC)
            {
                case "":
                    paisgo.SetActive(true);
                    break;
                case "Escolha1": // errado
                    paisemoji.GetComponent<Image>().sprite = emojis[Random.Range(0, emojis.Length)];
                    choice1.SetActive(false);
                    choice2.SetActive(false);
                    StartCoroutine("Wait_", 2f);
                    break;
                case "Escolha2": // certo
                    paisemoji.GetComponent<Image>().sprite = emojisR[Random.Range(0, emojisR.Length)];
                    choice1.SetActive(false);
                    choice2.SetActive(false);
                    GameHandler.colorStage--;
                    StartCoroutine("Wait", 2f);
                    break;
            }
        }
    }

    IEnumerator Wait()
    {
        y = true;
        yield return new WaitForSeconds(2f);
        paisgo.SetActive(false);
        finishedGameplay = false;
        nameC = "";
    }

    bool z;
    IEnumerator Wait_()
    {
        y = true;
        yield return new WaitForSeconds(2f);
        paisgo.SetActive(false);
        
        if (z == false)
        {
            livro.GetComponent<StudyController>().OpenQTE();
            z = true;
        }

        finishedGameplay = false;
        nameC = "";
    }
    
    public void CallParents() // chama evento pais
    {
        callher = true;
        choice1.SetActive(true);
        choice2.SetActive(true);
    }
}
