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
    public float movingSpeed = 17.5f;
    [Range(50.0f, 500.0f)]
    public float jumpForceInital = 400.0f;
    public float jumpForceCurrent = 0.0f;
    [Range(50.0f, 500.0f)]
    public float gravity = 350f;
    [Range(0.5f,10.0f)]
    public float gravityMultiply = 1.75f;

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

        ////- jumping -//
        ///
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            jumpForceCurrent = 0;
            gravityMultiply = 1.0f;
            jumpForceCurrent += jumpForceInital;
        }
        else
        {
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
