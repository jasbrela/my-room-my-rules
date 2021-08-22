using UnityEngine;

public class StudyController : MonoBehaviour
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
