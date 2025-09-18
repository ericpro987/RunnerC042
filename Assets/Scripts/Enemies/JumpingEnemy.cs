using System.Collections;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    int jumpTime;
    Rigidbody2D rb;
    void Start()
    {
        jumpTime = Random.Range(1, 4);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector3(-3, 0, 0);
        StartCoroutine(Jump());
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
        if (collision.transform.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Jump()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpTime);
            rb.AddForceY(300);
        }
    }
}
