using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private CursorData cursorData;
    private float timer;
    private float secs = 5.5f;
    private bool startTimer;
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
                Cursor.SetCursor(cursorData.doorwayCursors[GameHandler.colorStage], new Vector2(16f, 16f), CursorMode.Auto);
                
            } else if (hit2D.collider.gameObject.CompareTag("GameObject") || hit2D.collider.gameObject.CompareTag("BiologyObject"))
            {
                if (Input.GetMouseButtonDown(0) && !startTimer)
                {
                    startTimer = true;
                    switch (hit2D.transform.parent.GetComponent<ObjectSpot>().GetObjectType)
                    {
                        case ObjectType.Book:
                            EventHandler.Broadcast(Event.BookAnim);
                            break;
                        case ObjectType.Notebook:
                            EventHandler.Broadcast(Event.NotebookAnim);
                            break;
                        case ObjectType.ActionFigure:
                            EventHandler.Broadcast(Event.ActionFigureAnim);
                            break;
                        case ObjectType.Skeleton:
                            EventHandler.Broadcast(Event.SkeletonAnim);
                            break;
                    }
                }
                Cursor.SetCursor(cursorData.targetCursors[GameHandler.colorStage], new Vector2(8f, 8f), CursorMode.Auto);
            }
        } else
        {
            Cursor.SetCursor(cursorData.pointerCursors[GameHandler.colorStage], new Vector2(8f, 8f), CursorMode.Auto);
        }
    }
}
