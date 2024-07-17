using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance {get ; private set;}

    [SerializeField] private RecipeListSO recipeListSO;
    private List<RecipeSO> waitingRecipeSoList;

    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax= 4f;
    private int waitingRecipeMax = 4;


    private void Awake()
    {
        Instance = this;
        waitingRecipeSoList = new List<RecipeSO>();
    }
    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {


            spawnRecipeTimer = spawnRecipeTimerMax;

            if (waitingRecipeSoList.Count < waitingRecipeMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSoList[Random.Range(0, recipeListSO.recipeSoList.Count)];
                Debug.Log(waitingRecipeSO.RecipeName);
                waitingRecipeSoList.Add(waitingRecipeSO);
            }
        }
        
    }
    public void DeliverRecipe(PlateKhitchenObj plateKhitchenObj)
    {
        for (int i = 0; i < waitingRecipeSoList.Count; i++) { 
        
        RecipeSO waitingRecipeSO = waitingRecipeSoList[i];
            if (waitingRecipeSO.chitchenObjSOList.Count == plateKhitchenObj.GetChitchenObjSOList().Count)
            {
                //Has the same number of ingredients
                bool plateContentMatchesRecipe = true;
                foreach (ChitchenObjSO recipeKitchenObjSo in waitingRecipeSO.chitchenObjSOList)
                {
                    //Cyling throught all ingredients in the recipe 
                    bool ingerdientFound = false;
                    foreach (ChitchenObjSO plateKitchenObjSo in plateKhitchenObj.GetChitchenObjSOList())
                    {
                        //Cyling throught all ingredients in the plate
                        if (plateKitchenObjSo == recipeKitchenObjSo) {
                        //Ingerdient matches!
                        ingerdientFound = true;
                            break;
                        }

                    }
                    if (!ingerdientFound) {
                        //This Recipe ingerdient was not found on the plate 
                        plateContentMatchesRecipe = false;
                    }
                }
                if (plateContentMatchesRecipe) {
                    //Player deliveried the correct recipe 
                    Debug.Log("Player deliveried the correct recipe");
                    waitingRecipeSoList.RemoveAt(i);
                    return;
                }
            }
        }

        //No matches found!
        //Player did not deliver a correct recipe 
        Debug.Log("Player did not deliver a correct recipe ");


    }

}
