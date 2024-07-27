using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public static PlayerInputs Instance {  get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;
    private PlayerInputActoins playerInputActoins;

    private void Awake()
    {
        Instance = this;
        playerInputActoins = new PlayerInputActoins();
        playerInputActoins.Player.Enable();

        playerInputActoins.Player.Interact.performed += Interact_performed;
        playerInputActoins.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActoins.Player.Pause.performed += Pause_performed;
    }
    private void OnDestroy()
    {
        playerInputActoins.Player.Interact.performed -= Interact_performed;
        playerInputActoins.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInputActoins.Player.Pause.performed -= Pause_performed;
        playerInputActoins.Dispose();
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetmovementVectorNormalized() {


        Vector2 inputVector = playerInputActoins.Player.Move.ReadValue<Vector2>();

     
        inputVector = inputVector.normalized;
        return inputVector;

    }
}
