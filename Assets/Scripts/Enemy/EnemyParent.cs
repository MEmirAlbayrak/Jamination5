using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    int currentRealm = -1;

    private void Start() {
        changeRealm();
    }
    void changeRealm(){
        currentRealm++;
        for (int i = 0, length = transform.childCount; i < length; i++){
            if (i == currentRealm){
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
