﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	private List<Burst> Bursts;
	private int CurrentBurstIndex;
	private int Cooldown;
	private Vector3 Position;
	private Boundary Bounds;


	// Empty Constructor
	public Ship () {
		Bursts = new List<Burst> {new Burst()};
		Cooldown = 1;
		CurrentBurstIndex = 1;
	}


	// Constructor with bursts
	public Ship (List<Burst> bursts) : this() {
		Bursts = bursts;
	}

	// Moves ship and returns resultant position
	public Vector3 Move(Vector3 movementVector) {
		return ((Bounds == null) ?
			(Position + movementVector) :
			(Bounds.MoveClamped(Position, movementVector)));
	}

	public void SetBounds(Vector3 lowerLeft, Vector3 upperRight, float buffer = 0) {
		Bounds = new Boundary(lowerLeft, upperRight, buffer);
	}

	public Vector3 GetPosition() {
		return Position;
	}

	public void SwitchBurst(int i) {
		CurrentBurstIndex = Mathf.Clamp(i, 0, Bursts.Count - 1);
	}

	public void FireBurst(Vector3 direction, GameObject bulletPrefab) {
		Vector3 quaternionDefaultVector = new Vector3(0,1,0);
		Vector3 translatedPosition = direction - Position;
		Vector3 zAxis = new Vector3(0,0,1);

		float middleRay = Vector3.SignedAngle(
			quaternionDefaultVector,
			translatedPosition,
			zAxis
		);

		float bulletRotation;
		Quaternion bulletDirection;
		Vector3 radiusAddition;
		Burst currentBurst = Bursts[CurrentBurstIndex];
		for(int i = 0; i < currentBurst.shots.Count; i++) {
			bulletRotation = middleRay + currentBurst.shots[i];
			bulletDirection = Quaternion.Euler(0, 0, bulletRotation);
			Instantiate(bulletPrefab, Position, bulletDirection);
		}
	}
}


// radiusAddition = direction * (new Vector3(0, 0.1f, 0));
