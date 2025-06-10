using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;      // ���� ���� ������
    public Transform[] spawnPoints;          // ���� ��ġ��

    public float[] spawnWeights;             // �� �������� ���� Ȯ�� ����ġ

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
            Debug.LogWarning("spawnPoints �Ǵ� prefabsToSpawn�� ��� �ֽ��ϴ�!");
            return;
        }

        if (spawnWeights.Length != prefabsToSpawn.Length)
        {
            Debug.LogWarning("spawnWeights �迭�� ���̴� prefabsToSpawn�� ���ƾ� �մϴ�!");
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

        // Ȥ�ö� �������� ������ ��� ������ ������ ��ȯ
        return prefabsToSpawn[prefabsToSpawn.Length - 1];
    }
}
