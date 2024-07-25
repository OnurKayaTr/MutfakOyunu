using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Search;


public class GameStartCoundownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coundownText;

    private void Start()
    {
        GameManager.Instance.OnstateChanged += Gamemanager_OnstateChanged;
        Hide();
    }
    private void Update()
    {
        coundownText.text = GameManager.Instance.GetCountDownToStartTimer().ToString("#");
    }
    private void Gamemanager_OnstateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountDownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        
        }

    }

    private void Show(){ gameObject.SetActive(true); }
    private void Hide() { gameObject.SetActive(false); }

}
