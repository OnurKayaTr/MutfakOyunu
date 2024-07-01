using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObj;

    [SerializeField] private ChitchenObjSO kitchenObjSO;
    

   
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObj())
        {
            KhicthenObj.SpawnKitchenObj(kitchenObjSO, player);
            

            OnPlayerGrabbedObj?.Invoke(this, EventArgs.Empty);
        }
        
    }
   
}
