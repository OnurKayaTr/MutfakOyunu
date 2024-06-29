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
}
