using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public ChitchenObjSO input;
    public ChitchenObjSO output;
    public float FryingTimerMax;

}
