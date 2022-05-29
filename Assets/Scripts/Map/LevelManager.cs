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
        ChangeRealms(0);

        EnemySpawner.Instance.SendSpawnCommand(waveCounts[0]);
    }

    public void ChangeRealms(int realm){
        currentRealm = realm;
        realmObjects.ForEach(realmObject => (realmObject as IRealm)?.ChangeRealm(currentRealm));
    }

    public void WaveFinished(){
        wave++;

        if (wave == waveCounts.Count){
            Debug.Log("finished!");
            LevelFinished();
            return;
        }

        Debug.Log("Send new wave");
        EnemySpawner.Instance.SendSpawnCommand(waveCounts[wave]);
    }

    private void LevelFinished(){
        Portal.Instance.gameObject.SetActive(true);
    }
}

public interface IRealm{
    void ChangeRealm(int realm);
}
