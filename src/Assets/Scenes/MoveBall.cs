using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey("w")) {
            rb.AddForce(new Vector3(0, 0, 1), ForceMode.Impulse);
        }

        if (Input.GetKey("a")) {
            rb.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
        }

        if (Input.GetKey("s")) {
            rb.AddForce(new Vector3(0, 0, -1), ForceMode.Impulse);
        }

        if (Input.GetKey("d")) {
            rb.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
    }
}
