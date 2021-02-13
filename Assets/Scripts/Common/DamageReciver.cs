﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciver : MonoBehaviour
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public SC_CharacterController playerController;
    public WeaponManager weaponManager;

    public void ApplyDamage(float points)
    {
        playerHP -= points;

        if (playerHP <= 0)
        {
            //Player is dead
            playerController.canMove = false;
            playerHP = 0;
        }
    }
}
