﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StruggleManager_C : MonoBehaviour {

    private CombatManager combatController;
    public GameObject canvas;

    public GameObject player;
    public GameObject enemy;
    public GameObject struggleButton_L;
    public GameObject struggleButton_R;
    public GameObject struggle_Counter;
    public GameObject camera;
    public GameObject effectClone;
    public float readySize, pressedSize;
    public Color origColor, pressedColor;
    [HideInInspector]
    public int goal = 50;

    private int BASE_PRESS_COUNT = 250;

    public GameObject hitEffect;
    public GameObject blood01_FX;
    public GameObject blood02_FX;
    public GameObject blood03_FX;
    public GameObject blood04_FX;

    public GameObject struggleFuseHandle;

    public GameObject sparks;
    private GameObject sparkClone;

    private float HARD_MODE_FAIL = 0.11f;
    private float NORMAL_MODE_FAIL = 0.22f;
    private float EASY_MODE_FAIL = 0.35f;
    private float currentMode;

    //player vars
    private Vector3 playerOrig;
    private Vector3 playerMax = new Vector3(-475, 138, 0);
    private Vector3 playerMin = new Vector3(-765, 138, 0);
    private Vector3 playerStrugglePos = new Vector3(-530, 138, 0);
    private Vector3 playerCenter = Vector3.zero;
    //enemy vars
    private Vector3 enemyOrig;
    private Vector3 enemyMax = new Vector3(-468, 160, 0);
    private Vector3 enemyMin = new Vector3(-335, 160, 0);
    private Vector3 enemyStrugglePos = new Vector3(-390, 160, 0);
    private Vector3 enemyCenter = Vector3.zero;

    private Vector3 origCameraPos;
    private Vector3 effectPos;
    private Vector3 offsetVec;

    private int strugglePressCounter = 0;
    bool struggling_Player = false;
    float percentCompleted = 0;
    float randomVar = 0;
    int frameTracker = 0;
    float timeOutTracker = 0;
    float failTime = 0;
    int failScale = 10;
    bool playerCanFail = true;
    int enemyLevel = 1;

    bool LeftKeyReady = true;
    bool RightKeyReady = true;
    Coroutine randoMovementRoutine;
    float percHealthRemaining;
    private Vector3 fuseStart;
    private Vector3 fuseEnd;

    // Use this for initialization
    void Start ()
    {
        player = GameController.controller.playerObject;

        combatController = this.GetComponent<CombatManager>();
        playerOrig = player.transform.position;
        enemyOrig = enemy.transform.position;
        origCameraPos = camera.transform.position;
        effectPos = enemy.transform.GetChild(0).transform.GetChild(0).transform.position;
        disableStruggleButtons();
        struggle_Counter.GetComponent<Text>().enabled = false;
        fuseStart = new Vector3(-190, 0, 0);
        fuseEnd = new Vector3(190, 0, 0);
        currentMode = HARD_MODE_FAIL; //CHANGE THE THE MODE LATER!

        if(combatController.enemyInfo != null)
            enemyLevel = combatController.enemyInfo.enemyLevel;

        struggleFuseHandle.SetActive(false);
    } 
	
    public void ForceExecute()
    {
        StartCoroutine(ExecuteEnemy());
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		if(struggling_Player)
        {
            ++frameTracker;
            timeOutTracker += Time.deltaTime;

            //Player failed to finish the execution
            if(timeOutTracker >= failTime)
            {
                if (playerCanFail)
                {
                    percentCompleted = 0;
                    timeOutTracker = 0;
                    failTime = 0;
                    struggling_Player = false;
                    strugglePressCounter = 0;

                    StartCoroutine(StruggleFailed());
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightButtonPressed();
            }

            percentCompleted = (float)strugglePressCounter / goal;

            if(percentCompleted >= 0.99f)
            {
                percentCompleted = 0;
                timeOutTracker = 0;
                failTime = 0;
                struggling_Player = false;

                StartCoroutine(ExecuteEnemy());
            }

            randomVar = Random.Range(-1.0f, 1.0f);

            // randomly decide to move characters
            if(randomVar >= 0.75f)
            {
                //Randomly have them lerp back and forth
                RandomlyMoveCharacters();
            }

            playerCenter = Vector3.Lerp(playerStrugglePos, playerMax, percentCompleted);
            enemyCenter = Vector3.Lerp(enemyStrugglePos, enemyMin, percentCompleted);

            //UPDATE FUSE
            struggleFuseHandle.transform.GetChild(1).GetComponent<Image>().fillAmount = percentCompleted;
            struggleFuseHandle.transform.GetChild(2).transform.localPosition = Vector3.Lerp(fuseStart, fuseEnd, percentCompleted);
        }
	}

    public void RandomlyMoveCharacters()
    {
        offsetVec = new Vector3(randomVar * 35, 0, 0);
        player.GetComponent<LerpScript>().LerpToPos(playerCenter, playerCenter + offsetVec, Mathf.Abs(randomVar));
        enemy.GetComponent<LerpScript>().LerpToPos(enemyCenter, enemyCenter + offsetVec, Mathf.Abs(randomVar));
    }

    public void rightButtonPressed()
    {
        ++strugglePressCounter;
        struggle_Counter.GetComponent<Text>().text = strugglePressCounter.ToString();

        struggleButton_R.transform.localScale = new Vector3(pressedSize, pressedSize, 1);
        struggleButton_R.GetComponent<Image>().color = pressedColor;

        this.GetComponent<CombatAudio>().playRandomStrugglePress();

        Invoke("restoreRight", 0.05f);
    }

    public void restoreRight()
    {
        struggleButton_R.transform.localScale = new Vector3(readySize, readySize, 1);
        struggleButton_R.GetComponent<Button>().enabled = true;
        struggleButton_R.GetComponent<Image>().color = origColor;
    }

    public void leftButtonPressed()
    {
        ++strugglePressCounter;
        struggle_Counter.GetComponent<Text>().text = strugglePressCounter.ToString();

        struggleButton_L.transform.localScale = new Vector3(pressedSize, pressedSize, 1);
        struggleButton_L.GetComponent<Image>().color = pressedColor;

        this.GetComponent<CombatAudio>().playRandomStrugglePress();

        Invoke("restoreLeft", 0.05f);
    }

    public void restoreLeft()
    {
        struggleButton_L.transform.localScale = new Vector3(readySize, readySize, 1);
        struggleButton_L.GetComponent<Button>().enabled = true;
        struggleButton_L.GetComponent<Image>().color = origColor;
    }

    //IGNITE THE SPARK
    public void BeginStruggle_Player(float percentHealthRemaining, bool canFail = true)
    {
        percHealthRemaining = percentHealthRemaining;
        playerCanFail = canFail;

        failScale += GameController.controller.playerProwess;
        int rand = Random.Range(1, 5);
        int lvDiff = GameController.controller.playerLevel - enemyLevel;
        goal = (int)(((float)BASE_PRESS_COUNT * percHealthRemaining) + enemyLevel + (rand * -lvDiff));
        print("base: " + ((float)BASE_PRESS_COUNT * percHealthRemaining));
        goal -= GameController.controller.playerProwess;
        print("goal: " + goal);
        print("prowess: " + GameController.controller.playerProwess);

        failTime = (float)goal * currentMode;
        failTime -= 3 * percHealthRemaining;
        print("first: " + ((float)goal * currentMode));
        print("failTime: " + failTime);

        StartCoroutine(AlignCharacters(1.0f / failTime));
    }

    //ANIMATE CHARACTERS STRUGGLING
    IEnumerator AlignCharacters(float cameraTime)
    {
        player.GetComponent<LerpScript>().LerpToPos(playerOrig, playerStrugglePos, 2);
        player.GetComponent<AnimationController>().PlayStruggleHoldAnim();
        enemy.GetComponent<LerpScript>().LerpToPos(enemyOrig, enemyStrugglePos, 2);
        camera.GetComponent<CameraController>().LerpCameraSize(150, 125, 1);
        camera.GetComponent<LerpScript>().LerpToPos(origCameraPos, origCameraPos + new Vector3(10,-5,0), 2);
        yield return new WaitForSeconds(0.5f);
        sparkClone = (GameObject)Instantiate(sparks, Vector3.zero, transform.rotation);
        sparkClone.transform.SetParent(player.transform);
        sparkClone.transform.localPosition = new Vector3(8, 2, 0);
        yield return new WaitForSeconds(0.5f);
        enableStruggleButtons();
        struggle_Counter.GetComponent<Text>().enabled = true;
        struggling_Player = true;
        camera.GetComponent<CameraController>().LerpCameraSize(125, 100, cameraTime);
        struggleFuseHandle.SetActive(true);
    }

    IEnumerator ExecuteEnemy()
    {
        percentCompleted = 0;
        strugglePressCounter = 0;
        disableStruggleButtons();
        struggle_Counter.GetComponent<Text>().enabled = false;
        struggleButton_L.transform.localScale = new Vector3(1, 1, 1);
        struggleButton_L.GetComponent<Image>().color = origColor;
        struggleButton_R.transform.localScale = new Vector3(1, 1, 1);
        struggleButton_R.GetComponent<Image>().color = origColor;

        //UPDATE FUSE
        struggleFuseHandle.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        struggleFuseHandle.transform.GetChild(2).transform.localPosition = fuseStart;
        struggleFuseHandle.SetActive(false);
        Destroy(sparkClone);

        yield return new WaitForSeconds(0.5f);
        player.GetComponent<AnimationController>().PlayAttackAnim();
        this.GetComponent<CombatAudio>().playStrikeHit();
        yield return new WaitForSeconds(0.1f);
        Vector3 spawnPos = new Vector3(player.transform.position.x + 150, player.transform.position.y, 0);
        effectClone = (GameObject)Instantiate(hitEffect, spawnPos, transform.rotation);
        yield return new WaitForSeconds(0.15f);
        this.GetComponent<CombatAudio>().playBloodSplatter();
        //this.GetComponent<EnemyCombatScript>().PlayDeathAnim();
        //play execution anim
        //yield return new WaitForSeconds(0.75f);
        this.GetComponent<CombatManager>().ExecuteEnemy_Strike();
        yield return new WaitForSeconds(0.75f);
        camera.GetComponent<CameraController>().LerpCameraSize(100, 150, 3);
        camera.GetComponent<LerpScript>().LerpToPos(camera.transform.position, origCameraPos, 3.0f);
        player.GetComponent<LerpScript>().LerpToPos(player.transform.position, playerOrig, 3);
        enemy.GetComponent<LerpScript>().LerpToPos(enemy.transform.position, enemyOrig, 3);
        enemy.GetComponent<LerpScript>().LerpToColor(origColor, Color.clear, 1.5f);

        if(!playerCanFail)
            this.GetComponent<TutorialManager02_C>().StruggleFinished();
    }

    IEnumerator StruggleFailed()
    {
        percentCompleted = 0;
        strugglePressCounter = 0;
        disableStruggleButtons();
        struggle_Counter.GetComponent<Text>().enabled = false;
        struggleButton_L.transform.localScale = new Vector3(1, 1, 1);
        struggleButton_L.GetComponent<Image>().color = origColor;
        struggleButton_R.transform.localScale = new Vector3(1, 1, 1);
        struggleButton_R.GetComponent<Image>().color = origColor;

        //UPDATE FUSE
        struggleFuseHandle.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        struggleFuseHandle.transform.GetChild(2).transform.localPosition = fuseStart;
        struggleFuseHandle.SetActive(false);
        Destroy(sparkClone);

        player.GetComponent<LerpScript>().LerpToPos(player.transform.position, playerOrig, 3);
        player.GetComponent<AnimationController>().PlayIdleAnim();
        enemy.GetComponent<LerpScript>().LerpToPos(enemy.transform.position, enemyOrig, 3);
        camera.GetComponent<CameraController>().LerpCameraSize(100, 150, 3);
        yield return new WaitForSeconds(1f);
        combatController.StruggleFailed(true);
    }

    void enableStruggleButtons()
    {
        struggleButton_L.GetComponent<Button>().enabled = true;
        struggleButton_L.GetComponent<Image>().enabled = true;

        struggleButton_R.GetComponent<Button>().enabled = true;
        struggleButton_R.GetComponent<Image>().enabled = true;
    }

    void disableStruggleButtons()
    {
        struggleButton_L.GetComponent<Button>().enabled = false;
        struggleButton_L.GetComponent<Image>().enabled = false;

        struggleButton_R.GetComponent<Button>().enabled = false;
        struggleButton_R.GetComponent<Image>().enabled = false;
    }
}
