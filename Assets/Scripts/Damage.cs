using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Bonus, ITakeDamage
{
    public float Damages = 10f;
    public float MaxHelath = 100f;

    private float _currentHealth = 0f;

    public override void ApplyBonus(Player player)
    {
        player.TakeDamage(Damages, gameObject);
        Destroy(gameObject);
    }


    // Use this for initialization
    void Start()
    {
        _currentHealth = MaxHelath;
    }

    public void TakeDamage(float damages, GameObject instigator)
    {
        _currentHealth -= damages;
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
