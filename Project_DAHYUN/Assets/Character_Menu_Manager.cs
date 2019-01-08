﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Character_Menu_Manager : MonoBehaviour {

    //[HideInInspector]
    private Vector3 EQP_TAB_OFFSET = new Vector3(-83, 35, 0);

    // Holds all of the unlocked equipment information from the players saved file
    [HideInInspector]
    public bool[,] unlockedEquipment = new bool[32, 4];

    public GameObject playerMannequin;
    public GameObject equipmentSelectPopUpPrefab;
    private GameObject equipmentSelectPopUp;
    public GameObject inputDetector;
    public GameObject personaPanel;
    public GameObject auraColor;
    public GameObject background;
    public GameObject snapshotAnchor;
    public GameObject abilitySelectTab;
    public GameObject abilitySelecPrfb;
    public GameObject traitSelectTab;

    private bool personaPanelActive = false;
    private int actionPresses = 0;
    private bool readyForAction = true;

    public GameObject canvas;
    public GameObject camera;
    public GameObject blackSq;
    public Vector3 mmCameraPos;

    public GameObject slider1, slider2, slider3;

    //Spritesheets
    private Sprite[] spriteSheet_Head, spriteSheet_Torso, spriteSheet_Legs, spriteSheet_Back, spriteSheet_Gloves, spriteSheet_Shoes, spriteSheet_Weapon, spriteSheet_Aura;
    public Sprite lockedIcon;

    public GameObject[] equipmentOptions;
    public GameObject[] statText;

    public GameObject BackButton;
    public GameObject AbilitiesButton;
    public GameObject PersonaButton;
    public GameObject SkillsButton;

    private Vector3 skillStart;
    private Vector3 abilityStart;
    private Vector3 personaStart;
    private Vector3 auraStart;

    private string bodyHeadIdle = "Player_BodyHead_DefaultWhite_Idle";
    private string bodyTorsoIdle = "Player_BodyTorso_DefaultWhite_Idle";
    private string bodyArmsIdle = "Player_BodyArms_DefaultWhite_Idle";
    private string bodyGlovesIdle = "Player_BodyArms_DefaultWhite_Idle";

    private bool refreshing = false;
    private string currentTab = "";

    private int[] atk = new int[8];
    private int[] def = new int[8];
    private int[] spd = new int[8];
    private int[] prw = new int[8];

    EquipmentInfo info;

    public GameObject equipmentHandle;
    public GameObject mirrorCamera;

    public Color equipActive, equipInactive;

    private GameObject atk_text;
    private GameObject def_text;
    private GameObject prs_text;
    private GameObject spd_text;

    private int prevID_i, prevID_j;

    private void Awake()
    {
        //GameController.controller.playerEquippedIDs[0] = 0;
        //GameController.controller.playerEquippedIDs[1] = 0;
        //GameController.controller.playerEquippedIDs[2] = 4;
        //GameController.controller.playerEquippedIDs[3] = 0;
        //GameController.controller.playerEquippedIDs[4] = 8;
        //GameController.controller.playerEquippedIDs[5] = 0;
        //GameController.controller.playerEquippedIDs[6] = 12;
        //GameController.controller.playerEquippedIDs[7] = 0;
        //GameController.controller.playerEquippedIDs[8] = 16;
        //GameController.controller.playerEquippedIDs[9] = 0;
        //GameController.controller.playerEquippedIDs[10] = 20;
        //GameController.controller.playerEquippedIDs[11] = 0;
        //GameController.controller.playerEquippedIDs[12] = 24;
        //GameController.controller.playerEquippedIDs[13] = 0;
        //GameController.controller.playerEquippedIDs[14] = 28;
        //GameController.controller.playerEquippedIDs[15] = 0;

        if(GameController.controller.playerNumber != 0)
        {
            GameController.controller.Load(GameController.controller.charNames[GameController.controller.playerNumber]);
        }
        else
            GameController.controller.Load(GameController.controller.charNames[1]);
    }

    // Use this for initialization
    void Start()
    {
        playerMannequin = GameController.controller.playerObject;
        unlockedEquipment = GameController.controller.playerEquipmentList;

        abilityStart = AbilitiesButton.transform.position;
        skillStart = SkillsButton.transform.position;
        personaStart = PersonaButton.transform.position;
        auraStart =  auraColor.transform.position;

        //load in defaults for now : FIX THIS SHIT L8R
        unlockedEquipment[0, 0] = true;
        unlockedEquipment[0, 2] = true;
        unlockedEquipment[0, 3] = true;

        unlockedEquipment[4, 0] = true;
        unlockedEquipment[4, 2] = true;
        unlockedEquipment[4, 3] = true;

        unlockedEquipment[8, 0] = true;
        unlockedEquipment[8, 2] = true;
        unlockedEquipment[8, 3] = true;

        unlockedEquipment[12, 0] = true;
        unlockedEquipment[12, 2] = true;
        unlockedEquipment[12, 3] = true;

        unlockedEquipment[16, 0] = true;
        unlockedEquipment[16, 2] = true;
        unlockedEquipment[16, 3] = true;

        unlockedEquipment[20, 0] = true;
        unlockedEquipment[20, 2] = true;
        unlockedEquipment[20, 3] = true;

        unlockedEquipment[24, 0] = true;
        unlockedEquipment[24, 1] = true;
        unlockedEquipment[24, 2] = true;
        unlockedEquipment[24, 3] = true;
        unlockedEquipment[25, 0] = true;
        unlockedEquipment[25, 1] = false;

        unlockedEquipment[28, 0] = true;
        unlockedEquipment[28, 2] = true;

        spriteSheet_Head = Resources.LoadAll<Sprite>("IconSpritesheets\\Helmet_Spritesheet01");
        spriteSheet_Torso = Resources.LoadAll<Sprite>("IconSpritesheets\\Torso_Spritesheet01");
        spriteSheet_Legs = Resources.LoadAll<Sprite>("IconSpritesheets\\Legs_Spritesheet01");
        spriteSheet_Back = Resources.LoadAll<Sprite>("IconSpritesheets\\Back_Spritesheet01");
        spriteSheet_Gloves = Resources.LoadAll<Sprite>("IconSpritesheets\\Gloves_Spritesheet01");
        spriteSheet_Shoes = Resources.LoadAll<Sprite>("IconSpritesheets\\Shoes_Spritesheet01");
        spriteSheet_Weapon = Resources.LoadAll<Sprite>("IconSpritesheets\\Sword_Spritesheet01");
        spriteSheet_Aura = Resources.LoadAll<Sprite>("IconSpritesheets\\Spritesheet_Icons_Aura");

        background.GetComponent<SpriteRenderer>().color = GameController.controller.getPlayerColorPreference();

        LoadPersona();

        LoadEquipmentIcons();

        UnhighlightEquipment();
    }

    public void HideOtherTabs(string tab)
    {
        if(tab != currentTab)
        {
            float speed = 5.0f;
            currentTab = tab;

            switch (tab)
            {
                case "Abilities":
                    personaPanel.SetActive(false);
                    personaPanelActive = false;
                    traitSelectTab.SetActive(false);
                    AbilitiesButton.GetComponent<LerpScript>().LerpToPos(AbilitiesButton.transform.position, abilityStart, speed);
                    auraColor.GetComponent<LerpScript>().LerpToPos(auraColor.transform.position, auraStart + new Vector3(10, 0, 0), speed);
                    PersonaButton.GetComponent<LerpScript>().LerpToPos(PersonaButton.transform.position, personaStart + new Vector3(10, 0, 0), speed);
                    SkillsButton.GetComponent<LerpScript>().LerpToPos(SkillsButton.transform.position, skillStart + new Vector3(10, 0, 0), speed);
                    break;
                case "Traits":
                    abilitySelectTab.SetActive(false);
                    abilitySelecPrfb.SetActive(false);
                    personaPanel.SetActive(false);
                    personaPanelActive = false;
                    SkillsButton.GetComponent<LerpScript>().LerpToPos(SkillsButton.transform.position, skillStart, speed);

                    PersonaButton.GetComponent<LerpScript>().LerpToPos(PersonaButton.transform.position, personaStart + new Vector3(10, 0, 0), speed);
                    auraColor.GetComponent<LerpScript>().LerpToPos(auraColor.transform.position, auraStart + new Vector3(10, 0, 0), speed);
                    AbilitiesButton.GetComponent<LerpScript>().LerpToPos(AbilitiesButton.transform.position, abilityStart + new Vector3(10, 0, 0), speed);
                    break;
                case "Persona":
                    abilitySelectTab.SetActive(false);
                    abilitySelecPrfb.SetActive(false);
                    traitSelectTab.SetActive(false);
                    PersonaButton.GetComponent<LerpScript>().LerpToPos(PersonaButton.transform.position, personaStart, speed);
                    auraColor.GetComponent<LerpScript>().LerpToPos(auraColor.transform.position, auraStart, speed);

                    SkillsButton.GetComponent<LerpScript>().LerpToPos(SkillsButton.transform.position, skillStart + new Vector3(10, 0, 0), speed);
                    AbilitiesButton.GetComponent<LerpScript>().LerpToPos(AbilitiesButton.transform.position, abilityStart + new Vector3(10, 0, 0), speed);
                    break;
            }
        }
    }

    public void ShowAllTabs()
    {
        float speed = 20.0f;
        AbilitiesButton.GetComponent<LerpScript>().LerpToPos(AbilitiesButton.transform.position, abilityStart, speed);
        SkillsButton.GetComponent<LerpScript>().LerpToPos(SkillsButton.transform.position, skillStart, speed);
        PersonaButton.GetComponent<LerpScript>().LerpToPos(PersonaButton.transform.position, personaStart, speed);
        auraColor.GetComponent<LerpScript>().LerpToPos(auraColor.transform.position, auraStart, speed);
        currentTab = "None";
    }

    public void disablePersonaPanel()
    {
        personaPanelActive = false;
        personaPanel.gameObject.SetActive(false);
        //inputDetector.gameObject.SetActive(false);
    }

    public void togglePersonaPanel()
    {
        if (personaPanelActive)
        {
            personaPanelActive = false;
            personaPanel.gameObject.SetActive(false);
            //inputDetector.gameObject.SetActive(false);
        }
        else
        {
            personaPanelActive = true;
            personaPanel.gameObject.SetActive(true);
            //inputDetector.gameObject.SetActive(true);
        }
    }

    public void enableTraitsTab()
    {
        traitSelectTab.SetActive(true);
    }

    public void ActionPress()
    {
        if (actionPresses < 2)
        {
            ++actionPresses;
        }

        if (readyForAction && actionPresses > 0)
        {
            readyForAction = false;
            StartCoroutine(actionPressAnimation());
        }
    }

    IEnumerator actionPressAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        
        switch(actionPresses)
        {
            case 1:
                if(!playerMannequin.GetComponent<AnimationController>().InCombat)
                {
                    playerMannequin.GetComponent<AnimationController>().PlayCheerAnim(); // play cheer
                }
                else
                {
                    playerMannequin.GetComponent<AnimationController>().PlayAttackAnim();
                }
                break;
            case 2:
                if (playerMannequin.GetComponent<AnimationController>().InCombat)
                {
                    playerMannequin.GetComponent<AnimationController>().SetCombatState(false);
                }
                else
                {
                    playerMannequin.GetComponent<AnimationController>().SetCombatState(true);
                }
                break;
        }

        yield return new WaitForSeconds(1f);
        readyForAction = true;
        actionPresses = 0;
    }

    public void UpdateAuraColor(GameObject slider)
    {
        Color color = GameController.controller.getPlayerColorPreference();

        switch (slider.name)
        {
            case "Slider1": // R
                color.r = slider.GetComponent<Slider>().value;
                break;
            case "Slider2": // G
                color.g = slider.GetComponent<Slider>().value;
                break;
            case "Slider3": // B
                color.b = slider.GetComponent<Slider>().value;
                break;
        }
        
        auraColor.GetComponent<Image>().color = color;
        GameController.controller.setPlayerColorPreference(color);
        playerMannequin.GetComponent<AnimationController>().seteAuraColor(color);
        background.GetComponent<SpriteRenderer>().color = color;
        RefreshMaskColor();
    }

    public void RefreshMaskColor()
    {
        Color playerPref = GameController.controller.getPlayerColorPreference();
        foreach (GameObject mask in camera.GetComponent<CameraController>().GetMaskObjects())
        {
            mask.GetComponent<SpriteRenderer>().color = new Color(playerPref.r, playerPref.g, playerPref.b, 0.6f);
            mask.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(playerPref.r, playerPref.g, playerPref.b, 1.0f);
        }
    }

    // TODO: fix this for any other masks we want to add to the player
    public void UpdateMask(bool updateAll, string maskName = "weapon")
    {
        Color playerPref = GameController.controller.getPlayerColorPreference();
        if (updateAll)
        {
            //foreach(GameObject mask in camera.GetComponent<CameraController>().GetMaskObjects())
            //{
            //    mask.GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.maskSpriteName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
            //    mask.GetComponent<SpriteRenderer>().enabled = true;
            //    mask.GetComponent<SpriteRenderer>().color = new Color(playerPref.r, playerPref.g, playerPref.b, 0.6f);
            //    mask.GetComponent<SpriteMask>().enabled = true;
            //    mask.GetComponent<SpriteMaskAnimator>().setActive(true);
            //    mask.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = info.maskTexture;
            //    mask.transform.GetChild(0).GetComponent<SpriteRenderer>().color = info.equipmentColor;
            //}
        }
        else
        {
            switch(maskName)
            {
                case "weapon":
                    GameObject weaponMask = playerMannequin.transform.GetChild(6).GetChild(0).gameObject;
                    weaponMask.GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.maskSpriteName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    weaponMask.GetComponent<SpriteRenderer>().enabled = true;
                    weaponMask.GetComponent<SpriteRenderer>().color = new Color(playerPref.r, playerPref.g, playerPref.b, 0.6f);
                    weaponMask.GetComponent<SpriteMask>().enabled = true;
                    weaponMask.GetComponent<SpriteMaskAnimator>().setActive(true);
                    weaponMask.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = info.maskTexture;
                    weaponMask.transform.GetChild(0).GetComponent<SpriteRenderer>().color = info.equipmentColor;
                    break;
            }
        }
    }

    public void ButtonAuraColor(GameObject button)
    {
        Color color = button.GetComponent<Image>().color;

        slider1.GetComponent<Slider>().value = color.r;
        slider2.GetComponent<Slider>().value = color.g;
        slider3.GetComponent<Slider>().value = color.b;

        auraColor.GetComponent<Image>().color = color;
        GameController.controller.setPlayerColorPreference(color);
        playerMannequin.GetComponent<AnimationController>().seteAuraColor(color);
        background.GetComponent<SpriteRenderer>().color = color;
    }

    public void setAuraColor(GameObject obj)
    {
        Color color = obj.GetComponent<Image>().color;
        GameController.controller.setPlayerColorPreference(color);
        auraColor.GetComponent<Image>().color = color;
        playerMannequin.GetComponent<AnimationController>().seteAuraColor(color);
        background.GetComponent<SpriteRenderer>().color = GameController.controller.getPlayerColorPreference();
    }

    public void LoadAbilityScene()
    {
        StartCoroutine(GoToAbilityScreen());
    }

    IEnumerator GoToAbilityScreen()
    {
        blackSq.GetComponent<FadeScript>().FadeIn(2.0f);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("AbilitySelect_Scene");
    }

    public void RevertToPreviousEquip()
    {
        GameObject fakeBtn = null;
        HighlightEpqButton(fakeBtn, prevID_i, prevID_j);
    }

    public void ConfirmSelection()
    {
        UpdateStats();
        UnhighlightEquipment();
    }

    public void UpdateStats()
    {
        int statTotal;
        //Attack
        statTotal = GameController.controller.playerBaseAtk;
        for (int i = 0; i < 8; ++i)
        {
            statTotal += atk[i];
        }
        statText[0].GetComponent<Text>().text = statTotal.ToString();
        GameController.controller.playerAttack = statTotal;
        //Defense
        statTotal = GameController.controller.playerBaseDef;
        for (int i = 0; i < 8; ++i)
        {
            statTotal += def[i];
        }
        statText[1].GetComponent<Text>().text = statTotal.ToString();
        GameController.controller.playerDefense = statTotal;
        //Prowess
        statTotal = GameController.controller.playerBasePrw;
        for (int i = 0; i < 8; ++i)
        {
            statTotal += prw[i];
        }
        statText[2].GetComponent<Text>().text = statTotal.ToString();
        GameController.controller.playerProwess = statTotal;
        //Speed
        statTotal = GameController.controller.playerBaseSpd;
        for (int i = 0; i < 8; ++i)
        {
            statTotal += spd[i];
        }
        statText[3].GetComponent<Text>().text = statTotal.ToString();
        GameController.controller.playerSpeed = statTotal;
    }

    public void LoadPersona()
    {
        Color colorPref = GameController.controller.getPlayerColorPreference();
        Color playerSkin = GameController.controller.getPlayerSkinColor();

        for (int i = 8; i < 12; ++i)
        {
            playerMannequin.transform.GetChild(i).GetComponent<SpriteRenderer>().color = playerSkin;
        }

        auraColor.GetComponent<Image>().color = GameController.controller.getPlayerColorPreference();

        personaPanel.transform.GetChild(3).GetComponent<Slider>().value = colorPref.r;
        personaPanel.transform.GetChild(4).GetComponent<Slider>().value = colorPref.g;
        personaPanel.transform.GetChild(5).GetComponent<Slider>().value = colorPref.b;
    }

    public void HighlightEpqButton(GameObject button, int i, int j)
    {
        GameObject menuButton;
        int indexI = i;
        int indexJ = j;
        int sheetIndex = (4 * (indexI % 4)) + indexJ;

        info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i, j);
        string imageName = info.imgSourceName;
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;

        for (int k = 0; k < 2; ++k)
        {
            GameObject rowObject = grid.transform.GetChild(k).gameObject;

            //inner loop is always 4
            for (int l = 0; l < 4; ++l)
            {
                GameObject child = rowObject.transform.GetChild(l).gameObject;

                if(child == button)
                {
                    //EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 16, j);
                    child.transform.GetComponent<Image>().color = equipActive;
                }
                else
                {
                    child.transform.GetComponent<Image>().color = equipInactive;
                }
            }
        }

        //head
        if (indexI < 4)
        {
            menuButton = GameObject.Find("Head_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Head[(4 * indexI) + indexJ];

            playerMannequin.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
            print("HEAD IMAGE NAME = " + imageName);
            GameController.controller.playerEquippedIDs[0] = i;
            GameController.controller.playerEquippedIDs[1] = j;

            if (!info.hideUnderLayer)
                playerMannequin.transform.GetChild(8).GetComponent<SpriteRenderer>().enabled = true;
            else
                playerMannequin.transform.GetChild(8).GetComponent<SpriteRenderer>().enabled = false;

            atk[0] = info.AttackStat;
            def[0] = info.DefenseStat;
            prw[0] = info.ProwessStat;
            spd[0] = info.SpeedStat;
        }
        //torso
        else if (indexI < 8)
        {
            menuButton = GameObject.Find("Torso_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Torso[sheetIndex];
            playerMannequin.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            GameController.controller.playerEquippedIDs[2] = i;
            GameController.controller.playerEquippedIDs[3] = j;

            string newStr = imageName;
            string match = "Torso";
            string replace = "Arms";
            int mSize = 0;
            int tracker = 0;
            //Alters the form of the string to include the Arms animator with the Torso
            foreach (char c in imageName)
            {
                if (c == match[mSize])
                {
                    ++mSize;

                    if (mSize == 5)
                    {
                        newStr = newStr.Remove(tracker - 4, mSize);
                        newStr = newStr.Insert(tracker - 4, replace);
                        mSize = 0;
                        --tracker;
                    }
                }
                else
                    mSize = 0;

                ++tracker;
            }

            playerMannequin.transform.GetChild(7).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(newStr, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            if (!info.hideUnderLayer)
            {
                playerMannequin.transform.GetChild(9).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
                playerMannequin.transform.GetChild(9).GetComponent<SpriteRenderer>().enabled = false;

            atk[1] = info.AttackStat;
            def[1] = info.DefenseStat;
            prw[1] = info.ProwessStat;
            spd[1] = info.SpeedStat;
        }
        //legs
        else if (indexI < 12)
        {
            menuButton = GameObject.Find("Legs_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Legs[sheetIndex];
            playerMannequin.transform.GetChild(2).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            GameController.controller.playerEquippedIDs[4] = i;
            GameController.controller.playerEquippedIDs[5] = j;

            atk[2] = info.AttackStat;
            def[2] = info.DefenseStat;
            prw[2] = info.ProwessStat;
            spd[2] = info.SpeedStat;
        }
        //back
        else if (indexI < 16)
        {
            menuButton = GameObject.Find("Back_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Back[sheetIndex];
            playerMannequin.transform.GetChild(3).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            GameController.controller.playerEquippedIDs[6] = i;
            GameController.controller.playerEquippedIDs[7] = j;

            atk[3] = info.AttackStat;
            def[3] = info.DefenseStat;
            prw[3] = info.ProwessStat;
            spd[3] = info.SpeedStat;
        }
        //gloves
        else if (indexI < 20)
        {
            menuButton = GameObject.Find("Gloves_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Gloves[sheetIndex];
            playerMannequin.transform.GetChild(4).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            GameController.controller.playerEquippedIDs[8] = i;
            GameController.controller.playerEquippedIDs[9] = j;

            if (!info.hideUnderLayer)
            {
                playerMannequin.transform.GetChild(10).GetComponent<SpriteRenderer>().enabled = true;
                playerMannequin.transform.GetChild(11).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                playerMannequin.transform.GetChild(10).GetComponent<SpriteRenderer>().enabled = false;
                playerMannequin.transform.GetChild(11).GetComponent<SpriteRenderer>().enabled = false;
            }

            atk[4] = info.AttackStat;
            def[4] = info.DefenseStat;
            prw[4] = info.ProwessStat;
            spd[4] = info.SpeedStat;
        }
        //shoes
        else if (indexI < 24)
        {
            menuButton = GameObject.Find("Shoes_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Shoes[sheetIndex];
            playerMannequin.transform.GetChild(5).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            GameController.controller.playerEquippedIDs[10] = i;
            GameController.controller.playerEquippedIDs[11] = j;

            atk[5] = info.AttackStat;
            def[5] = info.DefenseStat;
            prw[5] = info.ProwessStat;
            spd[5] = info.SpeedStat;
        }
        //weapon
        else if (indexI < 28)
        {
            menuButton = GameObject.Find("Weapon_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Weapon[sheetIndex];
            playerMannequin.transform.GetChild(6).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            // Activate Weapon Mask
            if (info.useMaskTexture)
            {
                UpdateMask(false, "weapon");
            }
            else
            {
                playerMannequin.transform.GetChild(6).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                playerMannequin.transform.GetChild(6).GetChild(0).GetComponent<SpriteMask>().enabled = false;
            }
                

            GameController.controller.playerEquippedIDs[12] = i;
            GameController.controller.playerEquippedIDs[13] = j;

            atk[6] = info.AttackStat;
            def[6] = info.DefenseStat;
            prw[6] = info.ProwessStat;
            spd[6] = info.SpeedStat;
        }
        //aura
        else if (indexI < 30)
        {
            menuButton = GameObject.Find("Aura_Button");
            menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Aura[sheetIndex];
            playerMannequin.transform.GetChild(12).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(imageName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

            GameController.controller.playerEquippedIDs[14] = i;
            GameController.controller.playerEquippedIDs[15] = j;

            atk[7] = info.AttackStat;
            def[7] = info.DefenseStat;
            prw[7] = info.ProwessStat;
            spd[7] = info.SpeedStat;
        }

        atk_text.GetComponent<Text>().text = "ATK  " + info.AttackStat.ToString();
        def_text.GetComponent<Text>().text = "DEF  " + info.DefenseStat.ToString();
        spd_text.GetComponent<Text>().text = "PRS  " + info.SpeedStat.ToString();
        prs_text.GetComponent<Text>().text = "SPD  " + info.ProwessStat.ToString();

        RefreshAnimations();
    }

    public void RefreshAnimations()
    {
        playerMannequin.GetComponent<AnimationController>().Refresh();
    }

    //*4 items per row*

    // HEAD UNLOCKS
    // [0][0]... [0][3] 
    // [1][0]... [1][3]
    // [2][0]... [2][3]
    // [3][0]... [3][3]
    public void ShowHeadEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[0];
        int equippedJ = GameController.controller.playerEquippedIDs[1];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(0);
        
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        //mirrorCamera.GetComponent<PlayerCamera_C>().mirror = equipmentSelectPopUp.transform.GetChild(2).gameObject;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference updatest
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Head" + i + j;
                
                if(unlockedEquipment[i,j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i,j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Head[(4 * i) + j];

                    if(i == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // TORSO UNLOCKS
    // [4][0]... [4][3]
    // [5][0]... [5][3]
    // [6][0]... [6][3]
    // [7][0]... [7][3]
    public void ShowTorsoEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[2];
        int equippedJ = GameController.controller.playerEquippedIDs[3];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(1);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Torso" + (4 + i) + j;

                if (unlockedEquipment[i + 4, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 4, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Torso[(4 * i) + j];

                    if ((i + 4) == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 4, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // LEG UNLOCKS
    // [8][0]... [8][3] 
    // [9][0]... [9][3]
    // [10][0]... [10][3]
    // [11][0]... [11][3]
    public void ShowLegsEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[4];
        int equippedJ = GameController.controller.playerEquippedIDs[5];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(2);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Legs" + (8 + i) + j;

                if (unlockedEquipment[i + 8, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 8, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Legs[(4 * i) + j];

                    if ((i + 8) == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 8, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // BACK UNLOCKS
    // [12][0]... [12][3]
    // [13][0]... [13][3]
    // [14][0]... [14][3]
    // [15][0]... [15][3]
    public void ShowBackEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[6];
        int equippedJ = GameController.controller.playerEquippedIDs[7];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(3);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Back" + (12 + i) + j;

                if (unlockedEquipment[i + 12, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 12, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Back[(4 * i) + j];

                    if ((i + 12) == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 12, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // GLOVE UNLOCKS
    // [16][0]... [16][3] 
    // [17][0]... [17][3]
    // [18][0]... [18][3]
    // [19][0]... [19][3]
    public void ShowGlovesEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[8];
        int equippedJ = GameController.controller.playerEquippedIDs[9];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(4);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Gloves" + (16 + i) + j;

                if (unlockedEquipment[i + 16, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 16, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Gloves[(i) + j];

                    if ((i + 16) == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 16, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // SHOES UNLOCKS
    // [20][0]... [20][3]
    // [21][0]... [21][3]
    // [22][0]... [22][3]
    // [23][0]... [23][3]
    public void ShowShoesEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[10];
        int equippedJ = GameController.controller.playerEquippedIDs[11];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(5);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Shoes" + (20 + i) + j;

                if (unlockedEquipment[i + 20, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 20, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Shoes[(4 * i) + j];

                    if ((i + 20) == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 20, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // WEAPON UNLOCKS
    // [24][0]... [24][3] 
    // [25][0]... [25][3]
    // [26][0]... [26][3]
    // [27][0]... [27][3]
    public void ShowWeaponEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[12];
        int equippedJ = GameController.controller.playerEquippedIDs[13];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(6);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;

        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Weapon" + (24 + i) + j;

                if (unlockedEquipment[i + 24, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 24, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Weapon[(4 * i) + j];

                    if ((i + 24) == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 24, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }
    // AURA UNLOCKS
    // [28][0]... [28][3]
    // [29][0]... [29][3]
    public void ShowAuraEquipment()
    {
        int equippedI = GameController.controller.playerEquippedIDs[14];
        int equippedJ = GameController.controller.playerEquippedIDs[15];

        prevID_i = equippedI;
        prevID_j = equippedJ;

        Destroy(equipmentSelectPopUp);
        UnhighlightEquipment();
        HilightEquipment(7);
        equipmentSelectPopUp = (GameObject)Instantiate(equipmentSelectPopUpPrefab, Vector3.zero, transform.rotation);
        equipmentSelectPopUp.transform.GetChild(4).GetComponent<ClosePopUp>().externalCallObj = "CharacterMenuManager";
        equipmentSelectPopUp.transform.SetParent(canvas.transform);
        equipmentSelectPopUp.transform.localScale = Vector3.one;
        equipmentSelectPopUp.transform.localPosition = EQP_TAB_OFFSET;
        atk_text = equipmentSelectPopUp.transform.GetChild(5).gameObject;
        def_text = equipmentSelectPopUp.transform.GetChild(6).gameObject;
        spd_text = equipmentSelectPopUp.transform.GetChild(7).gameObject;
        prs_text = equipmentSelectPopUp.transform.GetChild(8).gameObject;

        //get the iner most grid child to reference later
        GameObject grid = equipmentSelectPopUp.transform.GetChild(1).GetChild(0).gameObject;
        // outer loop should match the key above
        for (int i = 0; i < 2; ++i)
        {
            GameObject rowObject = grid.transform.GetChild(i).gameObject;
            //inner loop is always 4
            for (int j = 0; j < 4; ++j)
            {
                GameObject button = rowObject.transform.GetChild(j).gameObject;
                button.name = "EquipmentSelect_Button_Aura" + (28 + i) + j;

                if (unlockedEquipment[i + 28, j])
                {
                    EquipmentInfo info = EquipmentInfoManager.equipmentInfoTool.LookUpEquipment(i + 28, j);
                    button.transform.GetChild(0).GetComponent<Text>().text = info.Name;
                    button.transform.GetChild(1).GetComponent<Image>().sprite = spriteSheet_Aura[(4 * i) + j];

                    if (i == equippedI && j == equippedJ)
                    {
                        //highlight current equipment
                        HighlightEpqButton(button, i + 28, j);
                    }
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "???";
                    button.transform.GetChild(1).GetComponent<Image>().sprite = lockedIcon;
                    button.GetComponent<Image>().raycastTarget = false;
                }
            }
        }
    }

    public void ShowEquipmentOptions()
    {
        foreach (GameObject button in equipmentOptions)
        {
            button.GetComponent<Image>().enabled = false;
        }
    }

    public void HideEquipmentOptions()
    {
        foreach(GameObject button in equipmentOptions)
        {
            button.GetComponent<Image>().enabled = false;
        }
    }

    public void GoBack()
    {
        StartCoroutine(GoToMainMenu());
    }

    public IEnumerator GoToMainMenu()
    {
        DisableMainButtons();
        DisableEquipmentButtons();

        GameController.controller.Save(GameController.controller.playerName);
        //print("saving char: " + GameController.controller.playerName);
        //SAVE THE PREFAB
        camera.GetComponent<LerpScript>().LerpToPos(camera.transform.position, mmCameraPos, 1f);
        yield return new WaitForSeconds(0.25f);
        blackSq.GetComponent<FadeScript>().FadeIn(2.0f);
        yield return new WaitForSeconds(0.65f);
        snapshotAnchor.transform.GetChild(2).GetComponent<PlayerCamera_C>().TakeSnapshot();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void HideMainButtons()
    {
        BackButton.GetComponent<Image>().enabled = false;
        BackButton.GetComponentInChildren<Image>().enabled = false;
        AbilitiesButton.GetComponent<Image>().enabled = false;
        AbilitiesButton.GetComponentInChildren<Text>().enabled = false;
        PersonaButton.GetComponent<Image>().enabled = false; ;
        PersonaButton.GetComponentInChildren<Text>().enabled = false;
    }

    public void DisableMainButtons()
    {
        BackButton.GetComponent<Button>().enabled = false;
        AbilitiesButton.GetComponent<Button>().enabled = false;
        PersonaButton.GetComponent<Button>().enabled = false; ;
    }

    public void DisableEquipmentButtons()
    {
        foreach (GameObject buttton in equipmentOptions)
        {
            buttton.GetComponent<Button>().enabled = false;
        }
    }

    private void LoadEquipmentIcons()
    {
        GameObject menuButton;
        int sheetIndex = (4 * (GameController.controller.playerEquippedIDs[0] % 4)) + GameController.controller.playerEquippedIDs[1];
        //head
        menuButton = GameObject.Find("Head_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Head[sheetIndex];
        //torso
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[2] % 4)) + GameController.controller.playerEquippedIDs[3];
        menuButton = GameObject.Find("Torso_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Torso[sheetIndex];
        //Legs
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[4] % 4)) + GameController.controller.playerEquippedIDs[5];
        menuButton = GameObject.Find("Legs_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Legs[sheetIndex];
        //back
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[6] % 4)) + GameController.controller.playerEquippedIDs[7];
        menuButton = GameObject.Find("Back_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Back[sheetIndex];
        //gloves 
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[8] % 4)) + GameController.controller.playerEquippedIDs[9];
        menuButton = GameObject.Find("Gloves_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Gloves[sheetIndex];
        //shoes 
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[10] % 4)) + GameController.controller.playerEquippedIDs[11];
        menuButton = GameObject.Find("Shoes_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Shoes[sheetIndex];
        //weapon
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[12] % 4)) + GameController.controller.playerEquippedIDs[13];
        menuButton = GameObject.Find("Weapon_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Weapon[sheetIndex];
        //aura
        sheetIndex = (4 * (GameController.controller.playerEquippedIDs[14] % 4)) + GameController.controller.playerEquippedIDs[15];
        menuButton = GameObject.Find("Aura_Button");
        menuButton.transform.GetChild(0).GetComponent<Image>().sprite = spriteSheet_Aura[sheetIndex];
    }

    public void UnhighlightEquipment()
    {
        for (int i = 0; i < 8; ++i)
        {
            equipmentHandle.transform.GetChild(i).GetComponent<Image>().color = Color.grey;
        }
    }

    public void HilightEquipment(int number)
    {
        equipmentHandle.transform.GetChild(number).GetComponent<Image>().color = new Color(0.8f, 1.0f, 0.0f, 1.0f);
    }
}
