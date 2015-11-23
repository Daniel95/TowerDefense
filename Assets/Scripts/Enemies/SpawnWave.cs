using UnityEngine;
using System.Collections;

public class SpawnWave : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private float[] enemiesCost;

    [SerializeField]
    private int wavePointsIncrement;

    [SerializeField]
    private int wavePointsStartValue;

    [SerializeField]
    private int spawnTimeMin;

    [SerializeField]
    private int spawnTimeMax;

    private float wavePoints;

    public void StartNewWave() {
        wavePoints = wavePointsStartValue;
        StartCoroutine(SpawnEnemies(wavePoints));
        wavePointsStartValue += wavePointsIncrement;
    }

    IEnumerator SpawnEnemies(float _points)
    {
        //This function will spawn random enemies that are stored in a array,
        //at random spots that are also stored in a array.
        
        //for each unit I spawn I spend _points depeding of the strength of that indiviual unit.

        //when all the _points are used this functions stops and the wave is spawned.

        //for each wave i increment the _points this system can use.

        //the result is that i can spawn endless waves of random enemies while each wave is still balanced for the player.

        float counter = 0;

        //while there are enough points left, continue
        while (_points > 0)
        {
            if (counter < 0)
            {
                //make a float that contains the spawn chance each enemy has to spawn
                float enemySpawnChance = 1;
                enemySpawnChance /= enemies.Length;
                //make a random number to choose a enemy
                float randomE = Random.Range(0, 0.99f);

                for (int e = 0; e < enemies.Length; e++)
                {
                    //look at the minimal & maximal value of enemySpawnChange and when the random number is between these
                    //then we will use the E in the for loop later for: enemy[e]
                    if (enemySpawnChance * e < randomE && enemySpawnChance * (e + 1) > randomE)
                    {
                        //decrement the enemy cost off the _points.
                        _points -= enemiesCost[e];

                        //same routine as the first for loop but now we choose a spawn point
                        float spawnPointChance = 1;
                        spawnPointChance /= spawnPoints.Length;
                        float randomS = Random.Range(0, 0.99f);

                        for (int s = 0; s < enemies.Length; s++)
                        {
                            if (spawnPointChance * s < randomS && spawnPointChance * (s + 1) > randomS)
                            {
                                Instantiate(enemies[e], spawnPoints[s].transform.position, spawnPoints[s].transform.rotation);
                                print("winner = " + e + " pointsleft = " + _points);
                                counter = Random.Range(spawnTimeMin, spawnTimeMax);
                            }
                        }
                    }
                }
            }
            counter--;
            yield return new WaitForFixedUpdate();
        }
    }
}
