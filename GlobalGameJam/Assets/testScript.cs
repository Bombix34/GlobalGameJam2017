using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

	public GameObject testWave;


	void Start () {
		
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {

			Instantiate(testWave, new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f)), Quaternion.identity);
		}
	}
}
