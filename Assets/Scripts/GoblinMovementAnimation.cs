using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovementAnimation : MonoBehaviour
{
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
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunningRight", false);
            _animator.SetBool("isIdle", true);
        }
    }

    private void ChangeAnimationOnRigthMovement()
    {
        _animator.SetBool("isRunningLeft", false);
        _animator.SetBool("isRunningRight", true);
    }

    private void ChangeAnimationOnLeftMovement()
    {
        _animator.SetBool("isRunningRight", false);
        _animator.SetBool("isRunningLeft", true);
    }
}
