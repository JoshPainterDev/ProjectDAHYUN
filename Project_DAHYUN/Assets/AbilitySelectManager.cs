﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AbilitySelectManager : MonoBehaviour
{
    public GameObject AbilitySelectPref;
    public GameObject AbilityGrid;
    public GameObject ASprefab;
    public GameObject descriptionPanel;
    public GameObject powerText;
    public GameObject typeText;
    public GameObject cooldownText;
    public GameObject sampleImage;
    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;
    public GameObject ability4;
    public Color highlightColor;
    public Color normalColor;
    public Color physicalColor;
    public Color magicalColor;
    public Color utilityColor;
    public GameObject blackSq;
    public GameObject backButton;

    private int ASslot = 0;
    private int currentASnum = 0;
    private int totalAbiliyUnlocks = 0;
    private int maxAbilities = 0;
    private int prevHighlightIndex = -1;
    private Ability currentAbility;

    // Use this for initialization
    void Start ()
    {
        totalAbiliyUnlocks = GameController.controller.totalAbilities;
        totalAbiliyUnlocks = 15;
        maxAbilities = GameController.controller.TOTAL_ABILITIES;

        for(int f = 0; f < 19; ++f)
            GameController.controller.unlockedAbilities[f] = true;

        //GameController.controller.playerAbility1 = AbilityToolsScript.tools.LookUpAbility("none");
        //GameController.controller.playerAbility2 = AbilityToolsScript.tools.LookUpAbility("none");
        //GameController.controller.playerAbility3 = AbilityToolsScript.tools.LookUpAbility("none");
        //GameController.controller.playerAbility4 = AbilityToolsScript.tools.LookUpAbility("none");

        LoadInitialIcons();
    }

    public void LoadAbilitiesPanel(int ASnum)
    {
        if (ASslot != ASnum)
        {
            if(ASslot != 0)
            {
                for (int k = 0; k < AbilityGrid.transform.childCount; ++k)
                {
                    Destroy(AbilityGrid.transform.GetChild(k).gameObject);
                }
            }

            ASslot = ASnum;
            int popUps = 0;
            int lastIndex = 1;

            // set all of the needed ability panels
            for (int i = 0; i < totalAbiliyUnlocks; ++i)
            {
                for (int j = lastIndex; j < maxAbilities; ++j)
                {
                    if (GameController.controller.unlockedAbilities[j] == true)
                    {
                        Ability curAbility = AbilityToolsScript.tools.IndexToAbilityLookUp(j);
                        GameObject selectClone = (GameObject)Instantiate(ASprefab, Vector3.zero, transform.rotation);
                        selectClone.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { AbilityOptionSelected(selectClone); });
                        selectClone.transform.SetParent(AbilityGrid.transform);
                        selectClone.transform.localScale = new Vector3(1, 1, 1);
                        selectClone.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = curAbility.Name;
                        selectClone.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = Resources.Load(curAbility.Icon, typeof(Sprite)) as Sprite;
                        ++popUps;
                        lastIndex = j;
                    }
                }
            }
            popUps = 0;
        }
        
        AbilitySelectPref.SetActive(true);
    }

    public void ClosePopUp()
    {
        prevHighlightIndex = -1;
        AbilitySelectPref.SetActive(false);
    }

    public void AbilityOptionSelected(GameObject button)
    {
        int index = button.transform.GetSiblingIndex();
        currentASnum = index;


        if (prevHighlightIndex != -1)
            AbilityGrid.transform.GetChild(prevHighlightIndex).GetChild(0).GetComponent<Image>().color = normalColor;

        currentAbility = AbilityToolsScript.tools.LookUpAbility(AbilityGrid.transform.GetChild(index).GetChild(0).GetChild(0).GetComponent<Text>().text);
        AbilityGrid.transform.GetChild(index).GetChild(0).GetComponent<Image>().color = highlightColor;
        prevHighlightIndex = index;
        sampleImage.GetComponent<Image>().sprite = button.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
        powerText.GetComponent<Text>().text = currentAbility.BaseDamage.ToString();
        descriptionPanel.GetComponent<Text>().text = currentAbility.Description;
        cooldownText.GetComponent<Text>().text = currentAbility.Cooldown.ToString();
        setType(currentAbility.Type);
    }

    public void ConfirmAbilitySelect()
    {
        switch(ASslot)
        {
            case 1:
                GameController.controller.playerAbility1 = currentAbility;
                break;
            case 2:
                GameController.controller.playerAbility2 = currentAbility;
                break;
            case 3:
                GameController.controller.playerAbility3 = currentAbility;
                break;
            case 4:
                GameController.controller.playerAbility4 = currentAbility;
                break;
        }

        setIcon(ASslot);
        AbilitySelectPref.SetActive(false);
    }

    public void setIcon(int abilityNum)
    {
        switch(abilityNum)
        {
            case 1:
                ability1.GetComponent<Image>().sprite = Resources.Load(GameController.controller.playerAbility1.Icon, typeof(Sprite)) as Sprite;
                break;
            case 2:
                ability2.GetComponent<Image>().sprite = Resources.Load(GameController.controller.playerAbility2.Icon, typeof(Sprite)) as Sprite;
                break;
            case 3:
                ability3.GetComponent<Image>().sprite = Resources.Load(GameController.controller.playerAbility3.Icon, typeof(Sprite)) as Sprite;
                break;
            case 4:
                ability4.GetComponent<Image>().sprite = Resources.Load(GameController.controller.playerAbility4.Icon, typeof(Sprite)) as Sprite;
                break;
        }
    }

    public void setType(AbilityType type)
    {
        switch(type)
        {
            case AbilityType.Physical:
                typeText.GetComponent<Text>().color = physicalColor;
                typeText.GetComponent<Text>().text = "Physical";
                break;
            case AbilityType.Magical:
                typeText.GetComponent<Text>().color = magicalColor;
                typeText.GetComponent<Text>().text = "Magical";
                break;
            case AbilityType.Utility:
                typeText.GetComponent<Text>().color = utilityColor;
                typeText.GetComponent<Text>().text = "Utility";
                break;
        }
    }

    public void LoadInitialIcons()
    {
        for (int i = 1; i < 5; ++i)
            setIcon(i);
    }

    public void BackToMM()
    {
        backButton.GetComponent<Button>().enabled = false;
        GameController.controller.Save(GameController.controller.playerName);
        StartCoroutine(LoadMM());
    }

    IEnumerator LoadMM()
    {
        blackSq.GetComponent<FadeScript>().FadeIn(2);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Character_Scene");
    }
}