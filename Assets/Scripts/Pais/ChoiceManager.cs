using UnityEngine;

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
        nameChoice = gameObject.name;
        pc.nameC = nameChoice;
    }
}
