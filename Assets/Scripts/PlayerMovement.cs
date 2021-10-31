using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
        


    
    
    // Update is called once per frame
    void Update()
    {
        #if (ENABLE_LEGACY_INPUT_MANAGER)
                // Debug.Log("INPUT_Manager");
                
                // handle input
                movement.x = Input.GetAxisRaw("Horizontal"); // todo see if new unity input system is good and replace this if necessary
                movement.y = Input.GetAxisRaw("Vertical");
                
                
                
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);

                if (
                    Input.GetAxisRaw("Horizontal") == 1
                    || Input.GetAxisRaw("Horizontal") == -1
                    || Input.GetAxisRaw("Vertical") == 1
                    || Input.GetAxisRaw("Vertical") == -1
                ) {
                    animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
                }

                // todo - check if only rotating interactor is ok
                if (Input.GetAxisRaw("Horizontal") > 0) {
                    interactor.localRotation = Quaternion.Euler(0, 0, 90);
                }
                if (Input.GetAxisRaw("Horizontal") < 0) {
                    interactor.localRotation = Quaternion.Euler(0, 0, -90);
                }
                if (Input.GetAxisRaw("Vertical") > 0) {
                    interactor.localRotation = Quaternion.Euler(0, 0, 180);
                }
                if (Input.GetAxisRaw("Vertical") < 0) {
                    interactor.localRotation = Quaternion.Euler(0, 0, 0);
                }
                
                // todo - for collider test box and circle
                // code monkey
                // if (Input.GetKey(KeyCode.W)) {
                //     transform.position += new Vector3(0, 1);
                // }


        #elif (ENABLE_INPUT_SYSTEM)
                // Debug.Log("INPUT_System");
        #elif (ENABLE_INPUT_SYSTEM && ENABLE_LEGACY_INPUT_MANAGER)
                        Debug.Log("INPUT_System");
        #else
                        Debug.Log("INPUT_Manager");
        #endif
    }

    private void FixedUpdate() {

        // Vector2 blub = movement.normalized
        
        // movement ( brackeys ) -> using "normalized" to equalize speed regardless of direction 
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); // fixedDeltaTime -> amount of time elapsed since last time function was called
        
        
        // from code monkey
        // Vector3 moveDir = new Vector3(movement.x, movement.y).normalized;    // make sure to keep speed on vertical movement
        // rb.velocity = moveDir; // using velocity instead of MovePosition since "code monkey" said there can be strange bugs when moving with MovePosition inside of clissions colliders
        // -> if using this set rigidbody2d to interpolate to "interpolate" :)
    }
}
