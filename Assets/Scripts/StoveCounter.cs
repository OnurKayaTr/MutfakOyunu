using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter,IHasProgges

{
    public event EventHandler<IHasProgges.OnProgressCahangedEventArgs> OnProgressCahanged;

    public event EventHandler<OnStateChangedEventArggs> OnStateChanged;
    public class OnStateChangedEventArggs: EventArgs { public State state; }
    public  enum State
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
                    OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs
                    {
                        progressNomralized = fryingTimer / fryingRecipeSO.FryingTimerMax
                    });
                    if (fryingTimer > fryingRecipeSO.FryingTimerMax)
                {
                    //Fried
                   
                    GetKhicthenObj().DestroySelf();

                    KhicthenObj.SpawnKitchenObj(fryingRecipeSO.output, this);
                        

                        
                        state = State.Fried;
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKhicthenObj().GetChitchenObjSO());

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArggs()
                        {
                            state = state
                        });

                    }
                break;
                    case State.Fried:
                    burningTimer += Time.deltaTime;
                    OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs
                    {
                        progressNomralized = burningTimer / burningRecipeSO.BurningTimerMax
                    });
                    if (burningTimer > burningRecipeSO.BurningTimerMax)
                    {
                        //Fried

                        GetKhicthenObj().DestroySelf();

                        KhicthenObj.SpawnKitchenObj(burningRecipeSO.output, this);
                        

                        state = State.Burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArggs()
                        {
                            state = state
                        });
                        OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs
                        {
                            progressNomralized = 0f
                        });
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
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArggs()
                    {
                        state = state
                    });

                    OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs
                    {
                        progressNomralized = fryingTimer / fryingRecipeSO.FryingTimerMax
                    });
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

                if (player.GetKhicthenObj().TryGetPlate(out PlateKhitchenObj plateKhitchenObj))
                {
                    //Player Holding Plate
                    if (plateKhitchenObj.TryAddIngredient(GetKhicthenObj().GetChitchenObjSO()))
                    {
                        GetKhicthenObj().DestroySelf();
                        state = State.Idle;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArggs()
                        {
                            state = state
                        });

                        OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs
                        {
                            progressNomralized = 0f
                        });
                    }

                }

            }
            else
            {
                //Player NOT Caryy smthng
                GetKhicthenObj().SetKitchenObjParent(player);
                state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArggs()
                {
                    state = state
                });

                OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs
                {
                    progressNomralized = 0f
                });
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
