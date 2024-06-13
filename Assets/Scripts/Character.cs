using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float Speed = 4f;
    public float JumpPower = 4f;
    public float oriSpeed;

    public float AttackPower = 5f;

    private bool isFloor;
    private bool isLadder;
    private bool isClimbing;
    private float inputVertical;
    private bool justJump, justAttack;
    public GameObject AttackObj;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private AudioSource audioSource;
    public AudioClip JumpClip;
    public AudioClip AttackClip;

    public GameObject AttckObj;
    public float AttackSpeed = 7f;



    private static Character _instance;

    public static Character Instance
    { get { return _instance; } }

    // GameManager 초기화
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); // 이미 인스턴스가 존재하면 새로 생성된 것을 파괴
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject); // 새로운 씬으로 전환되어도 파괴되지 않도록 설정
    }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
            Debug.Log("1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        oriSpeed = Speed;
    }

    void Update()
    {
        Move();
        JumpCheck();
        AttackCheck();
        ClimbingCHeck();
    }
    private void FixedUpdate()
    {
        Jump();
        _Attack();
        Climbing();
    }

    public void spood()
    {
        Speed = oriSpeed += 3;
    }

  
    void ClimbingCHeck()
    {
        inputVertical = Input.GetAxis("Vertical");
        if (isLadder && Math.Abs(inputVertical) > 0)
        {
            isClimbing = true;
        }
    }
    void Climbing()
    {
        if (isClimbing)
        {
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, inputVertical * Speed);
        }
        else
        {
            rigidbody2d.gravityScale = 1f;
        }
    }
    //공격
    private void _Attack()
    {
        if (justAttack)
        {
            justAttack = false;
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(AttackClip);

            if(gameObject.name == "Warrior(Clone)")
            {
                AttackObj.SetActive(true);
                Invoke("SetAttackInactive", 0.5f);
                return;
            }
            
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
            if (Input.GetMouseButton((int)MouseButton.Left))
            {
                justAttack = true;
                audioSource.PlayOneShot(JumpClip);
            }
        }
    }

    //점프
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
