using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Magic1;
    public GameObject Magic2;
    public GameObject Magic3;
    public GameObject Magic4;

    public float speed = 10;

    public Transform pos;

    public float cooltime1;
    public float curtime1;
    public float cooltime2;
    public float curtime2;
    public float cooltime3;
    public float curtime3;
    public float cooltime4;
    public float curtime4;

    public int MagicPower;

    public MagicCooldown magicCooldown;
    public MagicCooldown2 magicCooldown2;
    public MagicCooldown3 magicCooldown3;
    public MagicCooldown4 magicCooldown4;

    public bool magicool_1 = false;
    public bool magicool_2 = false;
    public bool magicool_3 = false;
    public bool magicool_4 = false;

    // Start is called before the first frame update
    void Start()
    {
        magicCooldown = FindObjectOfType<MagicCooldown>();
        magicCooldown2 = FindObjectOfType<MagicCooldown2>();
        magicCooldown3 = FindObjectOfType<MagicCooldown3>();
        magicCooldown4 = FindObjectOfType<MagicCooldown4>();
    }

    // Update is called once per frame
    void Update()
    {
        check1();
        check2();
        check3();
        check4();

        
    }

    void check1()
    {
        // ���� �ð��� ��Ÿ�Ӻ��� ������ ��Ÿ���� ����
        if (curtime1 > 0)
        {
            curtime1 -= Time.deltaTime;
        }
        // ��Ÿ���� 0 ������ ���� �߻�
        if (curtime1 <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireMagic1();
                // �߻� �Ŀ� ��Ÿ���� �ٽ� ����
                curtime1 = cooltime1;
            }
        }
    }

    void check2()
    {
        if (curtime2 > 0)
        {
            curtime2 -= Time.deltaTime;
        }
        if (curtime2 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //FireMagic2(); ���� ����
                curtime2 = cooltime2;
            }
        }
    }

    void check3()
    {
        if (curtime3 > 0)
        {
            curtime3 -= Time.deltaTime;
        }
        if (curtime3 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                FireMagic3();
                curtime3 = cooltime3;
            }
        }
    }

    void check4()
    {
        if (curtime4 > 0)
        {
            curtime4 -= Time.deltaTime;
        }
        if (curtime4 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FireMagic4();
                curtime4 = cooltime4;
            }
        }
    }

    public void FireMagic1()
    {
        //������ ����
        MagicPower = 8;

        // Magic1 �������� �����Ͽ� ����
        GameObject magic1 = Instantiate(Magic1, pos.position, Quaternion.identity);

        magicCooldown4.UseSpell3(); // MagicCooldown�� �޼��� ȣ��

        // Rigidbody ������Ʈ�� ������ �߰�
        Rigidbody magic1Rigidbody = magic1.GetComponent<Rigidbody>();
        if (magic1Rigidbody == null)
        {
            magic1Rigidbody = magic1.AddComponent<Rigidbody>();
        }

        // Magic ��ũ��Ʈ�� �����ͼ� ����
        Magic magicScript = magic1.GetComponent<Magic>();
        Player playerScript = GetComponent<Player>();

        if (magicScript != null)
        {
            // �÷��̾��� ������ ������ ����Ͽ� �ӵ� ����
            magic1Rigidbody.velocity = new Vector3(playerScript.direction, 0f, 0f) * speed;

            // ���� ������Ʈ Ȱ��ȭ
            magic1.SetActive(true);
        }
        else
        {
            Debug.LogError("Magic script not found on Magic1(Clone)!");
            Destroy(magic1);
        }

    }
    public void FireMagic2()
    {
        //������ ����

        GameObject magic2 = Instantiate(Magic2, pos.position, Quaternion.identity);
        magicCooldown3.UseSpell2();
        Rigidbody magic1Rigidbody = magic2.GetComponent<Rigidbody>();
        if (magic1Rigidbody == null)
        {
            magic1Rigidbody = magic2.AddComponent<Rigidbody>();
        }

        Magic magicScript = magic2.GetComponent<Magic>();
        Player playerScript = GetComponent<Player>();

        if (magicScript != null)
        {
            magic1Rigidbody.velocity = new Vector3(playerScript.direction, 0f, 0f) * speed;

            magic2.SetActive(true);
        }
        else
        {
            Debug.LogError("Magic script not found on Magic1(Clone)!");
            Destroy(magic2);
        }
    }
    public void FireMagic3()
    {
        //������ ����
        MagicPower = 12;

        GameObject magic3 = Instantiate(Magic3, pos.position, Quaternion.identity);
        magicCooldown2.UseSpell1();
        Rigidbody magic1Rigidbody = magic3.GetComponent<Rigidbody>();
        if (magic1Rigidbody == null)
        {
            magic1Rigidbody = magic3.AddComponent<Rigidbody>();
        }

        Magic magicScript = magic3.GetComponent<Magic>();
        Player playerScript = GetComponent<Player>();

        if (magicScript != null)
        {
            magic1Rigidbody.velocity = new Vector3(playerScript.direction, 0f, 0f) * speed;

            magic3.SetActive(true);
        }
        else
        {
            Debug.LogError("Magic script not found on Magic1(Clone)!");
            Destroy(magic3);
        }
    }

    public void FireMagic4()
    {
        //������ ����
        MagicPower = 20;

        GameObject magic4 = Instantiate(Magic4, pos.position, Quaternion.identity);

        magicCooldown.UseSpell(); // MagicCooldown�� �޼��� ȣ��

        Rigidbody magic1Rigidbody = magic4.GetComponent<Rigidbody>();
        if (magic1Rigidbody == null)
        {
            magic1Rigidbody = magic4.AddComponent<Rigidbody>();
        }

        Magic magicScript = magic4.GetComponent<Magic>();
        Player playerScript = GetComponent<Player>();

        if (magicScript != null)
        {
            magic1Rigidbody.velocity = new Vector3(playerScript.direction, 0f, 0f) * speed;

            magic4.SetActive(true);
        }
        else
        {
            Debug.LogError("Magic script not found on Magic1(Clone)!");
            Destroy(magic4);
        }
    }
}