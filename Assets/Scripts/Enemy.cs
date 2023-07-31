using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    public GameObject projectile;
    public Transform projectilePoint;
    public Animator animator;

    public static bool killed = false;

    void Start()
    {
        PauseMenu.target++;
    }

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
        rb.AddForce(transform.up * 4, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
            PauseMenu.kills++;
            killed = true;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

}
