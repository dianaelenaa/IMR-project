using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckBreathing : MonoBehaviour
{

    XRSimpleInteractable simpleInteractable;
    private bool IsBreathing;

    // Start is called before the first frame update
    void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.onHoverEntered.AddListener(OnHoverEnter);
        IsBreathing = GetComponentInParent<HealthStats>().IsBreathing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHoverEnter(XRBaseInteractor interactor)
    {
        if (!IsBreathing)
        {
            Debug.Log("Not breathing");
        }
        else if (IsBreathing)
        {
            Debug.Log("Breathing");
        }
    }
}
