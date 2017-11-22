using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBonus : Bonus
{
    public int Amount = 1;


    public override void ApplyBonus (Player player)
    {
        player.Ammo += Amount;
        _animator.SetTrigger("PickUp");
    }

   
}
