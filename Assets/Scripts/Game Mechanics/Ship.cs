﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	private float Speed;
	private List<Burst> Bursts;
	private int CurrentBurstIndex;
	private int cooldown = 1;
	private Vector3 Position;


	// Constructor
	public Ship (List<Burst> Burst) {

	}

	// Moves ship and returns resultant position
	public Vector3 Move(Vector3 movementVector) {
		return Position;
	}

	public Vector3 GetPosition() {
		return Position;
	}

	public void SwitchBurst(int i) {

	}

	public void FireBurst(Vector3 direction, GameObject bulletPrefab) {

	}
}
