using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBonus : Bonus
{
    public int Score = 50;

    public override void ApplyBonus(Player player)
    {
        player.AddScore(Score);
        _animator.SetTrigger("PickUp");
    }
}
