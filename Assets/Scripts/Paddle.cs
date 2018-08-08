using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (autoPlay)
        {
            MoveWithBall();
        }
        else
        {
            MoveWithMouse();
        }
        
	}

    void MoveWithBall()
    {
        transform.position = LimitPaddleToSpace(ball.transform.position.x);
    }

    void MoveWithMouse()
    {
        Vector3 mousePosInBlocks = Input.mousePosition / Screen.width * 16;
        transform.position = LimitPaddleToSpace(mousePosInBlocks.x);
    }

    Vector3 LimitPaddleToSpace(float x)
    {
        return new Vector3(Mathf.Clamp(x, .5f, 15.5f), transform.position.y, 0f);
    }
}
