using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {


    public float TimeValue
    {
        get
        {
            return timeValue;
        }
        set
        {
            timeValue = value;
            timeCounter.fillAmount = timeValue / maxTime;
            timeCounter.color = new Color(1 - timeValue / maxTime, timeValue / maxTime, 0);
        }
    }
    public GameObject[] bells;
    public Hero hero;
    public Image timeCounter;
    public AudioClip bell;
    public AudioClip peopleTalking;
    private float timeValue;
    private float maxTime;
    private bool playedOnce = false;
    // Use this for initialization
    private void Awake()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }

    void Start () {
        GetComponent<AudioSource>().Play();
        maxTime = 45;
        TimeValue = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (TimeValue > 0)
        {
            TimeValue -= Time.deltaTime;
        }
        else
        {
            if (!playedOnce)
            {
                playedOnce = true;
                GetComponent<AudioSource>().PlayOneShot(bell);
                foreach(GameObject bell in bells)
                {
                    bell.GetComponent<Animator>().SetBool("BellRing", true);
                }
                //dzwiek dzwonka
                hero.LoseGame();
            }
        }
	}
}
