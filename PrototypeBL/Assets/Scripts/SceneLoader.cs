using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private bool _reloadCurrentScene;
    [SerializeField] string _sceneName;
    [SerializeField] LoadSceneMode _loadSceneMode;

    public void LoadScene() {
        if( _reloadCurrentScene) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, _loadSceneMode);
        }
        else {
            SceneManager.LoadScene(_sceneName, _loadSceneMode);
        }
    }
}
