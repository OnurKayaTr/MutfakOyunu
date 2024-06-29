using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjParent 
{
    public Transform GetKitchenObjFollowTransform();
    
    public void SetKitchenObj(KhicthenObj kitchenObject);
    
    public KhicthenObj GetKhicthenObj();
    public void ClearKitchenObj();
    public bool HasKitchenObj();
    
        
    
}
