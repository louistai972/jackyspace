﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMalus : Bonus , ITakeDamage
{
    public float Damage = 10f;
    public float MaxHelath = 100f;
    public ParticleSystem Boom;
    public float Delai = 0.1f;

    private float _currentHealth = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponentInParent<Player>();
        if(player)
        {
            ApplyBonus(player);
            Destroy(this.gameObject);
        }
    }

    public override void ApplyBonus(Player player)
    {
        Debug.Log("Mine");
        player.TakeDamage(Damage, gameObject);
       // _animator.SetTrigger("PickUp");
    }


    // Use this for initialization
    void Start()
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
