using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicCooldown2 : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown1;
    [SerializeField]
    private TMP_Text textCooldown1;

    [SerializeField]
    public bool isCooldown1 = true;
    [SerializeField]
    private float cooldownTime1 = 5.0f;
    private float cooldownTimer1 = 0.0f;

    // MagicCooldown 스크립트에서 PlayerAttack 인스턴스를 받을 변수
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        textCooldown1.gameObject.SetActive(false);
        imageCooldown1.fillAmount = 0;

        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown1)
        {
            ApplyCooldown1();
        }
    }

    public void ApplyCooldown1()
    {
        cooldownTimer1 -= Time.deltaTime;

        if (cooldownTimer1 < 0.0f)
        {
            isCooldown1 = false;
            textCooldown1.gameObject.SetActive(false);
            imageCooldown1.fillAmount = 0.0f;

            PlayerAttack playeAttackrScript = GetComponent<PlayerAttack>();

            if (playeAttackrScript.magicool_1 == true)
            {
                UseSpell1();
                playeAttackrScript.magicool_1 = false;
            }

        }
        else
        {
            textCooldown1.text = Mathf.RoundToInt(cooldownTimer1).ToString();
            imageCooldown1.fillAmount = cooldownTimer1 / cooldownTime1;
        }
    }

    public void UseSpell1()
    {
        if (isCooldown1)
        {
            //스펠사용

        }
        else
        {
            isCooldown1 = true;
            textCooldown1.gameObject.SetActive(true);
            cooldownTimer1 = cooldownTime1;

        }
    }
}