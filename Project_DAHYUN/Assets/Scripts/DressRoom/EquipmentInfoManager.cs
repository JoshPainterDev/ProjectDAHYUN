﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInfoManager : MonoBehaviour{

    public static EquipmentInfoManager equipmentInfoTool;

    private const string prefixHead = "Animations\\Equipment\\Head";
    private const string prefixTorso = "Animations\\Equipment\\Torso";
    private const string prefixLegs = "Animations\\Equipment\\Legs";
    private const string prefixBack = "Animations\\Equipment\\Back";
    private const string prefixGloves = "Animations\\Equipment\\Gloves";
    private const string prefixShoes = "Animations\\Equipment\\Shoes";
    private const string prefixWeapon = "Animations\\Equipment\\Weapons";

    void Awake()
    {
        if (equipmentInfoTool == null)
        {
            DontDestroyOnLoad(gameObject);
            equipmentInfoTool = this;
        }
        else if (equipmentInfoTool != this)
        {
            Destroy(gameObject);
        }
    }

    public EquipmentInfo LookUpEquipment(int i, int j)
    {
        EquipmentInfo equipInfo = new EquipmentInfo();

        // HELMETS //
        if (i < 4)
        {
            switch (i)
            {
                case 0:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            equipInfo.imgSourceName = prefixHead + "\\Test_Suit\\Player_Head_TestHelm_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Mask";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            equipInfo.imgSourceName = prefixHead + "\\Slayer_Outfit\\Player_Head_SlayerHead_AnimController";
                            equipInfo.hideUnderLayer = false;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 1:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 2:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 3:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // TORSOS //
        else if (i < 8)
        {
            switch (i)
            {
                case 4:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Chest";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Torso;
                            equipInfo.imgSourceName = prefixTorso + "\\Test_Suit\\Player_Torso_TestTorso_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Chest";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Torso;
                            equipInfo.imgSourceName = prefixTorso + "\\Slayer_Outfit\\Player_Torso_SlayerTorso_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 5:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 6:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 7:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // LEGS //
        else if (i < 12)
        {
            switch (i)
            {
                case 8:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Legs";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Legs;
                            equipInfo.imgSourceName = prefixLegs + "\\Test_Suit\\Player_Legs_TestLegs_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Legs";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Legs;
                            equipInfo.imgSourceName = prefixLegs + "\\Slayer_Outfit\\Player_Legs_SlayerLegs_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 9:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 10:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 11:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // Back //
        else if (i < 16)
        {
            switch (i)
            {
                case 12:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Back";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Back;
                            equipInfo.imgSourceName = prefixBack + "\\Test_Suit\\Player_Back_TestCape_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Cape";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Back;
                            equipInfo.imgSourceName = prefixBack + "\\Slayer_Outfit\\Player_Back_SlayerCape_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 13:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 14:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 15:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // Gloves //
        else if (i < 20)
        {
            switch (i)
            {
                case 16:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Gloves";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Gloves;
                            equipInfo.imgSourceName = prefixGloves + "\\Test_Suit\\Player_Gloves_TestGloves_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Gloves";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Gloves;
                            equipInfo.imgSourceName = prefixGloves + "\\Slayer_Outfit\\Player_Gloves_SlayerGloves_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 17:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 18:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 19:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // SHOES //
        else if (i < 24)
        {
            switch (i)
            {
                case 20:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Shoes";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Shoes;
                            equipInfo.imgSourceName = prefixShoes + "\\Test_Suit\\Player_Shoes_TestShoes_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Greaves";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Shoes;
                            equipInfo.imgSourceName = prefixShoes + "\\Slayer_Outfit\\Player_Shoes_SlayerShoes_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 21:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 22:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 23:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // WEAPON //
        else if (i < 28)
        {
            switch (i)
            {
                case 24:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            equipInfo.imgSourceName = prefixWeapon + "\\Test_Sword\\Player_Weapon_TestSword_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Fire Sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            equipInfo.imgSourceName = prefixWeapon + "\\Fire_Sword\\Player_Weapon_FireSword_AnimController";
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            equipInfo.imgSourceName = prefixWeapon + "\\Slayer_Sword\\Player_Weapon_SlayerSword_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "idklol sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            //equipInfo.imgSourceName = prefixWeapon + "//Slayer_Sword//Player_Weapon_SlayerSword_Idle01";
                            break;
                    }
                    break;
                case 25:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 26:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
                case 27:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }
        }
        // AURA //
        else if (i > 30)
        {
            switch (i)
            {
                case 28:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Aura";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Back;
                            equipInfo.imgSourceName = prefixWeapon + "//Test_Sword//Player_Weapon_TestSword_AnimController";
                            break;
                        case 1:
                            equipInfo.Name = "Fire Sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            equipInfo.imgSourceName = prefixWeapon + "//Fire_Sword//Player_Weapon_FireSword_AnimController";
                            break;
                        case 2:
                            equipInfo.Name = "Slayer Sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            equipInfo.imgSourceName = prefixWeapon + "//Slayer_Sword//Player_Weapon_SlayerSword_AnimController";
                            break;
                        case 3:
                            equipInfo.Name = "idklol sword";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Sword;
                            //equipInfo.imgSourceName = prefixWeapon + "//Slayer_Sword//Player_Weapon_SlayerSword_Idle01";
                            break;
                    }
                    break;
                case 29:
                    switch (j)
                    {
                        case 0:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 1:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 2:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                        case 3:
                            equipInfo.Name = "Test Helmet";
                            equipInfo.AttackStat = 69;
                            equipInfo.DefenseStat = 69;
                            equipInfo.ProwessStat = 69;
                            equipInfo.SpeedStat = 69;
                            equipInfo.EquipType = EquipmentInfo.EquipmentType.Head;
                            break;
                    }
                    break;
            }

        }
        return equipInfo;
    }
}