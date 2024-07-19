using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IKitchenObjParent
{

    public static Player Instance { get; set; }

    public event EventHandler OnpickedSomething;
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {

        public BaseCounter selectedCounter;
    
    }
    

   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private PlayerInputs gameInput;
   [SerializeField] private LayerMask counterLayerMask;
   [SerializeField] private Transform kitchenObjTholdPoint;
   
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;
    private KhicthenObj kitchenObject;


    private void Awake()
    {
        if (Instance == null) { Debug.LogError("There is more than one Player instance"); }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }

    private void GameInput_OnInteractAlternateAction(object sender, EventArgs e)
    {
        if (selectedCounter != null) { selectedCounter.InteractAlternate(this); }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null) { selectedCounter.Interact(this); }
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
           if(raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                //Has ClearCounter
                if (baseCounter != selectedCounter) {
                    SetSelectedCounter(baseCounter);

                  
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
            canMove = moveDir.x !=0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirx, moveDistance);

            if (canMove)
            {
                moveDir = moveDirx;

            }

            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

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




    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
 OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
    }

    public Transform GetKitchenObjFollowTransform()
    {
        return kitchenObjTholdPoint;
    }
    public void SetKitchenObj(KhicthenObj kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if(kitchenObject != null)
        {
            OnpickedSomething?.Invoke(this,EventArgs.Empty);
        }
    }
    public KhicthenObj GetKhicthenObj() { return kitchenObject; }
    public void ClearKitchenObj() { kitchenObject = null; }
    public bool HasKitchenObj()
    {
        return kitchenObject != null;
    }
}
