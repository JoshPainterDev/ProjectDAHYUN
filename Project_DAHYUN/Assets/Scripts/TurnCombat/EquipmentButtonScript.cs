﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EquipmentButtonScript : MonoBehaviour {
    private GameObject menuManager;

    private void Awake()
    {
        menuManager = GameObject.Find("CharacterMenuManager");
    }

    // Use this for initialization
    void Start () {
	}

    public void OnClicked(Button button)
    {
        //string disect = button.name.Substring(button.name.Length - 3);
        //int temp = 0;
        //string numericPhone = new String(phone.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
        int indexI = 0;
        int indexJ = 0;

        string a = button.name;
        string b = string.Empty;
        int val;

        for (int i = 0; i < a.Length; i++)
        {
            if (char.IsDigit(a[i]))
                b += a[i];
        }

        int.TryParse(b, out val);
        indexJ = val % 10;
        indexI = val / 10;

        Destroy(button.transform.parent.parent.parent.parent.gameObject);

        menuManager.GetComponent<Character_Menu_Manager>().LoadSelectedImage(indexI, indexJ);
    }
}