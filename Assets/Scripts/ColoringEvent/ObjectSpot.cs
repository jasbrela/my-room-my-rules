using System;
using UnityEngine;

public class ObjectSpot : MonoBehaviour
{
    [SerializeField] private ObjectData objectData;
    [SerializeField] private Object firstObject;
    [SerializeField] private ObjectType objectType;

    public ObjectType GetObjectType => objectType;

    private void Awake()
    {
        if (firstObject != null)
        {
            Instantiate(firstObject.prefab, transform);
        }
    }

    private void Update()
    {
        // maybe add observer? so this wont be checking all the time??
        // also this need some optimization but its the best i can think of rn
        
        if (firstObject.objectType == objectType)
        {
            switch (objectType)
            {
                case ObjectType.Notebook:
                    UpdateItem(objectData.notebooks[GameHandler.ColorStage]);
                    break;
                case ObjectType.Skeleton:
                    UpdateItem(objectData.skeletons[GameHandler.ColorStage]);
                    break;
                case ObjectType.Bed:
                    UpdateItem(objectData.beds[GameHandler.ColorStage]);
                    break;
                case ObjectType.Desk:
                    UpdateItem(objectData.desks[GameHandler.ColorStage]);
                    break;
                case ObjectType.Chair:
                    UpdateItem(objectData.chairs[GameHandler.ColorStage]);
                    break;
                case ObjectType.Stethoscope:
                    UpdateItem(objectData.stethoscopes[GameHandler.ColorStage]);
                    break;
                case ObjectType.ActionFigure:
                    UpdateItem(objectData.actionFigures[GameHandler.ColorStage]);
                    break;
                case ObjectType.Book:
                    UpdateItem(objectData.books[GameHandler.ColorStage]);
                    break;
                case ObjectType.CoatRack:
                    UpdateItem(objectData.coatRacks[GameHandler.ColorStage]);
                    break;
                case ObjectType.Poster:
                    UpdateItem(objectData.posters[GameHandler.ColorStage]);
                    break;
                case ObjectType.Bedroom:
                    UpdateItem(objectData.bedrooms[GameHandler.ColorStage]);
                    break;
            }
        }
        else
        {
            throw new Exception("Wrong Object Type added to this Object Spot: " + gameObject.name + ". " +
                                "You may want to check the Object Data or Object Position.");
        }
    }

    private void UpdateItem(Object @object)
    {
        if (firstObject.id != @object.id)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Instantiate(@object.prefab, transform);

            firstObject = @object;
        }
    }
}