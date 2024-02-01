using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 500;

    int maxHp = 500;

    public Slider hpSlider;

    public float findDistance = 15f;    //����

    //�÷��̾� Ʈ������ (�� �ִ°��� �𸣰���)
    Transform player;

    public float attackdistsnce = 1.5f;

    public float speed = 3f;

    CharacterController cc;

    enum EnemyState
    {
        Idle,
        Move,
        Attack1,
        Attack2,
        Attack3,
        Damaged,
        Die
    }

    EnemyState m_state;

    float currentTime1 = 0;
    float attackdelay1 = 2f;
    float currentTime2 = 0;
    float attackdelay2 = 2f;
    float currentTime3 = 0;
    float attackdelay3 = 2f;

    public int attackpower1 = 5;
    public int attackpower2 = 8;
    public int attackpower3 = 12;

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

            case EnemyState.Attack2:
                attack2();
                break;
            case EnemyState.Attack3:
                attack3();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
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
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                             new Vector3(player.position.x, 0, player.position.z)) > attackdistsnce)
        {
            Vector3 dir = (new Vector3(player.position.x, 0, player.position.z) -
                           new Vector3(transform.position.x, 0, transform.position.z)).normalized;

            cc.Move(dir * speed * Time.deltaTime);
        }
        else
        {
            m_state = EnemyState.Attack1;
            currentTime1 = attackdelay1;
        }
    }


    //void Idle()
    //{
    //    if(Vector3.Distance(transform.position, player.position)<findDistance)
    //    {
    //        m_state = EnemyState.Move;

    //    }
    //}

    //void move()
    //{
    //    if (Vector3.Distance(transform.position, player.position) > attackdistsnce)
    //    {

    //        Vector3 dir = (player.position - transform.position).normalized;

    //        cc.Move(dir * speed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        m_state = EnemyState.Attack1;   //����: ���ݹ���� �پ��ѵ� ��� �ؾ�����
    //        currentTime1 = attackdelay1;
    //    }
    //}

    void attack1()
    {
        // ������ �ð����� �÷��̾ �����Ѵ�.
        if (Vector3.Distance(transform.position, player.position) < attackdistsnce)
        {
            currentTime1 += Time.deltaTime;
            if (currentTime1 > attackdelay1)
            {
                player.GetComponent<Player>().DamageAction(attackpower1);
                
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

    void attack2()
    {
        if (Vector3.Distance(transform.position, player.position) < attackdistsnce)
        {
            currentTime2 += Time.deltaTime;
            if (currentTime2 > attackdelay2)
            {
                player.GetComponent<Player>().DamageAction(attackpower2);
                
                Debug.Log("���ʹ��� ����2");
                currentTime2 = 0;
            }
        }
        else
        {
            m_state = EnemyState.Move;
            currentTime2 = 0;
        }
    }

    void attack3()
    {
        if (Vector3.Distance(transform.position, player.position) < attackdistsnce)
        {
            currentTime3 += Time.deltaTime;
            if (currentTime3 > attackdelay3)
            {
                player.GetComponent<Player>().DamageAction(attackpower3);
                
                Debug.Log("���ʹ��� ����3");
                currentTime3 = 0;
            }
        }
        else
        {
            m_state = EnemyState.Move;
            currentTime3 = 0;
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
        cc.enabled = false;
    }

    


}
