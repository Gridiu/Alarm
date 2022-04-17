using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoblinMovement : MonoBehaviour
{
    private readonly float _speed = 8f;

    private UnityEvent _goblinRightMovementEvent = new UnityEvent();
    private UnityEvent _goblinLeftMovementEvent = new UnityEvent();

    public event UnityAction GoblinRightMovementEvent
    {
        add => _goblinRightMovementEvent.AddListener(value);
        remove => _goblinRightMovementEvent.RemoveListener(value);
    }

    public event UnityAction GoblinLeftMovementEvent
    {
        add => _goblinLeftMovementEvent.AddListener(value);
        remove => _goblinLeftMovementEvent.RemoveListener(value);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _goblinRightMovementEvent.Invoke();
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            _goblinLeftMovementEvent.Invoke();
        }
    }
}
