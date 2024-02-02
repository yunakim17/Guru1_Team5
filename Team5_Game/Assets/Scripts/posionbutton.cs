using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class posionbutton : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown5;
    [SerializeField]
    private TMP_Text textCooldown5;

    [SerializeField]
    public bool isCooldown5 = true;
    [SerializeField]
    private float cooldownTime5 = 6.0f;
    private float cooldownTimer5 = 0.0f;

    // MagicCooldown 스크립트에서 PlayerAttack 인스턴스를 받을 변수
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        textCooldown5.gameObject.SetActive(false);
        imageCooldown5.fillAmount = 0;

        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown5)
        {
            ApplyCooldown1();
        }
    }

    public void ApplyCooldown1()
    {
        cooldownTimer5 -= Time.deltaTime;

        if (cooldownTimer5 < 0.0f)
        {
            isCooldown5 = false;
            textCooldown5.gameObject.SetActive(false);
            imageCooldown5.fillAmount = 0.0f;

            PlayerAttack playeAttackrScript = GetComponent<PlayerAttack>();

            if (playeAttackrScript.magicool_1 == true)
            {
                UseSpell5();
                playeAttackrScript.magicool_1 = false;

            }

        }
        else
        {
            textCooldown5.text = Mathf.RoundToInt(cooldownTimer5).ToString();
            imageCooldown5.fillAmount = cooldownTimer5 / cooldownTime5;
        }
    }

    public void UseSpell5()
    {
        if (!isCooldown5)  // 쿨다운 중이 아닐 때만 사용
        {
            Player playerScript = FindObjectOfType<Player>();
            playerScript.hp += 25;

            isCooldown5 = true;
            textCooldown5.gameObject.SetActive(true);
            cooldownTimer5 = cooldownTime5;
        }
    }

}