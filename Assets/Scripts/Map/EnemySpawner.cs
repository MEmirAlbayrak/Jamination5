using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IRealm
{
    private void Start() {
        
    }
    public void ChangeRealm(int realm){
        for (int i = 0, length = transform.childCount; i < length; i++){
           transform.GetChild(i).GetComponent<EnemyParent>().ChangeRealm(realm);
        }
    }
}
