using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 inputVec;
    [SerializeField] float speed;
    [SerializeField] int hp;
    [SerializeField] Rigidbody2D rigid;

    private void Awake()
    {
        //rigid = getcomponent<rigidbody2d>(); 10행으로 대체.
    }

    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        ////1. 힘을 준다
        //rigid.AddForce(inputVec);

        ////2. 속도 제어
        //rigid.linearVelocity = inputVec;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);
    }


    public void getDamage(int damage)
    {
        hp -=damage;
    }

}
