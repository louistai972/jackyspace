﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour, ITakeDamage
{

    protected AudioSource _audioSource;

    public HUDhander UiHandler;

    public GameObject vie1;
    public GameObject vie2;
    public GameObject vie3;
    public float VitesseInit = 10f;
    private float SpeedUp = 1f;

    public SpawnProjectile LeftSpawner;
    public SpawnProjectile RightSpawner;

    public float StraffMaxSpeed = 100f;
    public float StraffTime = 0.1f;

    private Rigidbody _rigidbody;
    private float _smoothXVelocity;

    public static ChangementCamera Instance { get; private set; }

    public GameObject CameraFPS;
    public GameObject CameraTOP;
    public GameObject CameraTPS;
    private int activeCamera = 1;
    public GameObject _currentCamera;

    public float MaxHealth = 3f;
    public float CurrentHealth;

    public Projectile ProjectilePrefab;
    public int Ammo = 3;

    public ParticleSystem Booster1;
    public ParticleSystem Booster2;

    public Text textAmmo;

    public Animator _animator;

    public int Score { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
        _audioSource = GetComponent<AudioSource>();
        _currentCamera = CameraTPS;
        _currentCamera.SetActive(true);

        //Assert.IsNotNull(UiHandler);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        Score = 0;
        Booster1.Play();
        Booster2.Play();

    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Ammo <= 0)
            {
                return;
            }
            else
            {
                _audioSource.pitch = Random.Range(0.8f, 1.25f);
                _audioSource.Play();
                LeftSpawner.SpawnProjectiles();
                RightSpawner.SpawnProjectiles();
                Ammo--;
            }
            
            textAmmo.text = Ammo.ToString();
            textAmmo.color = Color.white;  
        }

        if (Input.GetKeyDown("q"))
        {
            _animator.SetTrigger("Gauche");
        }

        if (Input.GetKeyDown("d"))
        {
            _animator.SetTrigger("Droite");
        }
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = _rigidbody.velocity;

        if (Input.GetKeyDown("z") && SpeedUp == 1f)
        {
            //_currentCamera.transform.position.new Vector3(0f, 0f, -3f);
            SpeedUp = 2f;
        }
        if (Input.GetKeyUp("z") && SpeedUp == 2f)
        {
            SpeedUp = 1f;
        }
        if (Input.GetKeyDown("s") && SpeedUp == 1f)
        {
            SpeedUp = 0.5f;
        }
        if (Input.GetKeyUp("s") && SpeedUp == 0.5f)
        {
            SpeedUp = 1f;
        }

		newVelocity.z = VitesseInit * SpeedUp;
        float targetVelocity = Input.GetAxis("Horizontal") * StraffMaxSpeed;

			newVelocity.x = Mathf.SmoothDamp(newVelocity.x,targetVelocity, ref _smoothXVelocity, StraffTime);


			_rigidbody.velocity = newVelocity;


    }

    void ChangeCamera()
    {
        if (Input.GetKeyDown("c"))
        {
            if (activeCamera == 0)
            {

                CameraTPS.SetActive(false);
                CameraTOP.SetActive(true);
                activeCamera += 1;
                _currentCamera = CameraTPS;
                return;

            }
            if (activeCamera == 1)
            {

                CameraTOP.SetActive(false);
                CameraFPS.SetActive(true);
                activeCamera += 1;
                _currentCamera = CameraTOP;
                return;

            }
            if (activeCamera == 2)
            {

                CameraFPS.SetActive(false);
                CameraTOP.SetActive(true);
                activeCamera = 0;
                _currentCamera = CameraFPS;
                return;

            }
        }
    }

    private void LateUpdate()
	{
		
	}

    public void Kill()
    { 
     
   	ChangementCamera.Instance._currentCamera.transform.parent = null;
    LevelManager.Instance.PlayerDeath();
    /*CameraFPS.SetActive(false);
    CameraTOP.SetActive(false);*/
    }

    public void TakeDamage(float damage, GameObject instigator)
    {
        CurrentHealth -= damage;

        if (CurrentHealth == 2)
        {
            vie3.SetActive(false);

        }

        if (CurrentHealth == 1)
        {
            vie3.SetActive(false);
            vie2.SetActive(false);
        }
        //UiHandler.TakeDamage();
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0f)
        {
            vie3.SetActive(false);
            vie2.SetActive(false);
            vie1.SetActive(false);
            Kill();
        }

    }

    public void AddScore(int scoreValue)
    {
        Score += scoreValue;
    }
}
