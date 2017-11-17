using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponentInParent<Player>();
        if(player)
        {
            player.Kill();
        }
    }
}
