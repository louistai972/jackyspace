using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMalus : Bonus , ITakeDamage
{
    public float Damage = 10f;
    public float MaxHelath = 100f;

    private float _currentHealth = 0f;

    public override void ApplyBonus(Player player)
    {
        player.TakeDamage(Damage, gameObject);
        Destroy(gameObject);
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
        Destroy(this.gameObject);
    }
}
