using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public Transform interactorContainer;
    public Transform interactorForward;
    public LayerMask InteractionLayerMask;
    private Vector2 movementInput;
    private bool lockMovement = false;
    
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
            interactorContainer.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (horizontalMovement < 0) {
            interactorContainer.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (verticalMovement > 0) {
            interactorContainer.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (verticalMovement < 0) {
            interactorContainer.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>();
    }


    private float prevInteractValue = 0;
    Collider[] colliders;
    public void OnInteract(InputAction.CallbackContext ctx)
    {
        float newInteractValue = ctx.ReadValue<float>();
        if (newInteractValue != prevInteractValue)
        {
            prevInteractValue = newInteractValue;
            if (newInteractValue == 1)
            {
                lockMovement = true;
                var hit = Physics2D.OverlapCircle(interactorForward.transform.position, 0.2f, InteractionLayerMask);
                if (hit)
                {
                    Debug.Log ("Hit" + hit.gameObject);
                }
            }
            else
            {
                lockMovement = false;
            }
        }
    }

    private void FixedUpdate() {
        if (!lockMovement)
        {
            rb.MovePosition(rb.position + movementInput.normalized * moveSpeed * Time.fixedDeltaTime); // fixedDeltaTime -> amount of time elapsed since last time function was called
        }
    }
}
