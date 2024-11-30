using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Assets")]
    [SerializeField] private InputActionAsset playerContols;

    [Header("Action Map Name References")]
    [SerializeField] private string actionMapName = "PlayerMove";

    //PlayerInupt system
    [SerializeField] private string move = "Move";
    [SerializeField] private string look = "Look";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprite";

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    public Vector2 moveInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool jumpTriggered { get; private set; }
    public float sprintValue { get; private set; }


    public static PlayerInputHandler instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        moveAction = playerContols.FindActionMap(actionMapName).FindAction(move);
        lookAction = playerContols.FindActionMap(actionMapName).FindAction(look);
        jumpAction = playerContols.FindActionMap(actionMapName).FindAction(jump);
        sprintAction = playerContols.FindActionMap(actionMapName).FindAction(sprint);
        RegisterInputAction();
    }

    void RegisterInputAction()
    {
        moveAction.performed += context => moveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => moveInput = Vector2.zero;

        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;

        jumpAction.performed += context => jumpTriggered = true;
        jumpAction.canceled += context => jumpTriggered = false;

        sprintAction.performed += context => sprintValue = context.ReadValue<float>();
        sprintAction.canceled += context => sprintValue = 0f;
    }



    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable(); 
        jumpAction.Disable(); 
        sprintAction.Disable();
    }
}
