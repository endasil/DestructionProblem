using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public TextMeshPro text;    
    public BoxCollider SpawnArea;
    public GameObject[] ObjectsToSpawn;    
    
    private int destroyCount = 0;
    private int blueDestroyed = 0;
    private int redDestroyed = 0;
    private int spawnedObjects = 0;

    internal void AddDestroyCount() => destroyCount++;    
    
    
    internal void AddBlueDestroyed()
    {
        blueDestroyed++;
        UpdateScoreText();
    }
    internal void AddRedDestroyed()
    {
        redDestroyed++;        
        UpdateScoreText();
    }
    void UpdateScoreText() => text.text = $"Destroyed\n Red: {redDestroyed} Blue: {blueDestroyed} count: {destroyCount}";
    void Update() => SpawnRandomObject();

    void SpawnRandomObject()
    {        
        if (spawnedObjects == 100)
            return;       
        
        var ball0 = Instantiate(ObjectsToSpawn[0], GetRandomPointInsideSpawnArea(), ObjectsToSpawn[0].transform.rotation);
        ball0.name += Time.frameCount;
        var ball1 = Instantiate(ObjectsToSpawn[1], GetRandomPointInsideSpawnArea(), ObjectsToSpawn[1].transform.rotation);
        ball1.name += Time.frameCount;
        spawnedObjects++;
    }

    public Vector3 GetRandomPointInsideSpawnArea()
    {
        Vector3 extents = SpawnArea.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        ) + SpawnArea.center;
        return SpawnArea.transform.TransformPoint(point);
    }
}
