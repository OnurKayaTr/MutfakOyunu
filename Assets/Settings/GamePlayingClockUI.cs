using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image timmerImage;

    private void Update()
    {
        timmerImage.fillAmount = GameManager.Instance.GetPlayerTimmerNormalize();
    }
}
