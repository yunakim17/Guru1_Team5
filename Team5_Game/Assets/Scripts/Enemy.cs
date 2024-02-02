using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 350;

    int maxHp = 350;

    public Slider hpSlider;

    public float findDistance = 15f;

    Transform player;

    public float attackdistsnce = 2f;

    public float speed = 1f;

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

    public int attackpower1 = 15;

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

            Quaternion lookRotation = Quaternion.LookRotation(dir);
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // DungeonSkeleton_demo�� ȸ���� ����
            Transform dungeonSkeletonTransform = transform.Find("DungeonSkeleton_demo");
            if (dungeonSkeletonTransform != null)
            {
                dungeonSkeletonTransform.rotation = Quaternion.Euler(0, angle, 0);
            }

            cc.Move(dir * speed * Time.deltaTime);
            anim.SetBool("idleToWalk", true);
        }
        else
        {
            if (currentTime1 <= 0)  // ������ �κ�
            {
                m_state = EnemyState.Attack1;
                anim.SetBool("WalkToAttack", true);
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
            anim.SetBool("attackToWalk", true);
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
