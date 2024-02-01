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

        // �����̽� Ű �Է� ó��
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
        // �׷��� �ʴٸ� ���� ���·� ��ȯ�Ѵ�.
        else
        {
            Die();
        }
    }
    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);  //�ǰ� ��� �ð� ��ŭ ��ٸ�
    }

    void Die()
    {
        // ���� ���� �ǰ� �ڷ�ƾ�� �����Ѵ�.
        StopAllCoroutines();
        Destroy(gameObject);
        Debug.Log("����");
    }

    private void OnTriggerEnter(Collider other)
    {
     
    }

}
