using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEController : MonoBehaviour
{
    float fillAmount = 0; // status do sprite
    float timePassed = 0, timePassed_ = 0; // tempo q passou
    float decreaseStatus = 0.03f; // quanto maior, mais rápido vai decrescer o status

    public string success = ""; // se conseguiu ou não
    string letra = ""; // o botão pra apertar
    string[] btns = {"a", "w", "s", "d", "e", "q"}; // botões que podem ser sorteados

    public int lvl = 1; // próximo qte

    GameObject obj_qte; // todo o qte
    GameObject obj_success; // acessa o texto, obj de feedback
    GameObject obj_letra; // acessa o texto, mostra letra que deve ser apertada
    
    void Awake() // pega objs no início e atribui pra variáveis
    {
        obj_qte = GameObject.Find("QTE");
        obj_success = GameObject.FindWithTag("Success");
        obj_letra = GameObject.FindWithTag("Letra");
    }

    void Start()
    {
        obj_qte.SetActive(false);
        obj_success.SetActive(false); // esconde obj de feedback
        letra = btns[Random.Range(0, btns.Length)]; // fas primeiro sorteio de botão a ser apertado

        lvl = 1;
        decreaseStatus = 0.03f;
        timePassed_ = 0;
        timePassed = 0;
        fillAmount = 0;
    }

    void Update()
    {
        if (lvl < 4)
        {
            QTE();
        }
        else if (lvl > 3)
        {
            obj_qte.SetActive(false);
        }
    }

    void QTE()
    {
        obj_letra.GetComponent<Text>().text = letra.ToUpper(); // atualiza letra pra apertar

        if (Input.GetKeyDown(letra.ToString()) && success != "no") // ao aperatr o botão
        {
            fillAmount += .2f; // aumenta o progresso
        }

        GetComponent<Image>().fillAmount = fillAmount; // atualiza o status no sprite
        timePassed += Time.deltaTime; // tempo que passou
        
        if (timePassed > .05f && success == "") // se passou o tempo
        {
            timePassed = 0; // reseta
            fillAmount -= decreaseStatus; // decresce status
            if (success == "yes") { fillAmount = 1; } // se conseguiu, fica cheio
        }

        if (fillAmount < 0) { fillAmount = 0; } // não deixa o fill amount fica > 0, bugar

        if (success == "") // se ainda nao teve resultado: first try
        {
            StartCoroutine("CheckEvent", 3); // checa se ganhou ou perdeu
        } 
    }

    IEnumerator CheckEvent()
    {
        timePassed_ += Time.deltaTime; // tempo que passou
        if (fillAmount >= 1 && timePassed_ < 3) // se encheu dentro do tempo
        {
            success = "yes";
            print("CONSEGUIU!");

            timePassed_ = 0;

            obj_success.SetActive(true);
            if (lvl == 3)
            {
                print("VENCEU!");
                obj_success.GetComponent<Text>().text = "congrats!";
            }
            else 
            {
                obj_success.GetComponent<Text>().text = ":D";
            }

            yield return new WaitForSeconds(1f);
            obj_success.SetActive(false); // esconde obj de feedback
            letra = btns[Random.Range(0, btns.Length)]; // faz sorteio do botão

            success = "";
            lvl += 1; // próximo qte
            decreaseStatus += 0.006f; // aumenta dificuldade
            fillAmount = 0;
        }
        else if (timePassed_ >= 3 && fillAmount < 1) // se nao encheu dentro do tempo
        {
            success = "no";
            print("PERDEU :(");

            timePassed_ = 0;

            obj_success.SetActive(true);
            obj_success.GetComponent<Text>().text = ":(";

            yield return new WaitForSeconds(1f);

            success = "";
            fillAmount = 0;
            decreaseStatus = 0.03f;
            timePassed_ = 0;
            timePassed = 0;
            letra = btns[Random.Range(0, btns.Length)]; // faz sorteio do botão

            obj_success.SetActive(false);
            obj_qte.SetActive(false);
        }
    }
}
