using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnblockAirways : MonoBehaviour
{
    // Start is called before the first frame update

    private XRGrabInteractable grabInteractable;
    private HealthStats healthStats;
    void Start()
    {
       grabInteractable = GetComponent<XRGrabInteractable>();
       grabInteractable.onSelectEntered.AddListener(OnSelectEnter);
       grabInteractable.onHoverEntered.AddListener(OnHoverEnter);
       healthStats = GetComponentInParent<HealthStats>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnSelectEnter(XRBaseInteractor interactor)
    {
        
        if(!healthStats.IsAirwayClear)
        {
            healthStats.IsAirwayClear = true;
            GetComponent<Rigidbody>().useGravity = true;
            GameObject.Find("BreathingZone").GetComponent<SphereCollider>().enabled = true;
        }
    }

    void OnHoverEnter(XRBaseInteractor interactor)
    {
        if(!healthStats.IsAirwayClear)
        {
            Debug.Log("Airway is blocked");
        }
        else if(healthStats.IsAirwayClear)
        {
            Debug.Log("Airway is clear");
        }
    }
}
