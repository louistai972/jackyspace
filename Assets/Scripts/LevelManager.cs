using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance { get; private set; }

    public Player Player;
	public TimeSpan RunningTime { get {return DateTime.UtcNow - _startedTime; }}
    public Text timerText;
    public Text stateText;
    public Text endText;
    public GameObject endLayout;

    private DateTime _startedTime;
    private float _startTime;
    private float _maxTime;
    
    private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_startedTime = DateTime.UtcNow;
        _startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - _startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("00");
        timerText.text = minutes + " : " + seconds;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            stateText.text = "VICTOIRE";
            stateText.color = Color.green;
            endText.text = timerText.text;
            endText.color = Color.white;
        }
        Debug.Log("Le enter");
        endLayout.SetActive(true);
    }

    public void PlayerDeath()
    {
        Debug.Log("Mort");
        ChangementCamera.Instance._currentCamera.transform.parent = null;
        Destroy(Player.gameObject);
        Time.timeScale = 0f;
        stateText.text = "DEFAITE";
        stateText.color = Color.red;
        endText.text = timerText.text;
        endText.color = Color.white;
        Debug.Log(" Le death");
        endLayout.SetActive(true);
    }
}
