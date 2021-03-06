﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityManager_C : MonoBehaviour
{
    private CombatManager combatManager;
    public GameObject enemyMannequinn;
    public GameObject playerMannequin;
    public GameObject boostHandle;

    public GameObject boostPrefab;

    public GameObject lightningBlue_FX;
    public GameObject lightningYellow_FX;
    public GameObject lightningStatic_FX;
    public GameObject lightningYellowBurst_FX;
    public GameObject lightningBigBurst_FX;
    public GameObject rush_FX;

    public GameObject outrage_FX;
    public GameObject solarFlare_FX;
    public GameObject illusion_FX;
    public GameObject reap_FX;
    public GameObject finalCut_FX;
    public GameObject blackRain_FX;

    private Vector3 initEnemyPos;
    private Vector3 initPlayerPos;

    private int origPlayerHP, damageReturn;

    // Use this for initialization
    void Start()
    {
        playerMannequin = GameController.controller.playerObject;
        initPlayerPos = playerMannequin.transform.position;
        initEnemyPos = enemyMannequinn.transform.position;
        combatManager = this.GetComponent<CombatManager>();
    }

    //ENEMY TURN SEQUENCE
    //1. check for special case due to player ability
    //2. check for special case due to enemy ability
    //3. roll accuracy
    //4. buff
    //5. calculate damage
    //6. play animation
    //7. deal damage
    //8. end turn


    public void SetupSelectedAbility(Ability abilityUsed, int playerHP)
    {
        origPlayerHP = playerHP;
        damageReturn = 0;

        StartCoroutine(AnimateAbility(abilityUsed));
    }

    IEnumerator AnimateAbility(Ability ability)
    {
        string abilityName = ability.Name;
        GameObject effectClone;
        Vector3 spawnPos = Vector3.zero;
        print(abilityName + " was used");
        switch (abilityName)
        {
            case "Hatred":
                spawnPos = initEnemyPos + new Vector3(0, 80, 0);
                effectClone = (GameObject)Instantiate(outrage_FX, spawnPos, transform.rotation);
                this.GetComponent<CombatAudio>().playOutrageSFX();
                yield return new WaitForSeconds(0.25f);
                StartCoroutine(AttackBoostAnim(ability.AttackBoost, ability.AttBoostDuration));
                yield return new WaitForSeconds(2f);
                break;
            case "Thunder Charge":
                int dieRoll = Random.Range(0, 99);
                float chance = (50f + (combatManager.enemyInfo.enemyAttack - GameController.controller.playerDefense));
                chance = Mathf.Clamp(chance, 50f, 100f);
                this.GetComponent<CombatAudio>().playThunderChargeFX();
                effectClone = (GameObject)Instantiate(lightningBlue_FX, initEnemyPos + new Vector3(0, 10, 0), transform.rotation);
                effectClone.GetComponent<SpriteRenderer>().color = GameController.controller.getPlayerColorPreference();
                GameObject effectClone02 = (GameObject)Instantiate(lightningYellow_FX, initEnemyPos + new Vector3(10, 40, 0), transform.rotation);
                GameObject effectClone03 = (GameObject)Instantiate(lightningYellow_FX, initEnemyPos + new Vector3(-10, 40, 0), transform.rotation);
                effectClone03.GetComponent<SpriteRenderer>().flipX = true;
                yield return new WaitForSeconds(1.4f);
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                GameObject effectClone04 = (GameObject)Instantiate(lightningYellow_FX, initEnemyPos - new Vector3(250, -40, 0), transform.rotation);
                effectClone04.transform.eulerAngles = new Vector3(0, 0, -90);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(initEnemyPos, initEnemyPos - new Vector3(420, 0, 0), 5);
                yield return new WaitForSeconds(1f);
                if (chance > dieRoll)
                {
                    combatManager.currSpecialCase = SpecialCase.StunFoe;
                    effectClone = (GameObject)Instantiate(lightningBigBurst_FX, initPlayerPos + new Vector3(0, 10, 0), transform.rotation);
                }
                yield return new WaitForSeconds(0.75f);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos, 2);
                yield return new WaitForSeconds(0.75f);
                break;
            case "Guard Break":
                dieRoll = Random.Range(0, 99);
                chance = (85f + (combatManager.enemyInfo.enemyProwess - GameController.controller.playerDefense));
                chance = Mathf.Clamp(chance, 85f, 100f);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos - new Vector3(-40, 0, 0), 2);
                yield return new WaitForSeconds(0.2f);
                effectClone = (GameObject)Instantiate(rush_FX, enemyMannequinn.transform.position + new Vector3(-15, 5, 0), transform.rotation);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos - new Vector3(350, 0, 0), 3);
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                yield return new WaitForSeconds(0.65f);
                print("chance: " + chance);
                print("roll: " + dieRoll);
                if (chance > dieRoll)
                {
                    combatManager.currSpecialCase = SpecialCase.StunFoe;
                    combatManager.playerVulnernable = true;
                    effectClone = (GameObject)Instantiate(lightningBigBurst_FX, initPlayerPos + new Vector3(0, 10, 0), transform.rotation);
                }
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos, 3);
                yield return new WaitForSeconds(1);
                break;
            case "Black Rain":
                spawnPos = initEnemyPos + new Vector3(-15, 80, 0);
                yield return new WaitForSeconds(0.25f);
                effectClone = (GameObject)Instantiate(blackRain_FX, spawnPos, transform.rotation);
                effectClone.GetComponent<SpriteRenderer>().flipX = true;
                //this.GetComponent<CombatAudio>().playOutrageSFX();
                yield return new WaitForSeconds(0.35f);
                damageReturn = combatManager.DamagePlayer_Ability(ability);
                effectClone.GetComponent<Animator>().speed = 0.0f;
                yield return new WaitForSeconds(0.75f);
                effectClone.GetComponent<Animator>().speed = 1.45f;
                yield return new WaitForSeconds(0.25f);
                effectClone.transform.position += new Vector3(-120, -60, 0);
                yield return new WaitForSeconds(1);
                break;
            case "Outrage":
                spawnPos = initEnemyPos - new Vector3(0, 80, 0);
                effectClone = (GameObject)Instantiate(outrage_FX, initEnemyPos - new Vector3(250,-50,0), transform.rotation);
                effectClone.GetComponent<SpriteRenderer>().flipX = false;
                yield return new WaitForSeconds(0.25f);
                combatManager.currSpecialCase = SpecialCase.Outrage;
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                yield return new WaitForSeconds(1);
                break;
            case "Deceive":
                spawnPos = initEnemyPos - new Vector3(0, 60, 0);
                effectClone = (GameObject)Instantiate(illusion_FX, spawnPos, transform.rotation);
                combatManager.currSpecialCase = SpecialCase.Deceive;
                yield return new WaitForSeconds(0.85f);
                break;
            case "Solar Flare":
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, enemyMannequinn.transform.position + new Vector3(-100, 0, 0), 3);
                yield return new WaitForSeconds(0.35f);
                spawnPos = initPlayerPos + new Vector3(0, 0, 0);
                effectClone = (GameObject)Instantiate(solarFlare_FX, spawnPos, transform.rotation);
                effectClone.transform.parent = enemyMannequinn.transform;
                effectClone.GetComponent<SpriteRenderer>().flipX = true;
                effectClone.transform.localPosition += new Vector3(-35,40,0);
                yield return new WaitForSeconds(0.75f);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, enemyMannequinn.transform.position - new Vector3(300, 0, 0), 5);
                yield return new WaitForSeconds(0.25f);
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                yield return new WaitForSeconds(0.7f);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos, 3);
                yield return new WaitForSeconds(0.85f);
                break;
            case "Reap":
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(initEnemyPos, enemyMannequinn.transform.position + new Vector3(100, 0, 0), 3);
                yield return new WaitForSeconds(0.25f);
                spawnPos = initEnemyPos + new Vector3(0, 0, 0);
                effectClone = (GameObject)Instantiate(reap_FX, spawnPos, transform.rotation);
                effectClone.transform.parent = enemyMannequinn.transform;
                effectClone.GetComponent<SpriteRenderer>().flipX = false;
                effectClone.transform.position -= new Vector3(80,-30,0);
                combatManager.GetComponent<CombatAudio>().playShadowVanish();
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos - new Vector3(300, 0, 0), 5);
                yield return new WaitForSeconds(0.25f);
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                yield return new WaitForSeconds(0.7f);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos, 3);
                yield return new WaitForSeconds(0.85f);
                break;
            case "Blade Storm":
                foreach (LerpScript script in enemyMannequinn.GetComponentsInChildren<LerpScript>())
                {
                    script.LerpToColor(Color.white, Color.clear, 5);
                }
                yield return new WaitForSeconds(0.5f);
                combatManager.GetComponent<CombatAudio>().playFinalCut();
                spawnPos = initPlayerPos + new Vector3(0, 0, 0);
                effectClone = (GameObject)Instantiate(finalCut_FX, spawnPos, transform.rotation);
                effectClone.transform.localScale = new Vector3(200, 200, 0);
                effectClone.transform.position = playerMannequin.transform.position + new Vector3(30, 30, 0);
                effectClone.GetComponent<SpriteRenderer>().flipX = false;
                yield return new WaitForSeconds(0.35f);
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                yield return new WaitForSeconds(1f);
                foreach (LerpScript script in enemyMannequinn.GetComponentsInChildren<LerpScript>())
                {
                    script.LerpToColor(Color.clear, Color.white, 5);
                }
                yield return new WaitForSeconds(0.85f);
                if (damageReturn != 0)
                    combatManager.UseMultiHit(false, ability);
                yield return new WaitForSeconds(0.85f);
                break;
            case "Murder-Stroke":
                combatManager.playerVulnernable = true;
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos - new Vector3(-40, 0, 0), 2);
                yield return new WaitForSeconds(0.2f);
                effectClone = (GameObject)Instantiate(rush_FX, enemyMannequinn.transform.position + new Vector3(-15, 5, 0), transform.rotation);
                effectClone.GetComponent<SpriteRenderer>().flipX = true;
                enemyMannequinn.transform.GetChild(0).GetComponent<EnemyMannequinController>().playAttackAnim();
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos - new Vector3(350, 0, 0), 3);
                damageReturn = this.GetComponent<CombatManager>().DamagePlayer_Ability(ability);
                yield return new WaitForSeconds(0.65f);
                effectClone = (GameObject)Instantiate(lightningBlue_FX, initPlayerPos + new Vector3(0, 10, 0), transform.rotation);
                enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos, 3);
                yield return new WaitForSeconds(1);
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(0.25f);
        FinishAbility(ability);
    }

    //Attack Boost
    IEnumerator AttackBoostAnim(int level, int duration)
    {
        combatManager.enemyAttackBoost = level;
        combatManager.setBoostDur("Attack", duration, false);

        GameObject effectClone = (GameObject)Instantiate(boostPrefab, initEnemyPos + new Vector3(-100, 100, 0), transform.rotation);
        effectClone.GetComponent<StatBoost_C>().boostType = BoostType.Attack;
        effectClone.GetComponent<StatBoost_C>().player = -1;
        yield return new WaitForSeconds(2.25f);
        boostHandle.transform.GetChild(0).GetComponent<LerpScript>().LerpToColor(Color.clear, Color.white, 2.5f);
    }

    //Defense Boost
    IEnumerator DefenseBoostAnim(int level, int duration)
    {
        combatManager.enemyDefenseBoost = level;
        combatManager.setBoostDur("Defense", duration, false);

        GameObject effectClone = (GameObject)Instantiate(boostPrefab, initEnemyPos + new Vector3(-100, 100, 0), transform.rotation);
        effectClone.GetComponent<StatBoost_C>().boostType = BoostType.Defense;
        effectClone.GetComponent<StatBoost_C>().player = -1;
        yield return new WaitForSeconds(2.25f);
        boostHandle.transform.GetChild(1).GetComponent<LerpScript>().LerpToColor(Color.clear, Color.white, 2.5f);
    }

    //Speed Boost
    IEnumerator SpeedBoostAnim(int level, int duration)
    {
        combatManager.enemySpeedBoost = level;
        combatManager.setBoostDur("Speed", duration, false);

        GameObject effectClone = (GameObject)Instantiate(boostPrefab, initEnemyPos + new Vector3(-100, 100, 0), transform.rotation);
        effectClone.GetComponent<StatBoost_C>().boostType = BoostType.Speed;
        effectClone.GetComponent<StatBoost_C>().player = -1;
        yield return new WaitForSeconds(2.25f);
        boostHandle.transform.GetChild(2).GetComponent<LerpScript>().LerpToColor(Color.clear, Color.white, 2.5f);
    }


    void FinishAbility(Ability ability)
    {
        switch (ability.Name)
        {
            case "Shadow Strike":
                break;
            case "Illusion":

                break;
            default:
                break;
        }

        // if the ability does damage, make sure to animate the damage
        if (ability.BaseDamage != 0)
            this.GetComponent<CombatManager>().EndEnemyTurn(damageReturn, origPlayerHP);
        else
            this.GetComponent<CombatManager>().EndEnemyTurn(0);
    }
}
