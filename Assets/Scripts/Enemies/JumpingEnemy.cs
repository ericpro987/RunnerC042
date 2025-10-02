using System.Collections;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    int jumpTime;
    Rigidbody2D rb;
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        jumpTime = Random.Range(1, 4);
        GetComponent<Rigidbody2D>().linearVelocity = new Vector3(-5, 0, 0);
        StartCoroutine(Jump());
    }
    private void OnDisable()
    {
        StopCoroutine(Jump());
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
        if (collision.transform.tag == "Finish")
        {
            this.gameObject.SetActive(false);
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
