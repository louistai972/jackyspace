using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMalus : Bonus
{
    public float Damage = 10f;

    public override void ApplyBonus(Player player)
    {
        player.TakeDamage(Damage, gameObject);
        Destroy(gameObject);
    }

}
