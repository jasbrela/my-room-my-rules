using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstudyController : MonoBehaviour
{
    GameObject obj_qte;

    void Awake()
    {
        obj_qte = GameObject.Find("QTE");
    }

    public void OpenQTE()
    {
        obj_qte.SetActive(true);
    }
}
