﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptElmt : MonoBehaviour {
    public GameObject wave;
    private float timer = 3f;
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(timer<=0) {
            timer = 3;
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0);
            Instantiate(wave, rndPosWithin, transform.rotation);
        }
        else { 
            timer -= Time.deltaTime;
        }
	}
}