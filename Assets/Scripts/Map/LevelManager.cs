using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Component> realmObjects;
    public int currentRealm = 0; 
    private int wave = 0;
    [SerializeField] private List<int> waveCounts;
    private static LevelManager lm;
    public static LevelManager Instance => lm;
    
    private void Awake() {
        if (lm == null)
        {
            lm = this;
        }

        else
        {
            Destroy(gameObject);
        }       
    }
    void Start()
    {
        currentRealm--;
        ChangeRealms();

        EnemySpawner.Instance.SendSpawnCommand(waveCounts[0]);
    }

    public void ChangeRealms(){
        currentRealm++;
        realmObjects.ForEach(realmObject => (realmObject as IRealm)?.ChangeRealm(currentRealm));
    }
}

public interface IRealm{
    void ChangeRealm(int realm);
}
