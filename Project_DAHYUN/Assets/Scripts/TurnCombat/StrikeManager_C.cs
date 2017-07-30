﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeManager_C : MonoBehaviour {

    public GameObject playerMannequin;
    public float strikeAnimDuration;
    private Vector3 initPlayerPos;
    private Vector2 strikeOffset = new Vector2(0f , 0f);
    private string strikeModifier;
    private GameObject effectClone;
    private int origEnemyHealth;

    //ASSETS
    public GameObject shadowStrike_FX;
    public GameObject seratedStrike_FX;

    // Use this for initialization
    void Start ()
    {
        initPlayerPos = playerMannequin.transform.position;
	}
	
    public void StrikeUsed(string strikeMod, int originalEnemyHP)
    {
        strikeModifier = strikeMod;
        origEnemyHealth = originalEnemyHP;

        if (strikeModifier == "none")
        {

        }
        else if(strikeModifier == "Shadow Strike")
        {
            Vector2 FXoffset = new Vector2(0, 20);
            Vector3 spawnPos = new Vector3(initPlayerPos.x + FXoffset.x, initPlayerPos.y + FXoffset.y, 0);
            effectClone = (GameObject)Instantiate(shadowStrike_FX, spawnPos, transform.rotation);
            effectClone.transform.parent = playerMannequin.transform;
            effectClone.GetComponent<Animator>().enabled = false;
            effectClone.GetComponent<SpriteRenderer>().enabled = false;
            //animate player mannequin
            StartCoroutine(AnimatePlayerStrike());
        }
        else if (strikeModifier == "Serated Strike")
        {
            Vector2 FXoffset = new Vector2(150, 0);
            Vector3 spawnPos = new Vector3(initPlayerPos.x + FXoffset.x, initPlayerPos.y + FXoffset.y, 0);
            effectClone = (GameObject)Instantiate(seratedStrike_FX, spawnPos, transform.rotation);
            effectClone.transform.parent = playerMannequin.transform;
            //animate player mannequin
            StartCoroutine(AnimatePlayerStrike());
        }
    }

    IEnumerator AnimatePlayerStrike()
    {
        Vector3 pos1;
        Vector3 pos2;

        switch (strikeModifier)
        {
            case "Shadow Strike":
                pos1 = new Vector3(initPlayerPos.x + 275, initPlayerPos.y + 15, 0);
                playerMannequin.GetComponent<LerpScript>().LerpToPos(initPlayerPos, pos1, strikeAnimDuration / .05f);
                yield return new WaitForSeconds(0.1f);
                effectClone.GetComponent<Animator>().enabled = true;
                effectClone.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<CombatManager>().DamageEnemy_Strike();
                yield return new WaitForSeconds(0.8f);
                playerMannequin.GetComponent<LerpScript>().LerpToPos(pos1, initPlayerPos, strikeAnimDuration / .25f);
                break;
            case "Serated Strike":
                pos1 = new Vector3(15, initPlayerPos.y, 0);
                pos2 = new Vector3(150, initPlayerPos.y, 0);
                playerMannequin.GetComponent<LerpScript>().LerpToPos(initPlayerPos, pos1, strikeAnimDuration / .1f);
                yield return new WaitForSeconds(0.25f);
                playerMannequin.GetComponent<LerpScript>().LerpToPos(pos1, pos2, strikeAnimDuration / .25f);
                yield return new WaitForSeconds(0.25f);
                this.GetComponent<CombatManager>().DamageEnemy_Strike();
                yield return new WaitForSeconds(0.25f);
                playerMannequin.GetComponent<LerpScript>().LerpToPos(pos2, initPlayerPos, strikeAnimDuration / .25f);
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(0.5f);

        this.GetComponent<CombatManager>().EndPlayerTurn(true, origEnemyHealth);
    }
}
