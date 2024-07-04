using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter
{

    private  enum State
    { Idle,Frying,Fried,Burned

    }

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArry;
    [SerializeField] private BurninRecipeSO[] burningRecipeSOArry;

    private State state;
    private float fryingTimer;
    private FryingRecipeSO fryingRecipeSO;
    private float burningTimer;
    private BurninRecipeSO burningRecipeSO;


    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObj())
            switch (state)
        {
            case State.Idle:
                break;
                case State.Frying:
                fryingTimer += Time.deltaTime;
                if (fryingTimer > fryingRecipeSO.FryingTimerMax)
                {
                    //Fried
                   
                    GetKhicthenObj().DestroySelf();

                    KhicthenObj.SpawnKitchenObj(fryingRecipeSO.output, this);
                        

                        
                        state = State.Fried;
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKhicthenObj().GetChitchenObjSO());
                    }
                break;
                    case State.Fried:
                    burningTimer += Time.deltaTime;
                    if (burningTimer > burningRecipeSO.BurningTimerMax)
                    {
                        //Fried

                        GetKhicthenObj().DestroySelf();

                        KhicthenObj.SpawnKitchenObj(burningRecipeSO.output, this);
                        

                        state = State.Burned;
                    }
                    break;

                case State.Burned:
                break;
                
        }
        
        
    }
    public override void Interact(Player player)
    {
        if (!HasKitchenObj())
        {
            // No Obj
            if (player.HasKitchenObj())
            {
                // Player Carry
                if (HasRecipeWhithInput(player.GetKhicthenObj().GetChitchenObjSO()))
                {

                    player.GetKhicthenObj().SetKitchenObjParent(this);
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKhicthenObj().GetChitchenObjSO());

                    state = State.Frying;
                    fryingTimer = 0f;
                }

            }
            else
            {
                // Player not carry
            }

        }
        else
        { // Obj here
            if (player.HasKitchenObj())
            {
                //Player Caryy smthng

            }
            else
            {
                //Player NOT Caryy smthng
                GetKhicthenObj().SetKitchenObjParent(player);
                state = State.Idle;
            }

        }
    }


    private bool HasRecipeWhithInput(ChitchenObjSO inputchitchenObjSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputchitchenObjSO);
        return fryingRecipeSO != null;
    }

    private ChitchenObjSO GetOutputForInput(ChitchenObjSO inputchitchenObjSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputchitchenObjSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(ChitchenObjSO inputchitchenObjSO)
    {

        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArry)
        {
            if (fryingRecipeSO.input == inputchitchenObjSO)
            {
                return fryingRecipeSO;
            }

        }
        return null;
    }
    private BurninRecipeSO GetBurningRecipeSOWithInput(ChitchenObjSO inputchitchenObjSO)
    {

        foreach (BurninRecipeSO burningRecipeSO in burningRecipeSOArry)
        {
            if (burningRecipeSO.input == inputchitchenObjSO)
            {
                return burningRecipeSO;
            }

        }
        return null;
    }
}
