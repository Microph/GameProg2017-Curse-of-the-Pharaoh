﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour {

	public Enemy enemy;
	public Camera cmr;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (true) {
			cmr.GetComponent<CameraSetting> ().target = enemy.transform;
		}
	}
}
