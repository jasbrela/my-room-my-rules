using UnityEngine;

[CreateAssetMenu]
public class Object : ScriptableObject
{
    public string id;
    public GameObject prefab;
    public Stage stage;
    public ObjectType objectType;
}
public enum Stage
{
    One,
    Two,
    Three
}

public enum ObjectType
{
    Notebook,
    Skeleton,
    Bed,
    Desk,
    Chair,
    Stethoscope,
    ActionFigure,
    Book,
    CoatRack,
    Poster,
    Bedroom
}
