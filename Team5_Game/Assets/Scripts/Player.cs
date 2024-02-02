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
    public Animator animator;

    public int hp = 100;

    int maxHp = 100;

    public Slider hpSlider;

    Vector3 movement;

    public float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();

        // "Wizard Variant" ������Ʈ�� Animator ������Ʈ ��������
        Animator wizardAnimator = transform.Find("Wizard Variant")?.GetComponent<Animator>();

        if (wizardAnimator != null)
        {
            animator = wizardAnimator;
        }
        else
        {
            // "Wizard Variant" ������Ʈ�� Animator�� ���� ��� ���� �α� ���
            Debug.LogError("Animator component is missing on the Wizard Variant object under the Player!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        hpSlider.value = (float)hp / (float)maxHp;

        // ���� ������Ʈ�� ��ġ
        Vector3 currentPosition = transform.position;

        // ���̰� 0 ������ ��� 0���� ����
        if (currentPosition.y < -2.88f)
        {
            currentPosition.y = -2.88f;
            transform.position = currentPosition;
        }

        Run();
    }

    private void Run()
    {
        Vector3 moveVelocity = Vector3.zero;
        animator.SetBool("isRun", false);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = -1f;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(direction, 1, 1);
            animator.SetBool("isRun", true);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = 1f;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(direction, 1, 1);
            animator.SetBool("isRun", true);
        }

        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    public void DamageAction(int damage)
    {
        hp -= damage;

        if (hp > 0)
        {
            StartCoroutine(DamageProcess());
            animator.SetBool("hurt", true);
        }
        else
        {
            Die();
        }
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void Die()
    {
        StopAllCoroutines();
        animator.SetTrigger("Die");
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
