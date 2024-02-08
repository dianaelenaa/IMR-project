using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondMenu : MonoBehaviour
{
    public void StartEasyMode(){
        SceneManager.LoadSceneAsync(2);
    }
    public void StartHardMode(){
        SceneManager.LoadSceneAsync(3);
    }
    public void StartChallenge(){
        SceneManager.LoadSceneAsync(4);
    }
    public void EnterSettings(){
        SceneManager.LoadSceneAsync(5);
    }
    public void GoBackToMainMenu(){
        SceneManager.LoadSceneAsync(0);
    }
}
