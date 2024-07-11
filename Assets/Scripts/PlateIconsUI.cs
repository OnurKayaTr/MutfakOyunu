using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKhitchenObj plateKhitchenObj;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        plateKhitchenObj.OnIngredientAded += PlateKhitchenObj_OnIngredientAded;
    }

    private void PlateKhitchenObj_OnIngredientAded(object sender, PlateKhitchenObj.OnIngredientAdedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {   foreach (Transform child in transform)
        {
            if(child == iconTemplate) continue;
            Destroy(child.gameObject);
        }
        

        

        foreach(ChitchenObjSO chitchenObjSO in plateKhitchenObj.GetChitchenObjSOList())
        {
            Transform iconTransfotm = Instantiate(iconTemplate, transform);
            iconTransfotm.gameObject.SetActive(true);

            iconTransfotm.GetComponent<PlateIconsSingleUI>().SetKitchenOBJSO(chitchenObjSO);
        }
    }
}
