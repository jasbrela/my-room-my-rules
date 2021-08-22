using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ParentsController : MonoBehaviour
{
    public bool finishedGameplay = false, callher = false; // se ela terminou de jogar
    AudioSource audio_;
    GameObject paisTexto; // reacao pais
    GameObject choicem, obj_qte;
    int loop = 0;
    public string nameC = "";
    GameObject livro;

    void Awake()
    {
        audio_ = GetComponent<AudioSource>();
        paisTexto = GameObject.FindWithTag("DPais");
        paisTexto.SetActive(false);
        choicem = GameObject.Find("Escolha1");
        obj_qte = GameObject.Find("QTE");
        livro = GameObject.Find("Livro");
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

        if (finishedGameplay == true)
        {
            // fecha animação dela jogando 

            Dialogo();
        }
    }

    void Dialogo()
    {
        paisTexto.GetComponent<Text>().text = ":|";

        switch (nameC)
        {
            case "":
                paisTexto.SetActive(true);
                break;
            case "Escolha1":
                paisTexto.GetComponent<Text>().text = ">:|";
                StartCoroutine("Wait_", 2f);
                break;
            case "Escolha2":
                paisTexto.GetComponent<Text>().text = ":)";
                StartCoroutine("Wait", 2f);
                break;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        paisTexto.SetActive(false);
    }
    bool x = false;
    IEnumerator Wait_()
    {
        yield return new WaitForSeconds(2f);
        paisTexto.SetActive(false);
        
        if (x == false)
        {
            livro.GetComponent<StudyController>().OpenQTE();
            x = true;
        }
    }
}
