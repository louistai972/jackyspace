using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance { get; private set; }

    public Player Player;
	public TimeSpan RunningTime { get {return DateTime.UtcNow - _startedTime; }}

	private DateTime _startedTime;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_startedTime = DateTime.UtcNow;
	}

    public void PlayerDeath()

    {
        ChangementCamera.Instance._currentCamera.transform.parent = null;
        Destroy(Player.gameObject);
    }
}
