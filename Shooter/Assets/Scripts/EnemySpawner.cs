using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    public GameObject enemy;
    float maxSpawnRatePerSec = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()//function to spawn enemy
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));//bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));//top-right corner

        GameObject anEnemy = (GameObject)Instantiate(enemy);//instantiate an enemy
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleEnemySpawn();//schedule when to spawn next enemy
    }
    
    void ScheduleEnemySpawn()
    {
        float spawnSec;

        if(maxSpawnRatePerSec > 1f)
        {
            spawnSec = Random.Range(1f, maxSpawnRatePerSec);//pick random number between 1 and maxSpawnRatePerSec
        }
        else
            spawnSec = 1f;
        Invoke("SpawnEnemy", spawnSec);
    }

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRatePerSec);

        maxSpawnRatePerSec = 10f;//reset maxSpawn rate
    }

    public void StopEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
    }
}
