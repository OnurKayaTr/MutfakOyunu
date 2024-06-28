using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class KhicthenObj : MonoBehaviour
{
    [SerializeField] private ChitchenObjSO kitchenObjSO;

    private ClearCounter clearCounter;
    public ChitchenObjSO GetChitchenObjSO() { return kitchenObjSO; }

    public void SetClearCounter(ClearCounter clearCounter) {
        if (this.clearCounter !=null)
        {
            this.clearCounter.ClearKitchenObj();
        }
        this.clearCounter = clearCounter;
        if (clearCounter.HasKitchenObj()) {
            Debug.LogError("counteralrdy has a kitobj");
        
        }
        clearCounter.SetKitchenObj(this);
        transform.parent = clearCounter.GetKitchenObjFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() { return clearCounter; }
}
