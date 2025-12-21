using UnityEngine;

public class Spawner : MonoBehaviour
{
    // player trans, 마리수, 스폰시간, 스폰거리, 최대치

    [SerializeField] Transform playerTarget;
    [SerializeField] GameObject monster;
    [SerializeField] float spawnTime = 1.0f;
    float timer;
    [SerializeField] float spawnDistance = 12f;
    [SerializeField] int maxMonsterCount = 10;
    int currentMonsterCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (playerTarget == null)
        {
            playerTarget = GameObject.FindWithTag("Player").transform;
        }

        if (monster == null)
        {
            monster = GameObject.FindWithTag("Enemy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer >= spawnTime))
        {
            timer = 0;
            MonsterSpawn();
        }
    }

    void MonsterSpawn()
    {
        if (currentMonsterCount < maxMonsterCount)
        {
            currentMonsterCount++;
            GameObject.Instantiate(monster);
        }
        if (currentMonsterCount >= maxMonsterCount) return;

        Vector3 spawnPos = playerTarget.position + (Vector3)(Random.insideUnitCircle.normalized * spawnDistance);

        Instantiate(monster, spawnPos, Quaternion.identity);
        currentMonsterCount++;
    }
}
