using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurninRecipeSO : ScriptableObject
{
    public ChitchenObjSO input;
    public ChitchenObjSO output;
    public float BurningTimerMax;
}
