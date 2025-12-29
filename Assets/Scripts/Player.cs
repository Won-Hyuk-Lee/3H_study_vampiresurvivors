using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 inputVec;
    [SerializeField] float speed;
    [SerializeField] int hp = 10;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int currentEXP;
    [SerializeField] int level = 1;

    int[] expToNextLev = { 3, 8, 15, 20 };


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

    public void addExperience(int experience)
    {
        currentEXP += experience;
        int i = 0;
       
        if (currentEXP >= expToNextLev[i])
        {
            levelUp();
            i++;
        }
    }

    public void levelUp()
    {
        currentEXP = 0;
        level++;
    }

}
