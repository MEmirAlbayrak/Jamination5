using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float damage = 5;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("SpikeTriggered", true);
        }
    }

        private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("SpikeTriggered", false);
        }
    }

    private void HitPlayer(){
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TakeDamage(damage);
    }
}
