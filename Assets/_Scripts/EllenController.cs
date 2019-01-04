using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenController : MonoBehaviour
{
    //variables for our controller
    float speed = 5;
    float rotationSpeed = 100;
    float rotation = 0; 
  
    Vector3 moveDirection = Vector3.zero;

    CharacterController controller; 
    Animator animator;

  

    // Start is called before the first frame update
    void Start()
    {
        //Getting the model for the controller and animator
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    void movement()
    {
      if (controller.isGrounded)
        {

           if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W))) //Walking forward
            {
                if (Input.GetKey(KeyCode.D)) //walking right
                {
             
                    moveDirection = new Vector3(1, 0, 1);
                    moveDirection *= speed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }
                else if (Input.GetKey(KeyCode.A)) //walking left
                {
                
                    moveDirection = new Vector3(-1, 0, 1);
                    moveDirection *= speed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }

                animator.SetBool("moving", true);
                animator.SetInteger("transitionStage", 1);
                moveDirection = new Vector3(0, 0, 1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);

            }
           else if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.S))) //Walking backward
            {
                if (Input.GetKey(KeyCode.D)) //walking backward right
                {
                    moveDirection = new Vector3(1, 0, -1);
                    moveDirection *= speed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }
                else if (Input.GetKey(KeyCode.A))//walking backward left
                {
                    moveDirection = new Vector3(-1, 0, -1);
                    moveDirection *= speed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }
               
                animator.SetBool("moving", true);
                animator.SetInteger("transitionStage", 2);
                moveDirection = new Vector3(0, 0, -1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);

            }
           else if((Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.W))) //Running forward
            {
                
                animator.SetBool("moving", true);
                animator.SetInteger("transitionStage", 3);
                moveDirection = new Vector3(0, 0, 1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);
            }
           else if ((Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.S))) //Running backward
            {
                animator.SetBool("moving", true);
                animator.SetInteger("transitionStage", 4);
                moveDirection = new Vector3(0, 0, -1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);
            }
           else
            {
                animator.SetBool("moving", false);
                moveDirection = new Vector3(0, 0, 0);
                animator.SetInteger("transitionStage", 0);

            }
        }

        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        controller.Move(moveDirection* Time.deltaTime);
    }
}
