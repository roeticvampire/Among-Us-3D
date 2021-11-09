using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] private float magnitude;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;



    [SerializeField] private Animator animator;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    
    public float movementThreshold=1f;

    // Start is called before the first frame update
    void Start()
    {
        characterController=GetComponent<CharacterController>();
        velocity=Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {//characterController.Move(Vector3.forward);
            if(SelectionManager.isWorkingOnTasks) return;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
            velocity.y=-2f;

        float x=Input.GetAxis("Horizontal");
        float z=Input.GetAxis("Vertical");
        Vector3 move=transform.right*x + transform.forward * z;
        move=Vector3.ClampMagnitude(move,1f);
        move*=magnitude*Time.deltaTime;
        
        characterController.Move(move);
        
        if(Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);


        
        animator.SetBool("isRunning", (x!=0f || z!=0f));     

    }
}
