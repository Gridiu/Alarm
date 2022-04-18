using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GoblinMovement))]

public class GoblinMovementAnimation : MonoBehaviour
{
    private const string IsRunningLeft = "IsRunningLeft";
    private const string IsRunningRight = "IsRunningRight";
    private const string IsIdle = "IsIdle";
    
    private Animator _animator;
    private GoblinMovement _goblinMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _goblinMovement = GetComponent<GoblinMovement>();
        _goblinMovement.GoblinRightMovementEvent += ChangeAnimationOnRigthMovement;
        _goblinMovement.GoblinLeftMovementEvent += ChangeAnimationOnLeftMovement;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(IsRunningLeft, false);
            _animator.SetBool(IsRunningRight, false);
            _animator.SetBool(IsIdle, true);
        }
    }

    private void ChangeAnimationOnRigthMovement()
    {
        _animator.SetBool(IsRunningLeft, false);
        _animator.SetBool(IsRunningRight, true);
    }

    private void ChangeAnimationOnLeftMovement()
    {
        _animator.SetBool(IsRunningLeft, false);
        _animator.SetBool(IsRunningRight, true);
    }
}
