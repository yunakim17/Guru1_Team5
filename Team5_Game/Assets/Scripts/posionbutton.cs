using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posionbutton : MonoBehaviour
{
    private bool hasUsedSpell5 = false;  // ��ٿ� ���� �� ���� ��� ������ �÷���

    // MagicCooldown ��ũ��Ʈ���� PlayerAttack �ν��Ͻ��� ���� ����
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��ٿ� ���� �� ���� ��� ������ ��쿡�� üũ
        if (!hasUsedSpell5 && playerAttack.magicool_1)
        {
            UseSpell5();

        }
    }

    public void UseSpell5()
    {
        Player playerScript = FindObjectOfType<Player>();
        playerScript.hp += 25;
        hasUsedSpell5 = true;  // �� �� ����� �Ŀ��� �ٽ� ������� ���ϵ��� �÷��� ����

    }
}
