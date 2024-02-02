using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 400;

    int maxHp = 400;

    public Slider hpSlider;

    public float findDistance = 15f;    //예시

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
        Attack2,
        Attack3,
        Damaged,
        Die
    }

    EnemyState m_state;

    float currentTime1 = 0;
    float attackdelay1 = 5f;
    float currentTime2 = 0;
    float attackdelay2 = 10f;
    float currentTime3 = 0;
    float attackdelay3 = 15f;

    public int attackpower1 = 5;
    public int attackpower2 = 6;
    public int attackpower3 = 9;

    // Start is called before the first frame update
    void Start()
    {
        m_state = EnemyState.Idle;
        
        //플레이어의 트렌스폼 컴포넌트를 받아오기
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

        Vector3 currentPosition = transform.position;

        // 높이가 -2.88 이하인 경우 0으로 설정
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
            if (currentTime1 <= 0)  // 수정된 부분
            {
                m_state = EnemyState.Attack1;
                currentTime1 = attackdelay1;
            }
            else if (currentTime2 <= 0)  // 수정된 부분
            {
                m_state = EnemyState.Attack2;
                currentTime2 = attackdelay2;
            }
            else if (currentTime3 <= 0)  // 수정된 부분
            {
                m_state = EnemyState.Attack3;
                currentTime3 = attackdelay3;
            }
        }

        // 각 공격 상태에서 currentTime 감소
        if (m_state == EnemyState.Attack1)
        {
            currentTime1 -= Time.deltaTime;
        }
        else if (m_state == EnemyState.Attack2)
        {
            currentTime2 -= Time.deltaTime;
        }
        else if (m_state == EnemyState.Attack3)
        {
            currentTime3 -= Time.deltaTime;
        }
    }


    void attack1()
    {
        // 일정한 시간마다 플레이어를 공격한다.
        if (Vector3.Distance(transform.position, player.position) < attackdistsnce)
        {
            currentTime1 += Time.deltaTime;
            if (currentTime1 > attackdelay1)
            {
                player.GetComponent<Player>().DamageAction(attackpower1);
                anim.SetBool("attack", true);
                Debug.Log("에너미의 공격1");
                currentTime1 = 0;
            }
        }
        //그렇지 않다면 현재 상태를 이동으로 전환한다.
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
                
                Debug.Log("에너미의 공격2");
                anim.SetBool("attack", true);
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
                anim.SetBool("attack", true);
                Debug.Log("에너미의 공격3");
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
        yield return new WaitForSeconds(0.5f);  //피격 모션 시간 만큼 기다림

        //현재 상태를 다시 이동 상태로 전환
        m_state = EnemyState.Move;
    }

    //데미지 실행 함수
    public void HitEnemy(int hitpower)
    {
        hp -= hitpower;

        if (hp > 0)
        {
            m_state = EnemyState.Damaged;
            Damaged();
        }
        // 그렇지 않다면 죽음 상태로 전환한다.
        else
        {
            m_state = EnemyState.Die;
            die();
            ScoreManager.AddScore(1); // 에너미 죽으면 확인증 1개 추가
        }
    }

    void die()
    {
        // 진행 중인 피격 코루틴을 중지한다.
        StopAllCoroutines();
        Destroy(gameObject);
    }

    


}
