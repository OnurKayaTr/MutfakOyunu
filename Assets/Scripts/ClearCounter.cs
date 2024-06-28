using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]  private ChitchenObjSO kitchenObjSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;
    private KhicthenObj kitchenObject;
    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObjSO != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjSOTranform = Instantiate(kitchenObjSO.prefab, counterTopPoint);
            kitchenObjSOTranform.GetComponent<KhicthenObj>().SetClearCounter(this);
            
        }
        else { Debug.Log(kitchenObject.GetClearCounter()); }

        
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
