using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTrap : MonoBehaviour
{
    [SerializeField] private int damageToPlayer;
    [SerializeField] private int damageToEnemy;
    [SerializeField] private float radius;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            animator.SetTrigger("Explode");
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void HitDamage(){
        transform.localScale = new Vector3(7,7,7);

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (var i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].CompareTag("Player")){
                hitColliders[i].GetComponent<PlayerMovement>().TakeDamage(damageToPlayer);
            }

            else if(hitColliders[i].CompareTag("Explosion")){
                hitColliders[i].GetComponent<ExplodingTrap>().animator.SetTrigger("Explode");
            }

            else if(hitColliders[i].CompareTag("Enemy")){
                hitColliders[i].GetComponent<EnemyBehavior>().TakeDamage(damageToEnemy);
            }
        }
    }

    private void DestroyTrap(){
        Destroy(gameObject);
    }
}
