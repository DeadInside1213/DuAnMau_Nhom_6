using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHeath {  get; private set; }
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        currentHeath = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHeath = Mathf.Clamp(currentHeath - _damage, 0, startingHealth);
        if(currentHeath > 0 )
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }

        }
    }
    public void addHealth(float _value)
    {
        currentHeath = Mathf.Clamp(currentHeath + _value, 0, startingHealth);

    }
}
