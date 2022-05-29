using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] private GameObject pentagram;
    [SerializeField] private float hp = 100;
    private GameObject newPentagram;
    private float pentagramAnimationCurrentTime = 0;
    private bool doesBorn = false;
    [SerializeField] private float pentagramAnimationDuration = 1;
    private void Start() {
        newPentagram = Instantiate(pentagram, transform.position, Quaternion.identity);
    }

    private void Update() {
        if (!doesBorn){
            pentagramAnimationCurrentTime += Time.deltaTime;

            if (pentagramAnimationCurrentTime > pentagramAnimationDuration){
                Destroy(newPentagram.gameObject);
                transform.eulerAngles = Vector3.zero;
                ChangeRealm(LevelManager.Instance.currentRealm);
                doesBorn = true;
            }
        }
    }
    public void ChangeRealm(int realm){
        if (realm == 0){
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).transform.position = transform.GetChild(1).transform.position;
            transform.GetChild(0).GetComponent<EnemyBehavior>()._agent.SetDestination(transform.GetChild(0).transform.position);
        }
            else if (realm == 1){
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).transform.position = transform.GetChild(0).transform.position;
            transform.GetChild(1).GetComponent<EnemyBehavior>()._agent.SetDestination(transform.GetChild(1).transform.position);
        }
    }

    public void TakeDamage(float damage){
        hp -= damage;

        if (hp < 0){
            Die();
        }
    }

    private void Die(){
        EnemySpawner.Instance.EnemyKilled();
        Destroy(gameObject);
    }
}
