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
        for (int i = 0, length = transform.childCount; i < length; i++){
            if (i == realm){
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else {
                transform.GetChild(i).gameObject.SetActive(false);
            }
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
