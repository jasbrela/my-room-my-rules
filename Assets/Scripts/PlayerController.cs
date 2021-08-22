using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private float timer;
    private float secs = 5f;
    private bool startTimer;
    private int currentAnim;
    
    private static readonly int Book = Animator.StringToHash("Book");

    private void Awake()
    {
        anim = GetComponent<Animator>();
        EventHandler.AddHandler(Event.BookAnim, TriggerBookAnim);
    }

    private void TriggerBookAnim()
    {
        startTimer = true;
        anim.SetBool(Book, true);
        currentAnim = Book;
    }

    private void Update()
    {
        if (currentAnim != 0)
        {
            if (startTimer && timer < secs)
            {
                timer += Time.deltaTime;
            }
            else
            {
                startTimer = false;
                timer = 0f;
                StopAnim(currentAnim);
            }
        }
    }
    
    private void StopAnim(int id)
    {
        timer = 0f;
        startTimer = false;
        anim.SetBool(id, false);
    }
}