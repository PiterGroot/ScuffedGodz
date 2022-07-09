using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemySpawner : MonoBehaviour
{
    private Transform followTarget;
    [SerializeField] private bool startSpawningOnAwake = true;
    [SerializeField]private AnimationCurve difficultyRamp;
    [SerializeField] private Vector2 spawnRadius;
    [SerializeField] private int enemyCount;
    [SerializeField] private int spawnInterval;
    [SerializeField] private GameObject[] enemies;

    private void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("TargetGroup").transform;
        if (startSpawningOnAwake) SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        GameObject enemyCluster = new GameObject("EnemyCluster");
        for (int i = 0; i < enemyCount; i++)
        {
            float spawnRadiusPoint = Random.Range(spawnRadius.x, spawnRadius.y);
            Vector2 randomSpawnPoint = Random.insideUnitCircle.normalized * spawnRadiusPoint;
            GameObject enemy = Instantiate(GetRandomEnemy(), randomSpawnPoint, Quaternion.identity);
            enemy.transform.SetParent(enemyCluster.transform);
        }
        enemyCluster.transform.position = transform.position;
        Invoke(nameof(SpawnEnemies), spawnInterval);
    }

    private void Update()
    {
        transform.position = followTarget.transform.position;
    }
    private GameObject GetRandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius.y);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius.x);
    }
}
