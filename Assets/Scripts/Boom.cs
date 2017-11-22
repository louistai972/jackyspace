using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public ParticleSystem Explosion;


    public void Explosions()
    {
        Explosion.Play();
    }


}
