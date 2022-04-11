using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseMovement : MonoBehaviour
{
    Rigidbody PRB;

    [SerializeField] InputAction Movement;
    Vector2 MovementInput;
    [SerializeField] float MovementSpeed;

    [SerializeField] float TopHorizontalMovementSpeed;
    [SerializeField] float TopVerticalMovementSpeed;

    //Enabling action function
    private void OnEnable()
    {
        Movement.Enable();
    }

    //Disabling action function
    private void OnDisable()
    {
        Movement.Disable();
    }

    //On start checking if TopVerticalMovementSpeed is greater than 0
    private void Start()
    {
        if (TopVerticalMovementSpeed > 0)
        {
            //Prevents player from exceeding top speed 
            TopVerticalMovementSpeed *= -1;
        }

        //Initialisng Player's Rigidbody
        PRB = GetComponent<Rigidbody>();
    }

    //Using Update to read in the Movement input allowing Player to move with WASD keys
    private void Update()
    {
        MovementInput = Movement.ReadValue<Vector2>();
    }

    //Using FixedUpdate with physics
    private void FixedUpdate()
    {
        //Clamping Player's speed so Player can't exceed their TopVerticalMovementSpeed or their TopHorizontalMovementSpeed
        PRB.AddForce(new Vector3(MovementInput.x, 0, MovementInput.y) * MovementSpeed);

        if (PRB.velocity.y < TopVerticalMovementSpeed)
        {
            PRB.velocity = new Vector3(PRB.velocity.x, TopVerticalMovementSpeed, PRB.velocity.z);
        }

        Vector2 tempXZ = new Vector2(PRB.velocity.x, PRB.velocity.z);
        if (tempXZ.magnitude > TopHorizontalMovementSpeed)
        {
            tempXZ = tempXZ.normalized * TopHorizontalMovementSpeed;
            PRB.velocity = new Vector3(tempXZ.x, PRB.velocity.y, tempXZ.y);
        }
    }

}