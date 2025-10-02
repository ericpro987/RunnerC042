using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        //poner el GETComponent
        GetComponent<Rigidbody2D>().linearVelocity = new Vector3 (-5, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player c = collision.transform.GetComponent<Player>();
            c.receiveDamage(1);
            c.Particles();
            this.gameObject.SetActive(false);
        }
        if(collision.transform.tag == "Finish")
        {
            this.gameObject.SetActive(false);
        }
    }
}
