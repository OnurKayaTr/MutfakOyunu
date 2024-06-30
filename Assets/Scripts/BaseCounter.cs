using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjParent
{
    
    [SerializeField] private Transform counterTopPoint;

    private KhicthenObj kitchenObject;

    public virtual void Interact(Player player)
    {    
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
