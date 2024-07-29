using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;


    private void Awake()
    {
        resumeButton.onClick.AddListener(() => {
        
        GameManager.Instance.PauseGame();
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.onClick.AddListener(() => {
            OptionsUI.Instance.Show();
        });

    }
    private void Start()
    {
        GameManager.Instance.GamePaused += GameManager_GamePaused;
        GameManager.Instance.UnGamePaused += GameManager_UnGamePaused;
        Hide();
    }

    private void GameManager_UnGamePaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_GamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
