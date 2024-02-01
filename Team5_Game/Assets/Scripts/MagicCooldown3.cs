using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicCooldown3 : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown2;
    [SerializeField]
    private TMP_Text textCooldown2;

    [SerializeField]
    public bool isCooldown2 = true;
    [SerializeField]
    private float cooldownTime2 = 5.0f;
    private float cooldownTimer2 = 0.0f;

    // MagicCooldown 스크립트에서 PlayerAttack 인스턴스를 받을 변수
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        textCooldown2.gameObject.SetActive(false);
        imageCooldown2.fillAmount = 0;

        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown2)
        {
            ApplyCooldown1();
        }
    }

    public void ApplyCooldown1()
    {
        cooldownTimer2 -= Time.deltaTime;

        if (cooldownTimer2 < 0.0f)
        {
            isCooldown2 = false;
            textCooldown2.gameObject.SetActive(false);
            imageCooldown2.fillAmount = 0.0f;

            PlayerAttack playeAttackrScript = GetComponent<PlayerAttack>();

            if (playeAttackrScript.magicool_1 == true)
            {
                UseSpell2();
                playeAttackrScript.magicool_1 = false;

                //회복 따로
                //Player playerScript = FindObjectOfType<Player>();
                //playerScript.hp += 20;
            }

        }
        else
        {
            textCooldown2.text = Mathf.RoundToInt(cooldownTimer2).ToString();
            imageCooldown2.fillAmount = cooldownTimer2 / cooldownTime2;
        }
    }

    public void UseSpell2()
    {
        if (isCooldown2)
        {
            //스펠사용

        }
        else
        {
            isCooldown2 = true;
            textCooldown2.gameObject.SetActive(true);
            cooldownTimer2 = cooldownTime2;

        }
    }
}