﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : MonoBehaviour, ITakeDamage
{
    public float MaxHelath = 100f;
    public ParticleSystem Boom;
    public float Delai = 0.5f;

    private float _currentHealth = 0f;

	// Use this for initialization
	void Start ()
    {
        _currentHealth = MaxHelath;
	}

    public void TakeDamage(float damage, GameObject instigator)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0f)
        {
            Kill();
        }

    }

    public void Kill()
    {
        Boom.Play();
        Debug.Log("Yatta");
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(Delai);
        Destroy(gameObject);
    }
}
