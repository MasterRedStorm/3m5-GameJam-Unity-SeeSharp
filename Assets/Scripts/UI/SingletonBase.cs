using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonBase<TInstance> : MonoBehaviour where TInstance : Component
{
    public static TInstance Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this as TInstance;
        DontDestroyOnLoad(gameObject);
    }
}