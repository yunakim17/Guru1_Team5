using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 5f;

    private Rigidbody2D myRigid;
    private SpriteRenderer spriter;

    private float horizontal;
    //private Animator animator;

    public int hp = 100;

    int maxHp = 100;

    public Slider hpSlider;


    Vector3 movement;

    public float direction = 1;

    public float jumpPower = 30f;

    bool isJumping = false;




    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();

        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        hpSlider.value = (float)hp / (float)maxHp;

        // 스페이스 키 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y == -2.88f)
        {
            isJumping = true;
        }

        Run();
        Jump();
    }


    private void Run()
    {
        Vector3 moveVelocity = Vector3.zero;
        //anim.SetBool("isRun", false);


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = -1f;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(direction, 1, 1);
            //if (!anim.GetBool("isJump"))
            //    anim.SetBool("isRun", true);

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = 1f;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(direction, 1, 1);
            //if (!anim.GetBool("isJump"))
            //    anim.SetBool("isRun", true);

        }
        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (transform.position.y < -2.88f)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = -2.88f;
            transform.position = newPosition;
        }
        if (isJumping == true)
        {
            this.myRigid.AddForce(transform.up * this.jumpPower);
            isJumping = false;
        }

    }






    public void DamageAction(int damage)
    {
        hp -= damage;

        if (hp > 0)
        {
            StartCoroutine(DamageProcess());
        }
        // 그렇지 않다면 죽음 상태로 전환한다.
        else
        {
            Die();
        }
    }
    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);  //피격 모션 시간 만큼 기다림
    }

    void Die()
    {
        // 진행 중인 피격 코루틴을 중지한다.
        StopAllCoroutines();
        Destroy(gameObject);
        Debug.Log("죽음");
    }

    private void OnTriggerEnter(Collider other)
    {
     
    }

}
