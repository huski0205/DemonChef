using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;      // 여러 개의 프리팹
    public Transform[] spawnPoints;          // 스폰 위치들

    public float[] spawnWeights;             // 각 프리팹의 스폰 확률 가중치

    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnAtRandomPoint();

            float waitTime = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnAtRandomPoint()
    {
        if (spawnPoints.Length == 0 || prefabsToSpawn.Length == 0)
        {
            Debug.LogWarning("spawnPoints 또는 prefabsToSpawn가 비어 있습니다!");
            return;
        }

        if (spawnWeights.Length != prefabsToSpawn.Length)
        {
            Debug.LogWarning("spawnWeights 배열의 길이는 prefabsToSpawn와 같아야 합니다!");
            return;
        }

        GameObject selectedPrefab = ChoosePrefabByWeight();

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(selectedPrefab, randomSpawnPoint.position, selectedPrefab.transform.rotation);
    }

    GameObject ChoosePrefabByWeight()
    {
        float totalWeight = 0f;
        foreach (float weight in spawnWeights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float accumulatedWeight = 0f;

        for (int i = 0; i < spawnWeights.Length; i++)
        {
            accumulatedWeight += spawnWeights[i];
            if (randomValue <= accumulatedWeight)
            {
                return prefabsToSpawn[i];
            }
        }

        // 혹시라도 도달하지 못했을 경우 마지막 프리팹 반환
        return prefabsToSpawn[prefabsToSpawn.Length - 1];
    }
}
