﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions; // needed for Regex
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewCharacter_Manager : MonoBehaviour {

    public GameObject textField;

	// Use this for initialization
	void Start () {
		
	}

    public void FinalizeCharacter()
    {
        string charName = textField.GetComponent<InputField>().text;
        charName = Regex.Replace(charName, @"[^a-zA-Z0-9 ]", "");

        if(charName != "")
        {
            GameController.controller.charNames[GameController.controller.CharacterSlot] = charName;
            ++GameController.controller.numChars;
            GameController.controller.SaveCharacters();
            print("Saving: " + charName);
            GameController.controller.Save(charName);
        }
        else
        {
            print("Bade Name! only chars and numbers!");
        }
    }
}
