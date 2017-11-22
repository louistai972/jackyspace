using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : MonoBehaviour, ITakeDamage
{
    public float MaxHelath = 100f;
    public ParticleSystem Boom;
    private bool death= false;

    private float _currentHealth = 0f;

	// Use this for initialization
	void Start ()
    {
        Boom.Play();
        _currentHealth = MaxHelath;
	}

    void Explosions()
    {
        Boom.Play();
    }


    public void TakeDamage(float damage, GameObject instigator)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0f)
        {
            Explosions();
            Kill();
        }

    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
