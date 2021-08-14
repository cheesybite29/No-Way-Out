using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public float spawnSpeed;
    private float lastSpawn;
    public List<GameObject> enemies;
    private PlayerControler player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControler>();
        lastSpawn = spawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawn += Time.deltaTime;

        if (lastSpawn >= spawnSpeed)
        {
            SpawnEnemy();
            lastSpawn = 0;
        }

    }

    private void SpawnEnemy()
    {
        if (enemies.Count <= 0) return;
        if (player.PlayerIsDead()) return;
        Instantiate(enemies[Random.Range(0, enemies.Count)],transform.position,Quaternion.identity);
    }
}

