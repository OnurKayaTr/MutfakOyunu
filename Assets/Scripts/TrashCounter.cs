using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyObjTrashed;

    new public static void ResetStaticData()
    {
        OnAnyObjTrashed = null;

    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObj()) {
        player.GetKhicthenObj().DestroySelf();


            OnAnyObjTrashed?.Invoke(this, EventArgs.Empty);
        
        }

    }
}
