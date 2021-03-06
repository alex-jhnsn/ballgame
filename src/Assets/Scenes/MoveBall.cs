﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MoveBall : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    public int CoinSpawn;

    int score;
    Rigidbody rb;
    GameObject coinPrefab;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        coinPrefab = Resources.Load("Coin") as GameObject;
        score = 0;
        setScoreText();
        spawnCoins();
    }

    // Update is called once per frame
    void Update() { 
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider c) {
        if(c.gameObject.name == "Coin" || c.gameObject.name == "Coin(Clone)") {
            Destroy(c.gameObject);
            score = score + 1;
            setScoreText();
        }

        if(c.gameObject.name.Contains("Wall")) {
            destroyCoins();
            spawnCoins();
        }
    }

    void destroyCoins() {
        var coins = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Coin").ToList();
        Debug.Log(coins.Count);
        foreach (var coin in coins)
        {
            Destroy(coin);
        }
    }

    void spawnCoins() {
        for (int i = 0; i < CoinSpawn; i++)
        {
            spawnCoin();
        }
    }

    void spawnCoin() {
        float x = Random.Range(-7.44F, 11);
        float y = 6.4F;
        float z = Random.Range(-3.29F, -20.96F);
        Quaternion rotation = Quaternion.Euler(0, 90, 90);
        Object go = Instantiate(Resources.Load("Coin"), new Vector3(x, y, z), rotation);
        go.name = "Coin";
    }

    void setScoreText() {
        this.ScoreText.text = "Score: " + score.ToString();
    }
}
