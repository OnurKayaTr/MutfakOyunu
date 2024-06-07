using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{


    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObj;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter) { Show(); }
        else { Hide(); }
    }
    private void Show()
    {
        visualGameObj.SetActive(true);
    }
    private void Hide()
    {
        visualGameObj.SetActive(false);
    }
}
