using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private PlayerInputActoins playerInputActoins;

    private void Awake()
    {
        playerInputActoins = new PlayerInputActoins();
        playerInputActoins.Player.Enable();
    }

    public Vector2 GetmovementVectorNormalized() {


        Vector2 inputVector = playerInputActoins.Player.Move.ReadValue<Vector2>();

     
        inputVector = inputVector.normalized;
        return inputVector;

    }
}
