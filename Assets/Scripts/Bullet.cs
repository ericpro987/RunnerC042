using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector3 (10,0,0);
    }

}
