using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventObject : ScriptableObject
{
    public event Action onEventTrigger;

    public void TriggerEvent()
    {
        if(onEventTrigger != null)
        {
            onEventTrigger();
        }
    }
}
