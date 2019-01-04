using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    /*
    public float forwardForce = 3000f;
    public float sidewaysForce = 3000f;
    public bool moveForward = false;
    public bool moveLeft = false;
    public bool moveBackward = false;
    public bool moveRight = false;
    */
    public float speed = 100;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    void Start()
    {
        //TODO: orient the body
        rb = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {

        //method 2 is similar to method one but relies on Unity mapping of wasd and arrow keys
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }


}
