using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;      // ���� ���� ������
    public Transform[] spawnPoints;          // ���� ��ġ��

    public float minSpawnDelay = 1f;         // �ּ� ��� �ð�
    public float maxSpawnDelay = 3f;         // �ִ� ��� �ð�

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
            Debug.LogWarning("spawnPoints �Ǵ� prefabsToSpawn�� ��� �ֽ��ϴ�!");
            return;
        }

        // ���� ������ ����
        GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        // ���� ��ġ ����
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(randomPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }
}
