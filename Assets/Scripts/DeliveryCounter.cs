using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObj())
        {
            if (player.GetKhicthenObj().TryGetPlate(out PlateKhitchenObj plateKhitchenObj))
            {
                // Only Accepts Plates

                DeliveryManager.Instance.DeliverRecipe(plateKhitchenObj);
                player.GetKhicthenObj().DestroySelf();
            }
        }
    }
}
