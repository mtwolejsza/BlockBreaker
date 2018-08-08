using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void DetectWin()
    {
        //Brick[] last = GameObject.FindObjectsOfType<Brick>();
        //Debug.Log(last.Length);
        //if (last.Length == 0)
        if (Brick.breakableBricks <= 0)
        {
            LoadNextLevel();
        }
    }

	public void LoadLevel (string level)
    {
        SceneManager.LoadScene(level);
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit ()
    {
        Application.Quit();
    }

}
