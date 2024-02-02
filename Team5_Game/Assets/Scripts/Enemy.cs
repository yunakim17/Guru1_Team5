using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 400;

    int maxHp = 400;

    public Slider hpSlider;

    public float findDistance = 15f;    //����

    Transform player;

    public float attackdistsnce = 1.5f;

    public float speed = 3f;

    CharacterController cc;

    public Animator anim;

    enum EnemyState
    {
        Idle,
        Move,
        Attack1,
        Damaged,
        Die
    }

    EnemyState m_state;

    float currentTime1 = 0;
    float attackdelay1 = 5f;

    public int attackpower1 = 7;

    // Start is called before the first frame update
    void Start()
    {
        m_state = EnemyState.Idle;
        
        //�÷��̾��� Ʈ������ ������Ʈ�� �޾ƿ���
        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_state)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Move:
                Move();
                break;

            case EnemyState.Attack1:
                attack1();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;

        Vector3 currentPosition = transform.position;

        // ���̰� -2.88 ������ ��� 0���� ����
        if (currentPosition.y < -2.88f)
        {
            currentPosition.y = -2.88f;
            transform.position = currentPosition;
        }
    }

    void Idle()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                             new Vector3(player.position.x, 0, player.position.z)) < findDistance)
        {
            m_state = EnemyState.Move;
        }
        
    }

    void Move()
    {
        anim.SetBool("idleToWalk", false);

        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                             new Vector3(player.position.x, 0, player.position.z)) > attackdistsnce)
        {
            Vector3 dir = (new Vector3(player.position.x, 0, player.position.z) -
                           new Vector3(transform.position.x, 0, transform.position.z)).normalized;

            cc.Move(dir * speed * Time.deltaTime);
            anim.SetBool("idleToWalk", true);
        }
        else
        {
            if (currentTime1 <= 0)  // ������ �κ�
            {
                m_state = EnemyState.Attack1;
                currentTime1 = attackdelay1;
            }
        }

        // �� ���� ���¿��� currentTime ����
        if (m_state == EnemyState.Attack1)
        {
            currentTime1 -= Time.deltaTime;
        }
    }


    void attack1()
    {
        // ������ �ð����� �÷��̾ �����Ѵ�.
        if (Vector3.Distance(transform.position, player.position) < attackdistsnce)
        {
            currentTime1 += Time.deltaTime;
            if (currentTime1 > attackdelay1)
            {
                player.GetComponent<Player>().DamageAction(attackpower1);
                anim.SetBool("attack", true);
                Debug.Log("���ʹ��� ����1");
                currentTime1 = 0;
            }
        }
        //�׷��� �ʴٸ� ���� ���¸� �̵����� ��ȯ�Ѵ�.
        else
        {
            m_state = EnemyState.Move;
            currentTime1 = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }

    public void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);  //�ǰ� ��� �ð� ��ŭ ��ٸ�

        //���� ���¸� �ٽ� �̵� ���·� ��ȯ
        m_state = EnemyState.Move;
    }

    //������ ���� �Լ�
    public void HitEnemy(int hitpower)
    {
        hp -= hitpower;

        if (hp > 0)
        {
            m_state = EnemyState.Damaged;
            Damaged();
        }
        // �׷��� �ʴٸ� ���� ���·� ��ȯ�Ѵ�.
        else
        {
            m_state = EnemyState.Die;
            die();
            ScoreManager.AddScore(1); // ���ʹ� ������ Ȯ���� 1�� �߰�
        }
    }

    void die()
    {
        // ���� ���� �ǰ� �ڷ�ƾ�� �����Ѵ�.
        StopAllCoroutines();
        Destroy(gameObject);
    }

    


}
