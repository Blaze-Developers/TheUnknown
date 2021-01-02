﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Com.Coding.MultiplayerFPS
{
    [CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
    public class Gun : ScriptableObject
    {
        public string name;
        public float firerate;
        public float aimSpeed;
        public GameObject prefab;
    }
}