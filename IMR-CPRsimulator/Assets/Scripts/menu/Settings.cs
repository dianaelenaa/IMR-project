using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public TMP_Text room;
    public TMP_Text park;
    static public TMP_Text placeSelected;
    public TMP_Text beegees;
    public TMP_Text queen;
    public TMP_Text beyonce;
    static public TMP_Text songSelected;

    void Start()
    {
        if(!placeSelected) placeSelected = room;
        if(!songSelected) songSelected = beegees;
        placeSelected.color = Color.red;   
        songSelected.color = Color.red;
        Debug.Log("In start.");
    }
    
    public void selectRoom(){
        placeSelected = room;
        room.color = Color.red;
        park.color = Color.black;
        Debug.Log("In select room.");
    }

    public void selectPark(){
        placeSelected = park;
        park.color = Color.red;
        room.color = Color.black;
        Debug.Log("In select park.");
    }

    public void selectBeeGees(){
        songSelected = beegees;
        songSelected.color = Color.red;
        queen.color = Color.black;
        beyonce.color = Color.black;
        Debug.Log("In select beegees.");
    }

    public void selectQueen(){
        songSelected = queen;
        songSelected.color = Color.red;
        beegees.color = Color.black;
        beyonce.color = Color.black;
        Debug.Log("In select queen.");
    }

    public void selectBeyonce(){
        songSelected = beyonce;
        songSelected.color = Color.red;
        queen.color = Color.black;
        beegees.color = Color.black;
        Debug.Log("In select beyonce.");
    }

    public void GoBackToSecondMenu(){
        SceneManager.LoadSceneAsync(1);
        Debug.Log("In go back to menu.");
    }
}
