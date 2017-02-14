﻿// Attached to Hero

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroAnimation : MonoBehaviour {

	bool isBlood = false;
	bool isRainbow = false;
	bool isSparkle = false;

	GameObject bloodPrefab;
	GameObject rainbowPrefab;
	GameObject sparklePrefab;
	Hero hero;

	// Use this for initialization
	void Start () {
		bloodPrefab = Resources.Load<GameObject> ("Prefabs/Cubes/Blood");
		rainbowPrefab = Resources.Load<GameObject> ("Prefabs/Cubes/Rainbow");
		sparklePrefab = Resources.Load<GameObject> ("Prefabs/Cubes/Sparkle");
		hero = gameObject.GetComponent<Hero> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			SplashBlood();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			SplashRainbow();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			SplashSparkle();
		}


		if (isBlood) {
			Splash (bloodPrefab, 10);
		}

		if (isSparkle && !hero.isDead) {
			Splash (sparklePrefab, 10);
		}

		if (isRainbow && !hero.isDead) {
			Splash (rainbowPrefab, 10);
		}
	}

	void Splash(GameObject prefab, int n) {
		for (int i = 0; i < n; i++) {
			GameObject go = Instantiate (prefab);
			go.transform.position = gameObject.transform.position;
		}
	}

	public void SplashBlood() {
		isBlood = true;
		StartCoroutine ("WaitAndStopBlood", 0.05f);
	}

	IEnumerator WaitAndStopBlood(float t) {
		yield return new WaitForSeconds (t);
		isBlood = false;
	}

	public void SplashRainbow() {
		isRainbow = true;
		StartCoroutine ("WaitAndStopRainbow", 0.05f);
	}

	IEnumerator WaitAndStopRainbow(float t) {
		yield return new WaitForSeconds (t);
		isRainbow = false;
	}

	public void SplashSparkle() {
		Splash (sparklePrefab, 10);
//		isSparkle = true;
//		StartCoroutine ("WaitAndStopSparkle", 0.05f);
	}

//	IEnumerator WaitAndStopSparkle(float t) {
//		yield return new WaitForSeconds (t);
//		isSparkle = false;
//	}
}