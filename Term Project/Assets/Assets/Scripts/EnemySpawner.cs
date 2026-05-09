using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    public int maxEnemies = 20;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && activeEnemies.Count < maxEnemies)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab, sp.position, sp.rotation);
        activeEnemies.Add(newEnemy);

        CharacterStats stats = newEnemy.GetComponent<CharacterStats>();
        if (stats != null)
        {
            stats.OnDeath += () => activeEnemies.Remove(newEnemy);
        }
    }
}