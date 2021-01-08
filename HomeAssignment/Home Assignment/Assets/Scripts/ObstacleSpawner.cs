using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;


    int startingWave = 0;


    
    IEnumerator Start()
    {
      
        do
        {
            
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); 
    }

    
    void Update()
    {

    }

   
    private IEnumerator SpawnAllObstacleInWave(WaveConfig waveToSpawn)
    {
      
        for (int ObstacleCount = 1; ObstacleCount <= waveToSpawn.GetNumberOfObsatcles(); ObstacleCount++)
        {
            
            var newObstacle = Instantiate(
                            waveToSpawn.GetObsatclePrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);


            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

           
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }

    }

    private IEnumerator SpawnAllWaves()
    {
     
        foreach (WaveConfig currentWave in waveConfigList)
        {
      
            yield return StartCoroutine(SpawnAllObstacleInWave(currentWave));
        }
    }
}
