using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;      // 여러 개의 프리팹
    public Transform[] spawnPoints;          // 스폰 위치들

    public float minSpawnDelay = 1f;         // 최소 대기 시간
    public float maxSpawnDelay = 3f;         // 최대 대기 시간

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private System.Collections.IEnumerator SpawnRoutine()
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

        // 랜덤 프리팹 선택
        GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        // 랜덤 위치 선택
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(randomPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }
}
