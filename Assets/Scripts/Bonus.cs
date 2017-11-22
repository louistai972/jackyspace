using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class Bonus : MonoBehaviour {


    protected Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();
        if(player != null)
        {
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
