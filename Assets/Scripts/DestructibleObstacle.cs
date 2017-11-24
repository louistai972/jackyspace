using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestructibleObstacle : MonoBehaviour, ITakeDamage
{
    public float MaxHelath = 100f;
    public ParticleSystem Boom;
    public float Delai = 0.5f;

    private float _currentHealth = 0f;

    protected AudioSource _audioSource;

	// Use this for initialization
	void Start ()
    {
        _currentHealth = MaxHelath;
	}

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
        
        _audioSource.pitch = Random.Range(0.8f, 1.25f);
        _audioSource.Play();
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(Delai);
        Destroy(gameObject);
    }
}
