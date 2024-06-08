using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhicthenObj : MonoBehaviour
{
    [SerializeField] private ChitchenObjSO kitchenObjSO;

    public ChitchenObjSO GetChitchenObjSO() { return kitchenObjSO; }
}
