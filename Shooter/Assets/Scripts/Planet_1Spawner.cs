using UnityEngine;

public class Planet_1Spawner : MonoBehaviour
{
    public GameObject planets_1;
    public GameObject planets_2;
    public GameObject planets_7;
    public GameObject planets_8;
    public GameObject planets_14;

    float maxSpawnRatePerSec = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlanet()//function to spawn planet
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));//bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));//top-right corner

        switch (Random.Range(1,6)){

            case 1: 
                GameObject a1Planet = (GameObject)Instantiate(planets_1);//instantiate one of the planets
                a1Planet.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                SchedulePlanetSpawn();//schedule when to spawn next planet
            break;

            case 2:
                GameObject a2Planet = (GameObject)Instantiate(planets_2);//instantiate one of the planets
                a2Planet.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                SchedulePlanetSpawn();//schedule when to spawn next planet
            break;

            case 3:
                GameObject a3Planet = (GameObject)Instantiate(planets_7);//instantiate one of the planets
                a3Planet.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                SchedulePlanetSpawn();//schedule when to spawn next planet
            break;

            case 4:
                GameObject a4Planet = (GameObject)Instantiate(planets_8);//instantiate one of the planets
                a4Planet.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                SchedulePlanetSpawn();//schedule when to spawn next planet
            break;

            case 5:
                GameObject a5Planet = (GameObject)Instantiate(planets_14);//instantiate one of the planets
                a5Planet.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                SchedulePlanetSpawn();//schedule when to spawn next planet
            break;
        }
    }
    
    void SchedulePlanetSpawn()
    {
        float spawnSec;

        if(maxSpawnRatePerSec > 1f)
            spawnSec = Random.Range(1f, maxSpawnRatePerSec);//pick random number between 1 and maxSpawnRatePerSec
        else
            spawnSec = 1f;
        Invoke("SpawnPlanet", spawnSec);
    }
    public void SchedulePlanetSpawner()
    {
        Invoke("SpawnPlanet", maxSpawnRatePerSec);
        maxSpawnRatePerSec = 8f;//reset maxspawn rate
    }

    public void StopPlanetSpawner()
    {
        CancelInvoke("SpawnPlanet");
    }
}
