using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    public string nameChoice = "";
    ParentsController pc;

    void Awake()
    {
        pc = GameObject.Find("PaisManager").GetComponent<ParentsController>();
    }

    public void CheckChoice()
    {
        nameChoice = this.gameObject.name;
        pc.nameC = nameChoice;
    }
}
