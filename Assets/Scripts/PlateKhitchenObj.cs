using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKhitchenObj : KhicthenObj
{
    [SerializeField] private List<ChitchenObjSO> validKitchenObjList;

    private List<ChitchenObjSO> chitchenObjSOList;
    private void Awake()
    {
        chitchenObjSOList = new List<ChitchenObjSO>();
    }
    public bool TryAddIngredient(ChitchenObjSO kitchenObjSO)

    {
        if (!validKitchenObjList.Contains(kitchenObjSO))
        {
            return false;
        }
        if (chitchenObjSOList.Contains(kitchenObjSO))
        {
            return false;
        }
        else
        {
            chitchenObjSOList.Add(kitchenObjSO);
            return true;
        }
    }
}
