using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateComplateViusal : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjSo_GameOBJ
    {
        public ChitchenObjSO kitchenObjSo;
        public GameObject gameObject;
    }
    [SerializeField] private PlateKhitchenObj plateKhitchenObj;
    [SerializeField] private List<KitchenObjSo_GameOBJ> kitchenObjSoGameObjList;

    private void Start()
    {
        plateKhitchenObj.OnIngredientAded += PlateKhitchenObj_OnIngredientAded;
        foreach (KitchenObjSo_GameOBJ kitchenObjSo_GameOBJ in kitchenObjSoGameObjList)
        {
            
                kitchenObjSo_GameOBJ.gameObject.SetActive(false);

        }

    }

    private void PlateKhitchenObj_OnIngredientAded(object sender, PlateKhitchenObj.OnIngredientAdedEventArgs e)
    {
        foreach (KitchenObjSo_GameOBJ kitchenObjSo_GameOBJ in kitchenObjSoGameObjList)
        {
            if (kitchenObjSo_GameOBJ.kitchenObjSo == e.kitchenObjSO)
            {
                kitchenObjSo_GameOBJ.gameObject.SetActive(true);


            }

        }
    }
}
