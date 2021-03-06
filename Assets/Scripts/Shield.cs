﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    public AudioClip skillSound;
    public AudioSource sfxSource;
    public Player player;
	public float appearTime;
	private bool isRaising = false;
	private float appearTimer;
	public GameObject shield;
	private GameObject shieldObj;
	private int facing;

	// Use this for initialization
	void Start () {
		appearTimer = appearTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isRaising) {
            player.isDown = false;
            appearTimer -= Time.deltaTime;
			shieldMove ();
			if (appearTimer < 0) {
				isRaising = false;
				appearTimer = appearTime;
				Destroy (shieldObj);
			}
		}
		else if (player.triggerNormalSkill) {
            sfxSource.PlayOneShot(skillSound);
            raiseShield	();
			isRaising = true;
            player.triggerNormalSkill = false;
		}
	}

	void shieldMove() {
		if (facing == 0)
			shieldObj.transform.position = new Vector2(player.transform.position.x - 1, player.transform.position.y);
		else if (facing == 1)
			shieldObj.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
		else if (facing == 2)
			shieldObj.transform.position = new Vector2(player.transform.position.x + 1, player.transform.position.y);
		else if (facing == 3)
			shieldObj.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 1);
	}

	void raiseShield() {
		shieldObj = Instantiate (shield, new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity) as GameObject;
		if (player.facing == 0) { //left
			facing = player.facing;
			shieldObj.transform.Rotate (Vector3.forward * -90);
		} else if (player.facing == 1) { //up
			facing = player.facing;
			shieldObj.transform.Rotate (Vector3.forward * -180);
		} else if (player.facing == 2) { //right
			facing = player.facing;
			shieldObj.transform.Rotate (Vector3.forward * -270);
		} else if (player.facing == 3) { //down
			facing = player.facing;
		}
	}
}
