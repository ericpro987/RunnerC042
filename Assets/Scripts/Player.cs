using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputSystem_Actions action;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        hp = 5;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        action = new InputSystem_Actions();
        action.Player.Jump.started += Jump;
        //action.Player.Jump.performed += Jump;
        action.Enable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 3)
        {
            sr.color = new Color(0, Mathf.Sin(Time.time), 0);
        }else if( hp > 1)
        {
            sr.color = new Color(Mathf.Sin(Time.time), Mathf.Sin(Time.time), 0);

        }
        else
        {
            sr.color = new Color(Mathf.Sin(Time.time), 0, 0);
        }
        Move();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            receiveDamage();
        }
    }
    private void Move()
    {
        Vector2 dir = action.Player.Move.ReadValue<Vector2>()*3;
        rb.linearVelocity = dir;
    }
    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(new Vector2(0, 500));
    }
    private void receiveDamage()
    {
        this.hp--;
    }
}
