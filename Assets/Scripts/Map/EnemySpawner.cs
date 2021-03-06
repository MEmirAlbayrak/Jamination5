using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IRealm
{
    [SerializeField] [Range(0, 5)] private float spawnTimeMin = 0.1f;
    [SerializeField] [Range(0, 5)] private float spawnTimeMax = 2f;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _spawnPoints;
    private float spawnTimeCounter = 0;
    private bool _canSpawn = false;
    private int _enemySpawnNumber;
    private static EnemySpawner es;
    [SerializeField] private float playerSpawnerDistance = 20f; 
    public static EnemySpawner Instance => es;
    private int leftEnemyCount;
    
    private void Awake() {
        if (es == null)
        {
            es = this;
        }

        else
        {
            Destroy(gameObject);
        }       
    }

    private void Update() {
        spawnTimeCounter -= Time.deltaTime;

        if (_canSpawn){

            if (_enemySpawnNumber > 0 && spawnTimeCounter < 0){
                SpawnZombies();
            }
 
            else if (_enemySpawnNumber <= 0)
            {
                _canSpawn = false; 
            }

        }
    }

   private void SpawnZombies()
    {
        _enemySpawnNumber--;
        spawnTimeCounter = Random.Range(spawnTimeMin, spawnTimeMax);

        Instantiate(_enemyPrefab, LookForSpawnPoints(), Quaternion.identity, transform);
    }
    public void ChangeRealm(int realm){
        for (int i = 0, length = transform.childCount; i < length; i++){
           transform.GetChild(i).GetComponent<EnemyParent>().ChangeRealm(realm);
        }
    }

    private Vector3 LookForSpawnPoints(){
        List<Transform> canSpawnPoints = new List<Transform>();

        foreach (Transform point in _spawnPoints)
        {
            if (Vector2.Distance(point.position, _player.position) < playerSpawnerDistance)
            {
                canSpawnPoints.Add(point);
            }
        }

        int randomPos = Random.Range(0, canSpawnPoints.Count);
        Vector3 enemyPosition = canSpawnPoints[randomPos].position;

        return enemyPosition;
    }

    public void SendSpawnCommand(int enemySpawnNumber)
    {
        _enemySpawnNumber += enemySpawnNumber;
        leftEnemyCount += enemySpawnNumber;
        _canSpawn = true;
    }

    public void EnemyKilled(){
        leftEnemyCount -= 1;

        if (leftEnemyCount == 0){
            LevelManager.Instance.WaveFinished();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GameObject.FindGameObjectWithTag("Player").transform.position, playerSpawnerDistance);
    }
}
