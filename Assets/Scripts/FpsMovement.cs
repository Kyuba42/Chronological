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
    [Range(0.5f, 10.0f)]
    public float gravityMultiply = 1.75f;

    [Header("CameraMovement")]
    [Range(1.0f, 10.0f)]
    public float lookSpeed = 1.0f;
    [Range(-360.0f, 360.0f)]
    public float MinHeadTurnX = 1.0f;
    [Range(-360.0f, 360.0f)]
    public float MaxHeadTurnX = 1.0f;

    [Header("Animations")]
    public Animator playerAnimatior = null;

    //------------End of public verables----------//

    //----------------private Verables------------//

    //look verables
    private Vector2 LookRotation = new Vector2(0, 0);
    public bool isPaused = false;

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


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimatior.SetBool("grabbing", true);
            playerAnimatior.SetBool("Idle", false);
            playerAnimatior.SetBool("Walking", false);
            playerAnimatior.SetBool("Jumping", false);
        }
        else if (!characterController.isGrounded)
        {
            if (playerAnimatior.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                playerAnimatior.SetBool("grabbing", false);
                playerAnimatior.SetBool("Idle", false);
                playerAnimatior.SetBool("Jumping", true);
                playerAnimatior.SetBool("Walking", false);
            }
        }
        else if (movementForce.x != 0.0f && movementForce.z != 0.0f)
        {
            if (playerAnimatior.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                playerAnimatior.SetBool("grabbing", false);
                playerAnimatior.SetBool("Idle", false);
                playerAnimatior.SetBool("Jumping", false);
                playerAnimatior.SetBool("Walking", true);
            }
        }
        else
        {
                if (playerAnimatior.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    playerAnimatior.SetBool("grabbing", false);
                    playerAnimatior.SetBool("Idle", true);
                    playerAnimatior.SetBool("Jumping", false);
                    playerAnimatior.SetBool("Walking", false);
                }
        }
        //- mouseLook -//
        if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;

            LookRotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            LookRotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;

            LookRotation.x = Mathf.Clamp(LookRotation.x, MinHeadTurnX, MaxHeadTurnX);

            CharacterModel.transform.eulerAngles = new Vector2(0, LookRotation.y);
            CharacterModelCamera.transform.localEulerAngles = new Vector2(LookRotation.x, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        characterController.Move(movementForce * Time.deltaTime);
        
    }

    public void SetPausedState(bool pause)
    {
        isPaused = pause;
    }
}
