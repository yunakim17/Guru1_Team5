using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicCooldown4 : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown3;
    [SerializeField]
    private TMP_Text textCooldown3;

    [SerializeField]
    public bool isCooldown3 = true;
    [SerializeField]
    private float cooldownTime3 = 3.0f;
    private float cooldownTimer3 = 0.0f;

    // MagicCooldown 스크립트에서 PlayerAttack 인스턴스를 받을 변수
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        textCooldown3.gameObject.SetActive(false);
        imageCooldown3.fillAmount = 0;

        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown3)
        {
            ApplyCooldown1();
        }
    }

    public void ApplyCooldown1()
    {
        cooldownTimer3 -= Time.deltaTime;

        if (cooldownTimer3 < 0.0f)
        {
            isCooldown3 = false;
            textCooldown3.gameObject.SetActive(false);
            imageCooldown3.fillAmount = 0.0f;

            PlayerAttack playeAttackrScript = GetComponent<PlayerAttack>();

            if (playeAttackrScript.magicool_1 == true)
            {
                UseSpell3();
                playeAttackrScript.magicool_1 = false;
            }

        }
        else
        {
            textCooldown3.text = Mathf.RoundToInt(cooldownTimer3).ToString();
            imageCooldown3.fillAmount = cooldownTimer3 / cooldownTime3;
        }
    }

    public void UseSpell3()
    {
        if (isCooldown3)
        {
            //스펠사용

        }
        else
        {
            isCooldown3 = true;
            textCooldown3.gameObject.SetActive(true);
            cooldownTimer3 = cooldownTime3;

        }
    }
}