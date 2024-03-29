﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
            //Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

     private void EnemyDeath()
        {
             animator.SetTrigger("death");
             GetComponent<EnemyAI>().enabled = false;
             GetComponent<NavMeshAgent>().enabled = false;
             GetComponent<CapsuleCollider>().enabled = false;
        }
}
