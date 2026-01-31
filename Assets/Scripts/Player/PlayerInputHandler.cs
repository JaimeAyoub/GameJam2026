using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")] [SerializeField]
    private InputActionAsset playerControls;

    private string playerActionMapName = "Player";
    private string uiActionMapName = "UI";
    private string movement = "Move";
    private string rotation = "Rotation";
    private string sprint = "Sprint";
    private string pause = "Pause";
    private string resume = "Resume";

    // Player InputActions
    private InputAction _movementAction;
    private InputAction _rotationAction;
    private InputAction _sprintAction;
    private InputAction _pauseAction;
    //private InputAction _mayusAction;


    // Player InputActions
    private InputAction _resumeAction;

    // Player Events
    public event Action PauseEvent;
    public static event Action MovementEvent;
    public static event Action StopMovementEvent;

    // UI Events
    public event Action ResumeEvent;

    public Vector2 MovementInput { get; private set; }
    public Vector2 RotationInput { get; private set; }
    public bool SprintTriggered { get; private set; }
    //public bool IsInMayus { get; private set; }

    private void EnablePlayerInput()
    {
        var playerMapReference = playerControls.FindActionMap(playerActionMapName);
        var uiMapReference = playerControls.FindActionMap(uiActionMapName);
        

        _movementAction = playerMapReference.FindAction(movement);
        _rotationAction = playerMapReference.FindAction(rotation);
        
        _sprintAction = playerMapReference.FindAction(sprint);
        _pauseAction = playerMapReference.FindAction(pause);

        _resumeAction = uiMapReference.FindAction(resume);

        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents() 
    {
        Debug.Log("SubscribeActionValuesToInputEvents");
        _movementAction.performed += OnPlayerMove;
        _movementAction.canceled += OnStopPlayerMove;


        _rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        _rotationAction.canceled += _ => RotationInput = Vector2.zero;


        _sprintAction.performed += _ => SprintTriggered = true;
        _sprintAction.canceled += _ => SprintTriggered = false;


        _pauseAction.performed += OnPause;
        _resumeAction.performed += OnResume;

        //_mayusAction.performed += _ => IsInMayus = true;
        //_mayusAction.canceled += _ => IsInMayus = false;
    }


    private void OnPause(InputAction.CallbackContext ctx)
    {
        
        PauseEvent?.Invoke();
        SetUI();
    }

    private void OnResume(InputAction.CallbackContext ctx)
    {
        ResumeEvent?.Invoke();
        SetGameplay();
    }

    private void OnPlayerMove(InputAction.CallbackContext ctx)
    {
        
        MovementEvent?.Invoke();
        MovementInput = ctx.ReadValue<Vector2>();
    }

    private void OnStopPlayerMove(InputAction.CallbackContext ctx)
    {
        StopMovementEvent?.Invoke();
        MovementInput = Vector2.zero;
    }

    private void OnEnable()
    {
        SetGameplay();
        EnablePlayerInput();
    }


    private void OnDisable()
    {
        playerControls.FindActionMap(playerActionMapName).Disable();
    }


    public void SetGameplay()
    {
        playerControls.FindActionMap(playerActionMapName).Enable();
        playerControls.FindActionMap(uiActionMapName).Disable();
    }

    public void SetUI()
    {
        playerControls.FindActionMap(playerActionMapName).Disable();
        playerControls.FindActionMap(uiActionMapName).Enable();
    }

    public void SetCombat()
    {
        playerControls.FindActionMap(playerActionMapName).Disable();
        playerControls.FindActionMap(uiActionMapName).Disable();
    }


}
