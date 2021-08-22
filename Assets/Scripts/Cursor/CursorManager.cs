using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // TODO: make it change with the coloring event

    [SerializeField] private CursorData cursorData;
    [SerializeField] private Vector2 hotspot;
    private void Update()
    {
        RaycastHit2D
            hit2D = //Physics2D.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0f, cursorData.interactableLayer.value);
                Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, cursorData.interactableLayer.value);
     
        Debug.DrawRay(Camera.main.transform.position, hit2D.point, Color.red, 1f);
        
        if (hit2D.collider != null)
        {
            //Debug.Log(hit2D.collider.gameObject.name);
            
            if (hit2D.collider.gameObject.CompareTag("Doorway"))
            {
                Cursor.SetCursor(cursorData.doorway, hotspot, CursorMode.Auto);
            } else if (hit2D.collider.gameObject.CompareTag("Object"))
            {
                Cursor.SetCursor(cursorData.target, hotspot, CursorMode.Auto);
            }
        } else
        {
            Cursor.SetCursor(cursorData.pointer, hotspot, CursorMode.Auto);
        }
    }
}
