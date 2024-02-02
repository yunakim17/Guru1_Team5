using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posionbutton : MonoBehaviour
{
    private bool hasUsedSpell5 = false;  // 쿨다운 없이 한 번만 사용 가능한 플래그

    // MagicCooldown 스크립트에서 PlayerAttack 인스턴스를 받을 변수
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        // 쿨다운 없이 한 번만 사용 가능한 경우에만 체크
        if (!hasUsedSpell5 && playerAttack.magicool_1)
        {
            UseSpell5();

        }
    }

    public void UseSpell5()
    {
        Player playerScript = FindObjectOfType<Player>();
        playerScript.hp += 25;
        hasUsedSpell5 = true;  // 한 번 사용한 후에는 다시 사용하지 못하도록 플래그 설정

    }
}
