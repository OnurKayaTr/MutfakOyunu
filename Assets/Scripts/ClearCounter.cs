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

            }
            else {
                //Player NOT Caryy smthng
                GetKhicthenObj().SetKitchenObjParent(player);
            }
        }

    }

   
}
