using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public int lives;
    public Vector2 startVelocity;
    private bool hasStarted = false;
    private LevelManager levelManager;
    private Rigidbody2D rigi;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            resetBall();

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;

                rigi.velocity = new Vector2(2.5f, 2.5f);
                rigi.WakeUp();
            }

        }
        else
        {
            rigi.velocity = World.rotateVelocity(rigi.velocity);
            Debug.Log(rigi.velocity);
        }
    }

    private void resetBall()
    {
        transform.position = new Vector3(8, 6, 0);
    }

    public void OnLoseEvent()
    {
        lives--;
        hasStarted = false;
        resetBall();
        if (lives <= 0)
        {
            levelManager.LoadLevel("Lose");
        }
    }
}
