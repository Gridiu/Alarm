using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseBreaking : MonoBehaviour
{
    [SerializeField] private UnityEvent _doorOpeningEvent;

    public event UnityAction DoorOpeningEvent
    {
        add => _doorOpeningEvent.AddListener(value);
        remove => _doorOpeningEvent.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Intruder>(out Intruder goblin))
        {
            _doorOpeningEvent?.Invoke();
        }
    }
}


