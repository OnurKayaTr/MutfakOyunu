using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]  private ChitchenObjSO kitchenObjSO;
    
    
    
    

    public override void Interact(Player player)
    {
        if (!HasKitchenObj())
        {
            // No Obj
            if (player.HasKitchenObj())
            {
                // Player Carry
                player.GetKhicthenObj().SetKitchenObjParent(this);
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
                if (player.GetKhicthenObj().TryGetPlate(out PlateKhitchenObj plateKhitchenObj)) {
                    //Player Holding Plate
                    if (plateKhitchenObj.TryAddIngredient(GetKhicthenObj().GetChitchenObjSO()))
                    {
                        GetKhicthenObj().DestroySelf();
                    }

                }
                else
                {
                    //player not cry plate But some 
                    if(GetKhicthenObj().TryGetPlate(out  plateKhitchenObj))
                    {
                        if (plateKhitchenObj.TryAddIngredient(player.GetKhicthenObj().GetChitchenObjSO())){
                            player.GetKhicthenObj().DestroySelf();
                        }
                    }
                }

            }
            else {
                //Player NOT Caryy smthng
                GetKhicthenObj().SetKitchenObjParent(player);
            }
        }

    }

   
}
