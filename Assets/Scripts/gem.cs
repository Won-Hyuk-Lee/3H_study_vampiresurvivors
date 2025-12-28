using UnityEngine;

public class gem : MonoBehaviour
{
    [SerializeField] int expValue = 0;
    float attractRange = 3.0f;
    int speed = 2;

    [SerializeField] Transform playerTrans;
    [SerializeField] Rigidbody2D rigid2d;

    Vector2 distancetoPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, playerTrans.position) < attractRange)
        {
            Vector2 distancetoPlayer = (Vector2)playerTrans.position - (Vector2)transform.position;
            rigid2d.linearVelocity = distancetoPlayer.normalized * speed;
        }
        else
        {
            rigid2d.linearVelocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().addExperience(expValue);
            Destroy(gameObject);
        }
    }

    public void setExpValue(int value)
    {
        expValue = value;
    }

}
