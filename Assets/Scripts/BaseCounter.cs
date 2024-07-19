using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjParent
{
    public static event EventHandler OnAnyObjPlacedHere;
    [SerializeField] private Transform counterTopPoint;

    private KhicthenObj kitchenObject;

    public virtual void Interact(Player player)
    {    
    }
    public virtual void InteractAlternate(Player player)
    {

    }
    public Transform GetKitchenObjFollowTransform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObj(KhicthenObj kitchenObject)
    {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null) {

            OnAnyObjPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }
    public KhicthenObj GetKhicthenObj() { return kitchenObject; }
    public void ClearKitchenObj() { kitchenObject = null; }
    public bool HasKitchenObj()
    {
        return kitchenObject != null;
    }
}
