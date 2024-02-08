using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastChest : MonoBehaviour
{
    public GameObject camera;
    public GameObject magicHandRight;
    public GameObject magicHandLeft;
    public GameObject point;
    public GameObject chest;
    public TextMeshPro text;
    private int x;


    void Start(){
        text.text = "What do you want to do next? Hover on the marked points.";
        magicHandRight = GameObject.Find("RCompr");
        magicHandLeft = GameObject.Find("LCompr");
        point = GameObject.Find("ChestPoint");
        x = 0;
    }

    void Update()
    {
        if(x == 19){
            PointSetTransform(new Vector3(26.167f, -2.736f, 0.469f), new Vector3(12.006f, 0f, 0f), new Vector3(0.06477829f, 0.02270868f, 0.06477829f));
            RHandSetTransform(new Vector3(26.28908f, -3.186902f, 0.6151758f), new Vector3(-5.207f, 84.131f, -9.194f), new Vector3(1.3f, 1.3f, 2f));
            LHandSetTransform(new Vector3(26.233f, -3.095f, 0.517f), new Vector3(31.727f, 98.072f, 7.038f), new Vector3(1.3f, 1.3f, 2f));
            text.text = "What do you want to do next? Hover on the marked points.";
            x = 0;
        }
        else if(x == 3 || x == 9 || x == 15){
            RHandSetTransform(new Vector3(26.0852f, -2.7175f, 0.5152f), new Vector3(-5.207f, 84.131f, -9.194f), new Vector3(1.3f, 1.3f, 2f));
            LHandSetTransform(new Vector3(26.06165f, -2.611085f, 0.418498f), new Vector3(31.727f, 98.072f, 7.038f), new Vector3(1.3f, 1.3f, 2f));
            x++;
        }
        else if(x == 6 || x == 12 || x == 18){
            RHandSetTransform(new Vector3(26.12285f, -2.749765f, 0.5251352f), new Vector3(-21.409f, 86.912f, -9.841f), new Vector3(1.3f, 1.3f, 2f));
            LHandSetTransform(new Vector3(26.06677f, -2.657863f, 0.4269594f), new Vector3(16.067f, 98.812f, 2.417f), new Vector3(1.3f, 1.3f, 2f));  
            x++;
        }
        else if(x>=1){
            x++;
        }
        checkIfRaycastHit();
    }

    bool checkIfRaycastHit(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject == point && Input.GetKey(KeyCode.C))
            {
                text.text = "Doing compressions...";
                print("Hai sa ne miscam:");
                PointSetTransform(new Vector3(100f, -3.1f, 0.392f), new Vector3(12.006f, 0f, 0f), new Vector3(0.06477829f, 0.02270868f, 0.06477829f));
                RHandSetTransform(new Vector3(26.12285f, -2.749765f, 0.5251352f), new Vector3(-21.409f, 86.912f, -9.841f), new Vector3(1.3f, 1.3f, 2f));
                LHandSetTransform(new Vector3(26.06677f, -2.657863f, 0.4269594f), new Vector3(16.067f, 98.812f, 2.417f), new Vector3(1.3f, 1.3f, 2f));
                x = 1;
                return true;
            }
            else if(hit.collider.gameObject == point && x == 0){
                text.text = "Do you want to start doing compressions? Press C.";
            }   
        }
        return false;
    }

    public void RHandSetTransform(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        magicHandRight.transform.position = position;
        magicHandRight.transform.rotation = Quaternion.Euler(rotation);
        magicHandRight.transform.localScale = scale;
    }

    public void LHandSetTransform(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        magicHandLeft.transform.position = position;
        magicHandLeft.transform.rotation = Quaternion.Euler(rotation);
        magicHandLeft.transform.localScale = scale;
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
