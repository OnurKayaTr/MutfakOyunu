using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    [SerializeField] private ChitchenObjSO plateKitchenObjSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;

        if (spawnPlateTimer > spawnPlateTimerMax) {
            KhicthenObj.SpawnKitchenObj(plateKitchenObjSO, this);
            spawnPlateTimer = 0f;


            if (platesSpawnedAmount < platesSpawnedAmountMax) {
                platesSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
            
        }
        
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObj())
        {
            if (platesSpawnedAmount > 0) 
            {
                platesSpawnedAmount--;

                KhicthenObj.SpawnKitchenObj(plateKitchenObjSO,player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    
}
