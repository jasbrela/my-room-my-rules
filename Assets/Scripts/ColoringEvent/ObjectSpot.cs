using System;
using UnityEngine;

public class ObjectSpot : MonoBehaviour
{
    [SerializeField] private ObjectData objectData;
    [SerializeField] private Object @object;
    [SerializeField] private ObjectType objectType;

    private void Awake()
    {
        Instantiate(@object.prefab, transform);
    }

    private void Update()
    {
        // maybe add observer? so this wont be checking all the time??
        // also this need some optimization but its the best i can think of rn
        
        if (@object.objectType == this.objectType)
        {
            switch (objectType)
            {
                case ObjectType.Notebook:
                    UpdateItem(objectData.notebooks[IncreaseColor.colorStage]);
                    break;
                case ObjectType.Skeleton:
                    UpdateItem(objectData.skeletons[IncreaseColor.colorStage]);
                    break;
                case ObjectType.Bed:
                    UpdateItem(objectData.beds[IncreaseColor.colorStage]);
                    break;
                case ObjectType.Desk:
                    UpdateItem(objectData.desks[IncreaseColor.colorStage]);
                    break;
                case ObjectType.Chair:
                    UpdateItem(objectData.chairs[IncreaseColor.colorStage]);
                    break;
                case ObjectType.Stethoscope:
                    UpdateItem(objectData.stethoscopes[IncreaseColor.colorStage]);
                    break;
                case ObjectType.ActionFigure:
                    UpdateItem(objectData.actionFigures[IncreaseColor.colorStage]);
                    break;
                case ObjectType.Book:
                    UpdateItem(objectData.books[IncreaseColor.colorStage]);
                    break;
                case ObjectType.CoatRack:
                    UpdateItem(objectData.coatRacks[IncreaseColor.colorStage]);
                    break;
            }
        }
        else
        {
            throw new Exception("Wrong Object Type added to this Object Spot: " + this.gameObject.name + ". " +
                                "You may want to check the Object Data.");
        }
    }

    private void UpdateItem(Object @object)
    {
        if (this.@object.id != @object.id)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            Instantiate(@object.prefab, transform);

            this.@object = @object;
        }
    }
}