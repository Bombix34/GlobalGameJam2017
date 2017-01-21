using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float speedPropagation;

	public GameObject interiorCircle;
	public GameObject exteriorCircle;

	public float cpt = 5;

	void Start () {
		
	}

	void Update () {
		interiorCircle.transform.localScale = new Vector2 (interiorCircle.transform.localScale.x+speedPropagation,interiorCircle.transform.localScale.y+speedPropagation);
		exteriorCircle.transform.localScale = new Vector2 (exteriorCircle.transform.localScale.x+speedPropagation,exteriorCircle.transform.localScale.y+speedPropagation);
		if (cpt > 0) {
			cpt -= Time.deltaTime;
		} else {
			Destroy (this.gameObject);
		}

	}
}
