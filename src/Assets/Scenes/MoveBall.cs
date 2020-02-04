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
         Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.z += 10 * Time.deltaTime;
         }

         if (Input.GetKey ("s")) {
             pos.z -= 10 * Time.deltaTime;
         }

         if (Input.GetKey ("d")) {
             pos.x += 10 * Time.deltaTime;
         }

         if (Input.GetKey ("a")) {
             pos.x -= 10 * Time.deltaTime;
         }

         transform.position = pos;
    }
}
