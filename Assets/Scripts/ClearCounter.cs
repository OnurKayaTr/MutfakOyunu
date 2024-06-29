using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjParent
{
    [SerializeField]  private ChitchenObjSO kitchenObjSO;
    [SerializeField] private Transform counterTopPoint;
    
    private KhicthenObj kitchenObject;
    

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjSOTranform = Instantiate(kitchenObjSO.prefab, counterTopPoint);
            kitchenObjSOTranform.GetComponent<KhicthenObj>().SetKitchenObjParent(this);
            
        }
        else {

            //Playera obje ver 
            kitchenObject.SetKitchenObjParent(player);
        }

        
    }

    public Transform GetKitchenObjFollowTransform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObj(KhicthenObj kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KhicthenObj GetKhicthenObj() { return kitchenObject; }
    public void ClearKitchenObj() { kitchenObject = null; }
    public bool HasKitchenObj()
    {
        return kitchenObject != null;
    }
}
