using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FpsMovement : MonoBehaviour
{

    [Header("Player Game Object")]
    [Tooltip("This Is the Most Exsturnal Game Object(The Thing that actual moves)")]
    public GameObject CharacterModel = null;
    [Tooltip("This Is the camera Located within the game object")]
    public GameObject CharacterModelCamera = null;
    [Tooltip("This is the actual controller that adds the forces")]
    public CharacterController characterController = null;
    //add neck camera here

    [Header("MovementSpeeds")]
    [Range(5.0f, 25.0f)]
    public float movingSpeed = 5.0f;
    [Range(50.0f, 500.0f)]
    public float jumpForceInital = 50.0f;
    public float jumpForceCurrent = 0.0f;
    [Range(50.0f, 500.0f)]
    public float gravity = 5.0f;
    [Range(0.5f,10.0f)]
    public float gravityMultiply = 1.25f;

    [Header("CameraMovement")]
    [Range(1.0f, 10.0f)]
    public float lookSpeed = 1.0f;
    [Range(-360.0f, 360.0f)]
    public float MinHeadTurnX = 1.0f;
    [Range(-360.0f, 360.0f)]
    public float MaxHeadTurnX = 1.0f;

    //------------End of public verables----------//

    //----------------private Verables------------//

    //look verables
    private Vector2 LookRotation = new Vector2(0, 0);

    //Jump verables
    private bool isGrounded = true;


    //-------------End Of private Verables--------//

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementForce;

        //- Moving Left, Right forward And Back -//
        movementForce = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementForce = transform.TransformDirection(movementForce);
        movementForce *= movingSpeed;

        //- jumping -//
        if (CharacterModel.transform.position.y < 4.5f)
            isGrounded = true;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            jumpForceCurrent = 0;
            gravityMultiply = 1.0f;
            jumpForceCurrent += jumpForceInital;
        }
        else
        {
            isGrounded = false;
            gravityMultiply += Time.deltaTime;
            jumpForceCurrent -= (gravity * gravityMultiply) * Time.deltaTime;
            movementForce.y += jumpForceCurrent * Time.deltaTime;
        }

        //- mouseLook -//
        LookRotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        LookRotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;

        LookRotation.x = Mathf.Clamp(LookRotation.x , MinHeadTurnX, MaxHeadTurnX);

        CharacterModel.transform.eulerAngles = new Vector2(0, LookRotation.y);
        CharacterModelCamera.transform.localEulerAngles = new Vector2(LookRotation.x, 0);

        characterController.Move(movementForce * Time.deltaTime);
    }
}
