using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckPulse : MonoBehaviour
{
    private HealthStats healthStats;
    private XRSimpleInteractable simpleInteractable;
    // Start is called before the first frame update
    void Start()
    {
        healthStats = GetComponentInParent<HealthStats>();
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.onHoverEntered.AddListener(OnHoverEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHoverEnter(XRBaseInteractor interactor)
    {
        Debug.Log("Checking pulse: " + healthStats.HeartRate);
    }
}
