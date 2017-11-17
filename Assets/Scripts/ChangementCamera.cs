using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementCamera : MonoBehaviour {

    public static ChangementCamera Instance { get; private set; }

    public GameObject CameraFPS;
	public GameObject CameraTOP;
	public GameObject CameraTPS;
	private int activeCamera = 0;
    public GameObject _currentCamera;


	// Use this for initialization
	void Start () 
	{
		
	}

    private void Awake()
    {
        Instance = this;
        _currentCamera = CameraTOP;
    }

    void ChangeCamera()
	{
		if (Input.GetKeyDown("c"))
		{
			if (activeCamera == 0)
			{

				CameraTOP.SetActive(false);
				CameraTPS.SetActive(true);
				activeCamera += 1;
                _currentCamera = CameraTPS;
				return;

			}
			if (activeCamera == 1)
			{

				CameraTPS.SetActive(false);
				CameraFPS.SetActive(true);
				activeCamera += 1;
                _currentCamera = CameraFPS;
                return;

			}
			if (activeCamera == 2)
			{

				CameraFPS.SetActive(false);
				CameraTOP.SetActive(true);
				activeCamera = 0;
                _currentCamera = CameraTOP;
                return;

			}	
		}
	}
	// Update is called once per frame
	void Update () 
	{
		ChangeCamera();
	}
}
