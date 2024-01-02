using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleCompression : MonoBehaviour
{

    private XRSimpleInteractable simpleInteractable;

    private bool isHoveringWithRightHand = false;
    private bool isHoveringWithLeftHand = false;
    private double necessaryCompressions;

    // Start is called before the first frame update
    void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();

        simpleInteractable.hoverEntered.AddListener(OnHover);
        simpleInteractable.hoverExited.AddListener(OnHoverExit);
        simpleInteractable.selectEntered.AddListener(OnSelect);

        necessaryCompressions = GetComponentInParent<HealthStats>().NecessaryCompressions;
    }

    void Update()
    { 
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
        if (IsGrabbedWithBothHandsNow())
        {
            necessaryCompressions -= 0.5;
        }
    }

    bool IsGrabbedWithBothHandsNow()
    {
        return isHoveringWithLeftHand && isHoveringWithRightHand;
    }
}
