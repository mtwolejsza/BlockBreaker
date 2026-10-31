using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Text livesText;
    
    public void Pause()
    {
        Time.timeScale = 0f;
        Vector3 pos = transform.position;
        pos.x = Screen.width / 2f;
        transform.position = pos;
        livesText.text = string.Format("Lives: {0}", World.lives.ToString());
    }

    public void Unpause()
    {
        //TODO this is a hack.  change it
        Vector3 pos = transform.position;
        pos.x = -5000f;
        transform.position = pos;
        Time.timeScale = 1f;
        World.hasStarted = true;
    }

}
