﻿using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}