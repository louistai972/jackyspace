using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : MonoBehaviour, ITakeDamage
{
    public float MaxHelath = 100f;
    public GameObject Boom;
    public Explosion ExplosionScript;

    private float _currentHealth = 0f;

	// Use this for initialization
	void Start ()
    {
        _currentHealth = MaxHelath;
	}

    public void Explosion()
    {
        //Boom.GetComponent<Explosions>();
    }

    public void TakeDamage(float damage, GameObject instigator)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0f)
        {
            Explosion();
            Kill();
        }

    }

    public void Kill()
    {
        //Destroy(this.gameObject);
        ExplosionScript.Explosions();
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
