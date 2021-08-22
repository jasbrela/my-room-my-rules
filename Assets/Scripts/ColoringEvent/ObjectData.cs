using UnityEngine;

[CreateAssetMenu]
public class ObjectData : ScriptableObject
{
    [Space(10)]
    [TextArea] public string Notes;
    [Space(10)]
    
    
    public Object[] notebooks;
    public Object[] skeletons;
    public Object[] beds;
    public Object[] desks;
    public Object[] chairs;
    public Object[] stethoscopes;
    public Object[] actionFigures;
    public Object[] books;
    public Object[] coatRacks;
    public Object[] posters;
}
