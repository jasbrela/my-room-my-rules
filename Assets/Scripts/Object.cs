using UnityEngine;

[CreateAssetMenu]
public class Object : ScriptableObject
{
    public GameObject prefab;
    public Stage stage;
    public ObjectType objectType;
}
public enum Stage
{
    stage1,
    stage2,
    stage3
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
    CoatRack
}
