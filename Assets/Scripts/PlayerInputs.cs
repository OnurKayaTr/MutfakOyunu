using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    private PlayerInputActoins playerInputActoins;

    private void Awake()
    {
        playerInputActoins = new PlayerInputActoins();
        playerInputActoins.Player.Enable();

        playerInputActoins.Player.Interact.performed += Interact_performed;
        playerInputActoins.Player.InteractAlternate.performed += InteractAlternate_performed;
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
