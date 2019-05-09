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

    public Hero hero;
    public Image timeCounter;

    private float timeValue;
    private float maxTime;
    // Use this for initialization
    private void Awake()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }

    void Start () {
        maxTime = 60;
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
            //dzwiek dzwonka
            hero.LoseGame();
        }
	}
}
