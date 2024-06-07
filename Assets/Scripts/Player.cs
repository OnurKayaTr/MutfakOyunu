using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {

        public ClearCounter selectedCounter;
    
    }
    

   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private PlayerInputs gameInput;
   [SerializeField] private LayerMask counterLayerMask;
   private Vector3 lastInteractDir;
    private ClearCounter selectedCounter;

    private void Awake()
    {
        if (Instance == null) { Debug.LogError("There is more than one Player instance"); }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null) { selectedCounter.Interact(); }
    }

    private void Update()
    {
        HandelMovement();
        HandleOInteractions();
    }



    private void HandleOInteractions()
    {
        float interactDistance = 2f;
        Vector2 inputVector = gameInput.GetmovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero) { 
        lastInteractDir = moveDir;
        }
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
           if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                if (clearCounter != selectedCounter) {
                    SetSelectedCounter (clearCounter);

                  
                }              
            }else {
                SetSelectedCounter(null);


                
            }
           
        }
        else
        {
            SetSelectedCounter(null);


        }
      
    }
    private void HandelMovement()
    {
        Vector2 inputVector = gameInput.GetmovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirx = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirx, moveDistance);

            if (canMove)
            {
                moveDir = moveDirx;

            }

            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else { }

            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        // transform.position += moveDir * Time.deltaTime * moveSpeed;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }




    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
 OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
    }
}
