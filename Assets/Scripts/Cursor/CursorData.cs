using UnityEngine;

[CreateAssetMenu]
public class CursorData : ScriptableObject
{
    [Space(10)]
    [TextArea] public string Notes;
    [Space(10)]
    
    
    public LayerMask interactableLayer;
    public Texture2D[] pointerCursors; // cursor
    public Texture2D[] targetCursors; // interactable
    public Texture2D[] doorwayCursors;

}
