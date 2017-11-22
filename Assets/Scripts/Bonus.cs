using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Bonus : MonoBehaviour
{


    protected Animator _animator;
    protected AudioSource _audioSource;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();
        if (player != null)
        {
            _audioSource.pitch = Random.Range(0.8f, 1.25f);
            _audioSource.Play();
            ApplyBonus(player);
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public virtual void ApplyBonus(Player player)
    {

    }

}
