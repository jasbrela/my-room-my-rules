using UnityEngine;
using UnityEngine.Audio;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private CursorData cursorData;
    private float timer;
    private float secs = 5.5f;
    private bool startTimer;

    [SerializeField]
    private AudioSource boneSound, turningPages, closingBook, mouseSound, keyboardSound;

    private void Update()
    {
        if (startTimer && timer < secs)
        {
            timer += Time.deltaTime;
        }
        else
        {
            startTimer = false;
            timer = 0f;
        }

        RaycastHit2D
            hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero, 0f, cursorData.interactableLayer.value);
     
        Debug.DrawRay(Camera.main.transform.position, hit2D.point, Color.red, 1f);
        
        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("Doorway"))
            {
                Cursor.SetCursor(cursorData.doorwayCursors[GameHandler.ColorStage], new Vector2(16f, 16f), CursorMode.Auto);
                
            } else if (hit2D.collider.gameObject.CompareTag("GameObject") || hit2D.collider.gameObject.CompareTag("BiologyObject"))
            {
                if (Input.GetMouseButtonDown(0) && !startTimer)
                {
                    startTimer = true;
                    switch (hit2D.transform.parent.GetComponent<ObjectSpot>().GetObjectType)
                    {
                        case ObjectType.Book:
                            GameHandler.DecreaseColor();
                            EventHandler.Broadcast(Event.BookAnim);
                            turningPages.Play();
                            closingBook.PlayDelayed(3);
                            break;
                        case ObjectType.Notebook:
                            GameHandler.IncreaseColor();
                            EventHandler.Broadcast(Event.NotebookAnim);
                            mouseSound.Play();
                            keyboardSound.PlayDelayed(1);
                            break;
                        case ObjectType.ActionFigure:
                            GameHandler.IncreaseColor();
                            EventHandler.Broadcast(Event.ActionFigureAnim);
                            break;
                        case ObjectType.Skeleton:
                            GameHandler.DecreaseColor();
                            EventHandler.Broadcast(Event.SkeletonAnim);
                            boneSound.Play();
                            break;
                    }
                }
                Cursor.SetCursor(cursorData.targetCursors[GameHandler.ColorStage], new Vector2(8f, 8f), CursorMode.Auto);
            }
        } else
        {
            Cursor.SetCursor(cursorData.pointerCursors[GameHandler.ColorStage], new Vector2(8f, 8f), CursorMode.Auto);
        }
    }
}
