using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardLevels : MonoBehaviour
{
    public void GoBackToSecondMenu(){
        SceneManager.LoadSceneAsync(1);
    }
}
