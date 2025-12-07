using System.Collections.Generic;
using UnityEngine;

public class bible : MonoBehaviour
{

    // 회전속도, 데미지, 갯수, 플레이어 위치, 간격, 지속시간, 쿨타임, 플레이어-바이블 거리
    private List<GameObject> bibles = new List<GameObject>();

    [SerializeField] GameObject biblePrefab;
    float rotateSpeed = 180.0f;
    int bibleCount= 1;
    float bibletobibleDis;
    float bibletoPlayerDis = 2.0f;
    float currentAngle = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BibleSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += rotateSpeed * Time.deltaTime;
        UpdateBiblePos();
    }

    void UpdateBiblePos()
    {
        float step = 360f / bibleCount;

        for (int i = 0; i < bibleCount; i++)
        {
            float angle = (currentAngle + step * i) * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * bibletoPlayerDis;
            bibles[i].transform.position = transform.position + offset;
        }
    }

    void BibleSpawn()
    {
        for(int i= 0; i<bibleCount;i++)
        {
            GameObject Bible = Instantiate(biblePrefab, transform.position, Quaternion.identity);
            bibles.Add(Bible);

        }
    }
}
