using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] private int HitPoints = 5;
    [SerializeField] private int StaminaPoints = 5;
    [SerializeField] private GameObject punchHitBox;
    [SerializeField] private GameObject[] specialHitBoxes;
    [SerializeField] private int[] specialStaminaCosts;

    private int maxHP;
    private int maxSP;
    private int SpecialID;

    public bool _canPunch;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = HitPoints;
        maxSP = StaminaPoints;
        SpecialID = 0;
        _canPunch = true;
        punchHitBox.GetComponent<HitBox>().donoOw = this.gameObject;
        for(int i = 0; i < specialHitBoxes.Length; i++)
        {
            specialHitBoxes[i].GetComponent<HitBox>().donoOw = this.gameObject;
        }
        if(specialHitBoxes.Length != specialStaminaCosts.Length)
        {
            Debug.LogError("Erro nas Hitboxes: indices diferentes");
        }
        //Debug.Log(maxSpecial);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _canPunch) //Punch
        {
            AttackPunch();
            _canPunch = false;
        }
        if(Input.GetKeyDown(KeyCode.Q) && _canPunch) //Special
        {
            if (specialStaminaCosts[SpecialID] <= StaminaPoints)
            {
                SpecialAttack();
                _canPunch = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) //Change Special
        {
            SpecialID++;
            SpecialID = (SpecialID % specialHitBoxes.Length);
            Debug.Log("Atualmente: " + specialHitBoxes[SpecialID].name);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //TODO: Interact
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //TODO: Roll
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("HP: " + HitPoints + "/" + maxHP + " || " + "SP: " + StaminaPoints + "/" + maxSP);
        }
    }

    #region Damage
    public void Damage()
    {
        if (HitPoints > 0)
        {
            HitPoints -= 1;
        }
        if(HitPoints <= 0)
        {
            Debug.Log("Morreu");
            //TODO: Reset
        }
        //Debug.Log("HP: " + HitPoints);
    }

    public void DamageAmount(int amount)
    {
        if (HitPoints > 0)
        {
            HitPoints -= amount;
        }
        if (HitPoints <= 0)
        {
            Debug.Log("Morreu");
            //TODO: Reset
        }
    }
    #endregion

    #region Attacks
    private void AttackPunch()
    {
        punchHitBox.SetActive(true);
        HitBox tmp = punchHitBox.GetComponent<HitBox>();
        tmp.EndAttack();
    }
    private void SpecialAttack()
    {
        SpendStamina();
        specialHitBoxes[SpecialID].SetActive(true);
        HitBox tmp = specialHitBoxes[SpecialID].GetComponent<HitBox>();
        tmp.EndAttack();
    }
    #endregion
    private void SpendStamina()
    {
        StaminaPoints -= specialStaminaCosts[SpecialID];

        if(StaminaPoints < 0) StaminaPoints = 0;
    }
}
