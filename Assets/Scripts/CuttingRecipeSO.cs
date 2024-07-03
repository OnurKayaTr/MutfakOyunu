using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    public ChitchenObjSO input;
    public ChitchenObjSO output;
    public int cuttingProgressMax;

}
