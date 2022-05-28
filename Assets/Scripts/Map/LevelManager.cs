using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Component> realmObjects;
    [SerializeField] private int currentRealm = 0;
    void Start()
    {
        currentRealm--;
        ChangeRealms();
    }

    public void ChangeRealms(){
        currentRealm++;
        realmObjects.ForEach(realmObject => (realmObject as IRealm)?.ChangeRealm(currentRealm));
    }
}

public interface IRealm{
    void ChangeRealm(int realm);
}
