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
    private Vector2 movement;
    
        
    private Vector2 movementInput;
    
    // Update is called once per frame
    private void Update() {
       transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * moveSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        // rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); // fixedDeltaTime -> amount of time elapsed since last time function was called
    }
}
