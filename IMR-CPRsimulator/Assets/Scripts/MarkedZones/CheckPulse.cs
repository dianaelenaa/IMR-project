using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CheckPulse : MonoBehaviour
{
    private HealthStats healthStats;
    private XRSimpleInteractable simpleInteractable;
    public TextMeshPro text;
    public TextMeshProUGUI info;

    void Start()
    {
        healthStats = GetComponentInParent<HealthStats>();
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.onHoverEntered.AddListener(OnHoverEnter);
    }

    private void OnHoverEnter(XRBaseInteractor interactor)
    {
        if(GlobalVars.step != -1){
            healthStats.HeartRate = Random.Range(60, 100);
            // text.text = "Checking pulse: " + healthStats.HeartRate;
            text.text = "The pulse is too weak...";
            if(GlobalVars.step == 0)
            {
                GlobalVars.step = 1;
                GlobalVars.score += 10;

                info.text = "Score: " + GlobalVars.score + " points";
            }
            else if(GlobalVars.step >= 2){
                text.text = "I can feel the pulse!";
            }
        }
    }
}
