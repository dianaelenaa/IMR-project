using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastToNeck : MonoBehaviour
{
    public GameObject camera;
    public GameObject magicHand;
    public GameObject point;
    public TextMeshPro text;
    private int x;


    void Start(){
        text.text = "What do you want to do next? Hover on the marked points.";
        magicHand = GameObject.Find("RHM");
        point = GameObject.Find("PulsePoint");
        x = 0;
    }

    void Update()
    {
        if(x == 1){
            SetTransform(new Vector3(26.002f, -2.8241f, 0.0113f), new Vector3(-2.787f, 84.111f, -0.465f), new Vector3(0.6731647f, 0.7996428f, 1.245512f));
            x++;       
        } else if(x == 2){
            SetTransform(new Vector3(25.9616f, -2.8488f, -0.0223f), new Vector3(-2.787f, 84.111f, -0.465f), new Vector3(0.6731647f, 0.7996428f, 1.245512f));
            x++;       
        }
        else if(x == 8){
            PointSetTransform(new Vector3(26.1649f, -2.8169f, -0.0179f), new Vector3(26.444f, 0f, 0f), new Vector3(0.06477829f, 0.02270868f, 0.06477829f));
            SetTransform(new Vector3(26.0199f, -3.0582f, -0.0145f), new Vector3(-2.787f, 84.111f, -0.465f), new Vector3(0.6731647f, 0.7996428f, 1.245512f));        
            text.text = "What do you want to do next? Hover on the marked points.";
            x = 0;
        }
        else if(x == 3){
            text.text = "No pulse...";
            x++;
        }
        else if(x>=4 && x<=7){
            x++;
        }
        checkIfRaycastHit();
    }

    bool checkIfRaycastHit(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject == point && Input.GetKey(KeyCode.P))
            {
                text.text = "Checking for pulse...";
                print("Hai sa ne miscam:");
                PointSetTransform(new Vector3(100f, -2.974f, -0.096f), new Vector3(26.444f, 0f, 0f), new Vector3(0.06477829f, 0.02270868f, 0.06477829f));
                SetTransform(new Vector3(26.0261f, -2.8247f, -0.0164f), new Vector3(-2.787f, 84.111f, -0.465f), new Vector3(0.6731647f, 0.7996428f, 1.245512f));
                x = 1;
                return true;
            }
            else if(hit.collider.gameObject == point && x == 0){
                text.text = "Do you want to start checking vitals? Press P.";
            }
                
        }
        return false;
    }

    public void SetTransform(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        magicHand.transform.position = position;
        magicHand.transform.rotation = Quaternion.Euler(rotation);
        magicHand.transform.localScale = scale;
    }

    public void PointSetTransform(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        point.transform.position = position;
        point.transform.rotation = Quaternion.Euler(rotation);
        point.transform.localScale = scale;
    }

    public void TextSetTransform(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        text.transform.position = position;
        text.transform.rotation = Quaternion.Euler(rotation);
        text.transform.localScale = scale;
    }
}
