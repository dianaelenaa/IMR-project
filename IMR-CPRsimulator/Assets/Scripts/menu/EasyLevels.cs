using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyLevels : MonoBehaviour
{
    public void GoBackToSecondMenu(){
        SceneManager.LoadSceneAsync(1);
    }

    public void GoToPlace(){
        SceneManager.LoadSceneAsync(6);
    }
}
