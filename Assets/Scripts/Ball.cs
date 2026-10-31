using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public int lives;
    public Vector2 startVelocity;
    //private bool hasStarted = false;
    private LevelManager levelManager;
    private PauseMenu pauseMenu;
    private Rigidbody2D rigi;

	// Use this for initialization
	void Start () {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        rigi = gameObject.GetComponent<Rigidbody2D>();
        rigi.velocity = new Vector2(2.5f, 2.5f);
        pauseMenu.Pause();
        resetBall();
    }
	
	// Update is called once per frame
	void Update () {
        //if (!World.hasStarted)
        //{
            

            //if (Input.GetMouseButtonDown(0))
            //{
                //hasStarted = true;

                //rigi.velocity = new Vector2(2.5f, 2.5f);
                //rigi.WakeUp();
            //}

        //}
        //else
        //{
            if (World.hasStarted && Input.GetMouseButtonDown(0))
            {
                pauseMenu.Pause();
                World.hasStarted = false;
            }
            rigi.velocity = World.rotateVelocity(rigi.velocity);
            //Debug.Log(rigi.velocity);
        //}
    }

    private void resetBall()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void OnLoseEvent()
    {
        World.lives--;
        World.hasStarted = false;
        resetBall();
        if (World.lives <= 0)
        {
            levelManager.LoadLevel("Lose");
        }
        else
        {
            pauseMenu.Pause();
        }
    }

}
