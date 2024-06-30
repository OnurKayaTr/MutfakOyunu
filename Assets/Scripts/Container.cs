using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : BaseCounter
{

    [SerializeField] private ChitchenObjSO kitchenObjSO;
    

   
    public override void Interact(Player player)
    {
            Transform kitchenObjSOTranform = Instantiate(kitchenObjSO.prefab);
            kitchenObjSOTranform.GetComponent<KhicthenObj>().SetKitchenObjParent(player);
    }
   
}
