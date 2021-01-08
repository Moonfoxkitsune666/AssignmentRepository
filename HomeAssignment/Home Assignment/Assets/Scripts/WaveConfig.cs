using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Obsatcle Wave Config")]
public class WaveConfig : ScriptableObject
{
  
    [SerializeField] GameObject obsatclePrefab;

 
    [SerializeField] GameObject pathPrefab;


    [SerializeField] float timeBetweenSpawns = 0.5f;


    [SerializeField] float spawnRandomFactor = 0.3f;

   
    [SerializeField] int numberOfObsatcles = 5;


    [SerializeField] float obstacleMoveSpeed = 2f;


    public GameObject GetObsatclePrefab()
    {
        return obsatclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
    
        var waveWayPoints = new List<Transform>();

   
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;

    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObsatcles()
    {
        return numberOfObsatcles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    void Start()
    {

    }

   
    void Update()
    {

    }
}
