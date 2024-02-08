using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class UnblockAirways : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private HealthStats healthStats;
    public TextMeshPro text;
    public TextMeshProUGUI info;

    void Start()
    {
       grabInteractable = GetComponent<XRGrabInteractable>();
       grabInteractable.onSelectEntered.AddListener(OnSelectEnter);
       grabInteractable.onHoverEntered.AddListener(OnHoverEnter);
       healthStats = GetComponentInParent<HealthStats>();
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
        if(GlobalVars.step != -1){
            if(!healthStats.IsAirwayClear)
            { 
                if(GlobalVars.step == 1)
                {
                    info.text = "In this step, you assess whether the patient is breathing or not.";
                    info.text += "If the patient is not breathing, the next step is to clear any obstructions from the airway to ensure that oxygen can flow freely into the lungs.";
                    info.text += "Gently tilt the head back and lift the chin to open the airway.";
                    info.text += "Check for any visible obstructions, such as foreign objects or vomit, and remove them if possible.";
                    info.text += "This step helps ensure that the patient's airway is clear, allowing for effective ventilation during CPR.";
                    info.text += "Press G to unblock his airways!";
                    text.text = "He is not breathing...";
                }
                else if(GlobalVars.step == 0)
                {
                    info.text = "Score: " + GlobalVars.score + " points\n";
                    info.text += "Try to check the pulse first.";
                }
            }
            else if(healthStats.IsAirwayClear)
            { 
                text.text += "Airway is clear!";
                if(GlobalVars.step == 1){
                    GlobalVars.step = 2;
                    GlobalVars.score += 10;
                    info.text += "\nScore: " + GlobalVars.score + " points";
                }
            }
        }
    }
}
