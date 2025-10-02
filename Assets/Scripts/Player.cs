using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputSystem_Actions action;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField]
    private float hp;
    [SerializeField]
    private int velocity;
    [SerializeField]
    private float pos;
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private int maxJump = 1;
    [SerializeField]
    private int nJumps;
    [SerializeField]
    private Smiley smiley;
    ParticleSystem ps;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        nJumps = maxJump;
        hp = 5;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        action = new InputSystem_Actions();
        action.Player.Jump.started += Jump;
        action.Player.Attack.started += Shoot;
        //action.Player.Jump.performed += Jump;
        action.Enable();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position.x;
       /* if (hp > 3)
        {
            sr.color = new Color(0, Mathf.Sin(Time.time), 0);
        }
        else if (hp > 1)
        {
            sr.color = new Color(Mathf.Sin(Time.time), Mathf.Sin(Time.time), 0);

        }
        else
        {
            sr.color = new Color(Mathf.Sin(Time.time), 0, 0);
        }*/
        Move();
    }
    private void Move()
    {
        if (pos < 0 && pos > -11)
        {
            Vector2 dir = action.Player.Move.ReadValue<Vector2>() * velocity;
            rb.linearVelocity = new Vector2(dir.x, rb.linearVelocity.y);
        }
        else
        {
            if (pos >= 0)
                this.transform.position = new Vector3(-0.01f, this.transform.position.y, this.transform.position.z);
            else if (pos <= -11)
                this.transform.position = new Vector3(-10.99f, this.transform.position.y, this.transform.position.z);

        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (nJumps > 0)
        {
            animator.Play("CharacterJump");
            nJumps--;
            rb.AddForceY(4.2f,ForceMode2D.Impulse);
        }
    }
    bool cooldown = false;
    private void Shoot(InputAction.CallbackContext context)
    {
        if (!cooldown)
        {
            cooldown = true;
            Bullet b = Instantiate(bullet);
            b.transform.position = this.transform.position;
            StartCoroutine(resetCooldown());
        }
    }
    IEnumerator resetCooldown()
    {
        yield return new WaitForSeconds(1);
        cooldown = false;
    }

    bool smileyAppear = false;
    public void receiveDamage(int damage)
    {
        this.hp -= damage;
        print(hp);
        if (this.hp <= 0 && !smileyAppear)
            StartCoroutine(SmileyTime());
    }
    public void Particles()
    {
        ps.Play();
    }
    IEnumerator SmileyTime()
    {
        smileyAppear = true;
        float r = Random.Range(3f, 11f);
        yield return new WaitForSeconds(r);
        smiley.gameObject.SetActive(true);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            animator.Play("CharacterRunning");
            nJumps = maxJump;
        }
    }
    private void OnDestroy()
    {
        action.Player.Jump.started -= Jump;
        action.Player.Attack.started -= Shoot;
        action.Disable();
    }
}
