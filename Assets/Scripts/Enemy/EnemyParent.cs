using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
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
}
