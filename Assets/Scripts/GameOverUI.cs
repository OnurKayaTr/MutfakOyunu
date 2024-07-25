using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeisDelvrdText;
    private void Start()
    {
        GameManager.Instance.OnstateChanged += Gamemanager_OnstateChanged;
        Hide();
    }
  
    
    private void Gamemanager_OnstateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();
            recipeisDelvrdText.text = DeliveryManager.Instance.GetsuccessfulRecipesAmount().ToString();

        }
        else
        {
            Hide();

        }

    }

    private void Show() { gameObject.SetActive(true); }
    private void Hide() { gameObject.SetActive(false); }


}
