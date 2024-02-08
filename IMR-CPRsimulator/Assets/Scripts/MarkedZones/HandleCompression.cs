using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class HandleCompression : MonoBehaviour
{

    private XRSimpleInteractable simpleInteractable;

    private bool isHoveringWithRightHand = false;
    private bool isHoveringWithLeftHand = false;
    private double necessaryCompressions;
    public TextMeshPro text;
    public TextMeshProUGUI info;

    void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();

        simpleInteractable.hoverEntered.AddListener(OnHover);
        simpleInteractable.hoverExited.AddListener(OnHoverExit);
        simpleInteractable.selectEntered.AddListener(OnSelect);

        necessaryCompressions = GetComponentInParent<HealthStats>().NecessaryCompressions;
    }


    void OnHover(HoverEnterEventArgs args)
    {
        if (args.interactor.gameObject.CompareTag("LeftHand"))
        {
            isHoveringWithLeftHand = true;
        }
        else if (args.interactor.gameObject.CompareTag("RightHand"))
        {
            isHoveringWithRightHand = true;
        }
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        if (args.interactor.gameObject.CompareTag("LeftHand"))
        {
            isHoveringWithLeftHand = false;
        }
        else if (args.interactor.gameObject.CompareTag("RightHand"))
        {
            isHoveringWithRightHand = false;
        }
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        if(GlobalVars.step != -1){
            if(GlobalVars.step == 2){
                if (IsGrabbedWithBothHandsNow())
                {
                    necessaryCompressions -= 1;
                    text.text = "You are doing compressions. " + necessaryCompressions + " remaining.";
                    if(necessaryCompressions <= 0){
                        GlobalVars.score += 10;
                        if(GlobalVars.score >= 30)
                        {
                            text.text = "Well done! This man is alive thanks to you!";
                            info.text = "Excellent work! Final score: " + GlobalVars.score + " points";
                        }
                        else{
                            System.DateTime oraCurenta = System.DateTime.Now;
                            text.text = "Time of death: " + oraCurenta.ToString("HH:mm");
                            info.text = "All things come to an end... Final score: " + GlobalVars.score + " points";
                        }
                        GlobalVars.step = -1;
                    }
                }
            }
        }
        else {
            text.text = "You can't do this yet.";
            GlobalVars.score -= 10;
            info.text = " You've missed some steps => penalty: 10 points\nCurrent score: " + GlobalVars.score + " points";
        }
    }

    bool IsGrabbedWithBothHandsNow()
    {
       return isHoveringWithLeftHand && isHoveringWithRightHand;
    }
}
