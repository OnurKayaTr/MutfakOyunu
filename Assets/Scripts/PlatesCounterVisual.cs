using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterToppoint;
    [SerializeField] private Transform plateViusalPrefab;


    private List<GameObject> plateViusalGameOBJList;

    private void Awake()
    {
        plateViusalGameOBJList = new List<GameObject>();
    }
    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObj = plateViusalGameOBJList[plateViusalGameOBJList.Count - 1];
        plateViusalGameOBJList.Remove(plateGameObj);
        Destroy(plateGameObj);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateViusalPrefab,counterToppoint);
        float plateOffSetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffSetY * plateViusalGameOBJList.Count, 0);
        plateViusalGameOBJList.Add(plateVisualTransform.gameObject);
    }
}
