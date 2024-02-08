using UnityEngine;
using Cinemachine;

public class HandController : MonoBehaviour
{
    public Transform leftHand; // Referința către transformarea mâinii stângi
    public Transform rightHand; // Referința către transformarea mâinii drepte
    public Transform neckPoint; // Referința către punctul de pe gâtul manechinului pentru luarea pulsului
    public CinemachineVirtualCamera activeCam;

    bool isPointingAtNeck = false; // Variabilă pentru marcarea orientării către gât
    public LayerMask raycastLayer;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, raycastLayer))
        {
            Debug.Log("Am lovit!!!");
            if (hit.collider.gameObject.CompareTag("Sphere") && Input.GetKeyDown(KeyCode.P))
            {
                isPointingAtNeck = true; // Setează variabila când raycast-ul este către gât și se apasă tasta P
            }
        }

        if (isPointingAtNeck && Input.GetKeyDown(KeyCode.P))
        {
            activeCam.Priority = 1;
            // Pozitionează mâinile pe gâtul manechinului (neckPoint)
            leftHand.position = neckPoint.position; // Ajustează poziția mâinii stângi
            leftHand.rotation = neckPoint.rotation; // Ajustează rotația mâinii stângi

            rightHand.position = neckPoint.position; // Ajustează poziția mâinii drepte
            rightHand.rotation = neckPoint.rotation; // Ajustează rotația mâinii drepte
        }
    }
}
