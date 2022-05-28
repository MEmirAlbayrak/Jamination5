using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridParent : MonoBehaviour, IRealm
{
    public void ChangeRealm(int realm){
        for (int i = 0, length = transform.childCount; i < length; i++){
            if (i/2 == realm){
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
