using System;
using System.Collections.Generic;
using UnityEngine;

public enum Event
{
    BookAnim,
    NotebookAnim,
    SkeletonAnim,
    ActionFigureAnim
}

public class EventHandler : MonoBehaviour
{
    // Stores the delegates that get called when an event is fired
    private static Dictionary<Event, Action> eventTable
        = new Dictionary<Event, Action>();
 
    // Adds a delegate to get called for a specific event
    public static void AddHandler(Event @event, Action action)
    {
        if (!eventTable.ContainsKey(@event)) eventTable[@event] = action;
        else eventTable[@event] += action;
    }
 
    // Fires the event
    public static void Broadcast(Event @event)
    {
        if (eventTable[@event] != null) eventTable[@event]();
    }
}
