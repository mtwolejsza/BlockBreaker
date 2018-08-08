using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private int maxHits;
    private int timesHit = 0;
    private LevelManager lm;
    public static int breakableBricks;

    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;

    void Awake()
    {
        breakableBricks = 0;
        Debug.Log(breakableBricks);
    }

	// Use this for initialization
	void Start () {
        breakableBricks++;
        Debug.Log(breakableBricks);
        maxHits = hitSprites.Length + 1;
        timesHit = 0;
        lm = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHits();
    }

    private void HandleHits()
    {
        timesHit++;
        AudioSource.PlayClipAtPoint(crack, transform.position, .8f);
        if (timesHit >= maxHits)
        {
            breakableBricks--;
            //Debug.Log(breakableBricks);
            GameObject s = GameObject.Instantiate(smoke, transform.position, Quaternion.identity);
            ParticleSystem.MainModule psm = s.GetComponent<ParticleSystem>().main;
            psm.startColor = GetComponent<SpriteRenderer>().color;
            lm.DetectWin();
            Destroy(gameObject);
        }
        else if (hitSprites[timesHit - 1])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        } else
        {
            Debug.LogError("Missing Brick Sprite");
        }
    }

}
