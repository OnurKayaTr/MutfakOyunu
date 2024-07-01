using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class KhicthenObj : MonoBehaviour
{
    [SerializeField] private ChitchenObjSO kitchenObjSO;

    private IKitchenObjParent kitchenObjParent;
    public ChitchenObjSO GetChitchenObjSO() { return kitchenObjSO; }

    public void SetKitchenObjParent(IKitchenObjParent kitchenObjParent) {
        if (this.kitchenObjParent !=null)
        {
            this.kitchenObjParent.ClearKitchenObj();
        }
        this.kitchenObjParent = kitchenObjParent;
        if (kitchenObjParent.HasKitchenObj()) {
            Debug.LogError("IKitchenObjParent alrdy has a kitobj");
        
        }
        kitchenObjParent.SetKitchenObj(this);
        transform.parent = kitchenObjParent.GetKitchenObjFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjParent GetKitchenObjParent() { return kitchenObjParent; }

    public void DestroySelf()
    {
        kitchenObjParent.ClearKitchenObj();
        Destroy(gameObject);
    }

    public static KhicthenObj SpawnKitchenObj(ChitchenObjSO chitchenObjS,IKitchenObjParent kitchenObjParent)
    {
        
        Transform kitchenObjSOTranform = Instantiate(chitchenObjS.prefab);
        KhicthenObj khicthenObj = kitchenObjSOTranform.GetComponent<KhicthenObj>();
        khicthenObj.SetKitchenObjParent(kitchenObjParent);
        return khicthenObj;
    }
}
