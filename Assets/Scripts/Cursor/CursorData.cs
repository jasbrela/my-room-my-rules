using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CursorData : ScriptableObject
{
    public LayerMask interactableLayer;
    public Texture2D pointer; // normal
    public Texture2D target; // interactable
    public Texture2D doorway;
}
