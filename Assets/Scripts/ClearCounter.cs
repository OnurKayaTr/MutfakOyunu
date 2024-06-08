using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]  private ChitchenObjSO kitchenObjSO;
    [SerializeField] private Transform counterTopPoint;

    public void Interact()
    {
        Debug.Log("Interact!");
        Transform kitchenObjSOTranform = Instantiate(kitchenObjSO.prefab, counterTopPoint);
        kitchenObjSOTranform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjSOTranform.GetComponent<KhicthenObj>().GetChitchenObjSO().objectName);
    }
}
