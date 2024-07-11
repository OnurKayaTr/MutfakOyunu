using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKhitchenObj : KhicthenObj
{
    public event EventHandler<OnIngredientAdedEventArgs> OnIngredientAded;
    public class OnIngredientAdedEventArgs : EventArgs
    {
        public ChitchenObjSO kitchenObjSO;
    }
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
            OnIngredientAded?.Invoke(this,new OnIngredientAdedEventArgs { kitchenObjSO = kitchenObjSO });
            return true;
        }
    }


    public List<ChitchenObjSO> GetChitchenObjSOList()
    {
        return chitchenObjSOList;
    }
}
