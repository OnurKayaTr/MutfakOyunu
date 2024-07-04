using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSoArray;
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
            }
        }
    }
    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObj() && HasRecipeWhithInput(GetKhicthenObj().GetChitchenObjSO())) {
            ChitchenObjSO outputchitchenObjSO = GetOutputForInput(GetKhicthenObj().GetChitchenObjSO());
            GetKhicthenObj().DestroySelf();
            KhicthenObj.SpawnKitchenObj(outputchitchenObjSO, this);
            
        }
    }

    private bool HasRecipeWhithInput(ChitchenObjSO inputChitchenObjSO) {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSoArray)
        {
            if (cuttingRecipeSO.input == inputChitchenObjSO)
            {
                return true;
            }

        }
        return false;
    }

    private ChitchenObjSO GetOutputForInput(ChitchenObjSO inputchitchenObjSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSoArray)
        {
            if (cuttingRecipeSO.input == inputchitchenObjSO)
            {
                return cuttingRecipeSO.output;
            }
           
        }
        return null;
    }
}
