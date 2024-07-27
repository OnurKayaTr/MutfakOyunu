using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button Playbutton;
    [SerializeField] private Button QuitButton;



    private void Awake()
    {
        Playbutton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameScene);
        });

        QuitButton.onClick.AddListener(() => { 
        Application.Quit();
        });

        Time.timeScale = 1f;
    }
    

    
}
