using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Cinemachine;
using TMPro;

public class CheckBreathing : MonoBehaviour
{

    XRSimpleInteractable simpleInteractable;
    private bool IsBreathing;
    public TextMeshPro text;
    public TextMeshProUGUI info;


    void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.onHoverEntered.AddListener(OnHoverEnter);
        IsBreathing = GetComponentInParent<HealthStats>().IsBreathing;
    }

    private void OnHoverEnter(XRBaseInteractor interactor)
    {
        if(GlobalVars.step != -1){
            if (!IsBreathing)
            {
                text.text = "Not breathing...";
            }
            else if (IsBreathing)
            {
                text.text = "Breathing!";
                GlobalVars.score += 10;
                info.text = "Score: " + GlobalVars.score + " points";
                if(GlobalVars.step == 1)
                    GlobalVars.step = 2;
            }
        }
    }
}
