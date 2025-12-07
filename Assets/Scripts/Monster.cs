using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{

    // 플레이어 위치, 데미지, 체력, 속도 
    [SerializeField] Transform playerTrans;
    [SerializeField] Rigidbody2D rigid2d;
    [SerializeField] int health = 5;
    int damage = 2;
    int speed = 2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
    }
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (playerTrans.position - transform.position).normalized;
        rigid2d.linearVelocity = dir * speed;

        damageCheck();

    }

    void damageCheck()
    {
        if(Vector3.Distance(transform.position, playerTrans.transform.position) < 2)
        {
            playerTrans.gameObject.GetComponent<Player>().getDamage(damage);
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.gameObject.GetComponent<Player>().getDamage(damage);
    //    }
    //}


    public void GetDamage(int damage)
    {
        health -= damage;
    }

}
