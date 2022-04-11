using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    Rigidbody PRB;
    [SerializeField] InputAction Jump;
    [SerializeField] float JumpPower;

    //Enabling action function 
    private void OnEnable()
    {
        //Used for when Player has jumped 
        Jump.performed += Jumped;
        Jump.Enable();
    }

    //Disabling action function
    private void OnDisable()
    {
        //Used for when Player has jumped 
        Jump.performed -= Jumped;
        Jump.Disable();
    }

    private void Start()
    {
        //Initialisng Player's Rigidbody on Start
        PRB = GetComponent<Rigidbody>();
    }

    //Calculation to determine if Player has Jumped 
    private void Jumped(InputAction.CallbackContext obj)
    {
        //isGrounded false to begin with as Player won't have Jumped
        bool isGrounded = false;

        //Using Raycast to determine if Player has Jumped then setting isGrounded to be true so Player can't jump again
        if (Physics.Raycast(transform.position, Vector3.down, transform.localScale.y/2 + .1f))
        {
            isGrounded = true;
        }

        if (!isGrounded)
            return;

        if(obj.ReadValue<float>() > 0)
        {
            //Using addforce and Player's JumpPower so Player can jump when spacebar is pressed
            PRB.AddForce(0, JumpPower, 0);
        }
    }
}
