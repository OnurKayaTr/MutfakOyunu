using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform iconConteiner;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    public void SetREcipeSO(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.RecipeName;

        foreach(Transform child in iconConteiner)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach ( ChitchenObjSO chitchenObjSO in recipeSO.chitchenObjSOList)
        {
            Transform iconTransform = Instantiate(iconTemplate, iconConteiner);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = chitchenObjSO.sprite;
        }
    }
}
