using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector3 (-5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().receiveDamage();
            Destroy(this.gameObject);
        }
        if(collision.transform.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
