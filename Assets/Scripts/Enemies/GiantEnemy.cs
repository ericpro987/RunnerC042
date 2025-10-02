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
    }
    private void OnEnable()
    {
        hp = 5;
    }
    private void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector3(-1, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player c = collision.transform.GetComponent<Player>();
            c.receiveDamage(3);
            c.Particles();
            this.gameObject.SetActive(false);
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
            this.gameObject.SetActive(false);
        }
    }
}
