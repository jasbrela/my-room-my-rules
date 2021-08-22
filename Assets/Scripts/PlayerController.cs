using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private float timer;
    private float secs = 5f;
    private bool startTimer;
    private int currentAnim;
    
    [SerializeField] private PlayerPositionData _playerPositionData;
    
    private static readonly int Book = Animator.StringToHash("Book");
    private static readonly int Skeleton = Animator.StringToHash("Skeleton");
    private static readonly int ActionFigure = Animator.StringToHash("ActionFigure");
    private static readonly int Notebook = Animator.StringToHash("Notebook");

    private void Awake()
    {
        anim = GetComponent<Animator>();
        EventHandler.AddHandler(Event.BookAnim, TriggerBookAnim);
        EventHandler.AddHandler(Event.SkeletonAnim, TriggerSkeletonAnim);
        EventHandler.AddHandler(Event.ActionFigureAnim, TriggerActionFigureAnim);
        EventHandler.AddHandler(Event.NotebookAnim, TriggerNotebookAnim);
    }
    // TODO: block clicks when animation is running
    // if you spam the triggers, the player will teleport to the points.
    // basically: if the animation is running, this should not happen. 

    #region Trigger Anim Methods
    private void TriggerBookAnim()
    {
        this.transform.position = this._playerPositionData.bookPlayerPosition.position;
        startTimer = true;
        anim.SetBool(Book, true);
        currentAnim = Book;
    }
    
    private void TriggerSkeletonAnim()
    {
        this.transform.position = this._playerPositionData.skeletonPlayerPosition.position;
        startTimer = true;
        anim.SetBool(Skeleton, true);
        currentAnim = Skeleton;
    }
    
    private void TriggerNotebookAnim()
    {
        this.transform.position = this._playerPositionData.notebookPlayerPosition.position;
        startTimer = true;
        anim.SetBool(Notebook, true);
        currentAnim = Notebook;
    }
    
    private void TriggerActionFigureAnim()
    {
        this.transform.position = this._playerPositionData.actionFigurePlayerPosition.position;
        startTimer = true;
        anim.SetBool(ActionFigure, true);
        currentAnim = ActionFigure;
    }
    #endregion
    
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