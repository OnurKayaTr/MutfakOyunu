using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene
    }

    private static Scene targetScence;


    public static void Load(Scene targetScene)
    {
        Loader.targetScence = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
        
    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScence.ToString());
    }
}
