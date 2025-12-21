using UnityEngine;

public class gem : MonoBehaviour
{
    [SerializeField] int expValue = 0;
    float attractRange = 5.0f;
    int speed = 2;

    [SerializeField] Transform playerTrans;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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
