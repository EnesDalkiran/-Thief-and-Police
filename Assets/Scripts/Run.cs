using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public CharacterController controller;

    int speed = 5;
    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;
    public Transform cam;
    Animator animator;
    void Start()
    {
        
        controller = gameObject.GetComponent<CharacterController>();   
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if (!controller.isGrounded)
        {
            controller.Move(Physics.gravity*Time.deltaTime);
        }
        Vector3 direction = new Vector3(x , 0.0f, z).normalized;
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("run", true);
            float targetangle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref TurnSmoothVelocity,TurnSmoothTime);
            transform.rotation=Quaternion.Euler(0f,angle,0f);
            Vector3 movedirection = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            controller.Move(movedirection.normalized * speed*Time.deltaTime);
        }
        else
        {
            animator.SetBool("run", false);
        }

    }
}
