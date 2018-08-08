using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //private LevelManager levelManager;
    private Ball ball;

    void Start()
    {
        //levelManager = GameObject.FindObjectOfType<LevelManager>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //levelManager.LoadLevel("Lose");
        ball.OnLoseEvent();
    }
    
}
