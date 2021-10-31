using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler: SingletonBase<SceneHandler>
{
    private void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(sceneName, mode);
    }

    public void LoadStartScene() => LoadScene(SceneNames.StartScene);

    public void LoadGameScene() => LoadScene(SceneNames.GameScene);
}
