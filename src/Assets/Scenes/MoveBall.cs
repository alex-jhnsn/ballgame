﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Rigidbody rb;
    GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coinPrefab = Resources.Load("Coin") as GameObject;
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

    private void OnTriggerEnter(Collider c) {
        
        if(c.gameObject.name == "Coin") {
            Destroy(c.gameObject);
        }

        if(c.gameObject.name.Contains("Wall")) {
            int x = Random.Range(10, -10);
            float y = 6.4F;
            int z = Random.Range(10, -10);
            Instantiate(Resources.Load("Coin"), new Vector3(x, y, z), new Quaternion());
        }
    }
}
