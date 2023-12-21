using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCompression : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("LeftHand"))
        {
            Debug.Log("Compression with left hand");
        }

        if (collision.gameObject.CompareTag("RightHand"))
        {
            Debug.Log("Compression with right hand");
        }
    }
}
