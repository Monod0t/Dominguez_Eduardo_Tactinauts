using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad instance = null;

    private void Awake()
    {
        // Check if another instance of this script already exists in the scene
        if (instance != null && instance != this)
        {
            // Destroy this instance to maintain only one instance of the script
            Destroy(this.gameObject);
            return;
        }

        // Set this instance as the main instance of the script
        instance = this;

        // Don't destroy this game object when a new scene is loaded
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Do any setup you need for the new scene here
    }
}
