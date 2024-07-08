using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgges
{
    public event EventHandler<IHasProgges.OnProgressCahangedEventArgs> OnProgressCahanged;
    
    public event EventHandler OnCut;
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSoArray;


    private int cuttingProgress;
    public override void Interact(Player player)
    {
        if (!HasKitchenObj())
        {
            // No Obj
            if (player.HasKitchenObj())
            {
                // Player Carry
                if (HasRecipeWhithInput(player.GetKhicthenObj().GetChitchenObjSO())) {

                    player.GetKhicthenObj().SetKitchenObjParent(this);
                    cuttingProgress = 0;
                    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKhicthenObj().GetChitchenObjSO());

                    OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs { progressNomralized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax });
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
                    }

                }

            }
            else
            {
                //Player NOT Caryy smthng
                GetKhicthenObj().SetKitchenObjParent(player);
            }
        }
    }
    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObj() && HasRecipeWhithInput(GetKhicthenObj().GetChitchenObjSO())) {

            cuttingProgress++;
            OnCut?.Invoke(this, EventArgs.Empty);

            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKhicthenObj().GetChitchenObjSO());
            OnProgressCahanged?.Invoke(this, new IHasProgges.OnProgressCahangedEventArgs { progressNomralized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax });

            if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            {
                ChitchenObjSO outputchitchenObjSO = GetOutputForInput(GetKhicthenObj().GetChitchenObjSO());
                GetKhicthenObj().DestroySelf();
                KhicthenObj.SpawnKitchenObj(outputchitchenObjSO, this);
            }
        }
    }

    private bool HasRecipeWhithInput(ChitchenObjSO inputchitchenObjSO) {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputchitchenObjSO);
        return cuttingRecipeSO != null;
    }

    private ChitchenObjSO GetOutputForInput(ChitchenObjSO inputchitchenObjSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputchitchenObjSO);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else { 
        return null;
        }     
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(ChitchenObjSO inputchitchenObjSO) {

        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSoArray)
        {
            if (cuttingRecipeSO.input == inputchitchenObjSO)
            {
                return cuttingRecipeSO;
            }

        }
        return null;


    }
}
