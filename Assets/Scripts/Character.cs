using System.Runtime.CompilerServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 4f;
    public float JumpPower = 4f;

    private bool isFloor;
    private bool justJump, justAttack;
    public GameObject AttackObj;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private AudioSource audioSource;
    public AudioClip JumpClip;
    public AudioClip AttackClip;

    public GameObject AttckObj;
    public float AttackSpeed = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = false;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        JumpCheck();
        AttackCheck();
    }
    private void FixedUpdate()
    {
        Jump();
        Attack();
    }

    private void Attack()
    {
        if (justAttack)
        {
            justAttack = false;
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(AttackClip);

            if(gameObject.name == "Warrior")
            {
                AttackObj.SetActive(true);
                Invoke("SetAttackInactive", 0.5f);
            }
            else
            {
                if (spriteRenderer.flipX)
                {
                    GameObject obj = Instantiate(AttckObj, transform.position, Quaternion.Euler(0, 180f, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * AttackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
                else
                {
                    GameObject obj = Instantiate(AttckObj, transform.position, Quaternion.Euler(0, 0, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * AttackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
            }

        }
        
       void SetAttackObjInactive()
        {
            AttackObj.SetActive(false);
        }


    }
    private void AttackCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                justAttack = true;
                audioSource.PlayOneShot(JumpClip);
            }
        }
    }

    //มกวม
    private void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                justJump = true;
                audioSource.PlayOneShot(JumpClip);
            }
        }
    }

    private void Jump()

    {
        if (justJump)
        {
            justJump = false;
            rigidbody2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");

        }

    }



    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }

    }
}
