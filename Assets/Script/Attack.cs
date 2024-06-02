using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer= Mathf.Infinity;
    private void Awake()
    {
            anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer >attackCoolDown && playerMovement.canAttack())
            Attack1();

        coolDownTimer += Time.deltaTime;
    }
    private void Attack1()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;

        fireballs[FindFirePoint()].transform.position = firePoint.position;
        fireballs[FindFirePoint()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFirePoint()
    {
        for (int i = 0;i<fireballs.Length;i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
