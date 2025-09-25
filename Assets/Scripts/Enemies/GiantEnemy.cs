using UnityEngine;

public class GiantEnemy : MonoBehaviour
{
    private int hp;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        hp = 5;
    }
    private void Update()
    {
        rb.linearVelocity = new Vector3(-1, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().receiveDamage(3);
            Destroy(this.gameObject);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            receiveDamage();
        }
    }
    [SerializeField]
    private float redColor = 0;
    public void receiveDamage()
    {
        redColor += 0.05f;
        this.hp--;
        sr.color = new Color(redColor,0,0);
        if (this.hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
