using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // player trans, 마리수, 스폰시간, 스폰거리, 최대치

    [SerializeField] Transform playerTarget;
    [SerializeField] GameObject monster;
    float spawnTime;
    float timer; 
    float spawnDistance;
    int maxMonsterCount;
    int currentMonsterCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer >= spawnTime))
        {
            timer = 0;
        }
    }

    void MonsterSpawn()
    {
        if (currentMonsterCount < maxMonsterCount)
        {
            currentMonsterCount++;
            GameObject.Instantiate(monster);
        }
    }
}
