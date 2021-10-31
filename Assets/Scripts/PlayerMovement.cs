using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// todo rename -> character controller ( or movement controller)
// todo extend:
// - compress and enlarge mesh?sprite? based on inertia?g-force?
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform interactor;
    private Vector2 movementInput;
    
    // Update is called once per frame
    private void Update()
    {
        float horizontalMovement = movementInput.x;
        float verticalMovement = movementInput.y;        
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetFloat("Vertical", verticalMovement);
        animator.SetFloat("Speed", movementInput.sqrMagnitude);

        if (
            horizontalMovement == 1
            || horizontalMovement == -1
            || verticalMovement == 1
            || verticalMovement == -1
        ) {
            animator.SetFloat("LastHorizontal", horizontalMovement);
            animator.SetFloat("LastVertical", verticalMovement);
        }

        // todo - check if only rotating interactor is ok
        if (horizontalMovement > 0) {
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (horizontalMovement < 0) {
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (verticalMovement > 0) {
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (verticalMovement < 0) {
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movementInput.normalized * moveSpeed * Time.fixedDeltaTime); // fixedDeltaTime -> amount of time elapsed since last time function was called
    }
}
