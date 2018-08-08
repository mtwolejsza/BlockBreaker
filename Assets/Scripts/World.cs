using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    private static float unitHeight;
    private static float unitWidth;
    private static Vector3 dimensions;

    private static Vector2 lastInput;

    // Use this for initialization
    void Start ()
    {
        //inchHeight = Screen.height / Screen.dpi;
        //inchWidth = Screen.width / Screen.dpi;
        //meterHeight = Screen.height / Screen.dpi * .0254f;
        //meterWidth = Screen.width / Screen.dpi * .0254f;
        unitHeight = Screen.height / Screen.dpi * .0254f;// / 9.8f;
        unitWidth = Screen.width / Screen.dpi * .0254f;// / 9.8f;
        /*Debug.Log(Screen.height);
        Debug.Log(Screen.width);
        Debug.Log(Screen.dpi);
        Debug.Log(unitHeight);
        Debug.Log(unitWidth);*/

        Vector3 leftBottomMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 rightTopMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        dimensions = rightTopMost - leftBottomMost;
        //Debug.Log(dimensions);
    }

    // Update is called once per frame
    void Update () {
        
    }

    public static Vector2 deltaVelocity()
    {
        //Vector3 adjustedMotion = Input.acceleration * ((Input.acceleration.magnitude - 1) / (.05f * Input.acceleration.magnitude)) * Time.deltaTime;
        Vector3 adjustedMotion = (Input.acceleration + Vector3.forward) * Time.deltaTime;
        Debug.Log(adjustedMotion);
        return new Vector2(adjustedMotion.x / unitWidth, adjustedMotion.y / unitHeight);
    }

    public static Vector2 rotateVelocity(Vector2 vel)
    {
        Vector2 input = new Vector2(Input.acceleration.x, Input.acceleration.y);
        float angleDelta = FindAngle(lastInput) - FindAngle(input);
        /*Debug.Log(angleDelta);
        Debug.Log(Vector2.Angle(Vector2.right, vel));*/
        float neededAngle = FindAngle(vel) - angleDelta;
        //Debug.Log(neededAngle);


        lastInput = input;
        return new Vector2(Mathf.Cos(neededAngle * Mathf.PI / 180), Mathf.Sin(neededAngle * Mathf.PI / 180)) * vel.magnitude;
    }

    private static float FindAngle(Vector2 vec)
    {
        float angle = Vector2.Angle(vec, Vector2.right);
        return angle * (vec.y > 0 ? 1 : -1);
    }
}
