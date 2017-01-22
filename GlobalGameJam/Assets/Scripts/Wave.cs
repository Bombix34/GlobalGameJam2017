using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float speedPropagation;

	public GameObject interiorCircle;
	public GameObject exteriorCircle;

	public float cpt = 5;
    private float cpt2;

	void Start () {
        cpt2 = cpt;
	}

	void Update () {
		interiorCircle.transform.localScale = new Vector2 (interiorCircle.transform.localScale.x+speedPropagation,interiorCircle.transform.localScale.y+speedPropagation);
		exteriorCircle.transform.localScale = new Vector2 (exteriorCircle.transform.localScale.x+speedPropagation,exteriorCircle.transform.localScale.y+speedPropagation);
        if (cpt > 0){
            cpt -= Time.deltaTime;
        }else{
            interiorCircle.transform.localScale = new Vector2(3, 3);
            exteriorCircle.transform.localScale = new Vector2(3, 3);
            cpt = cpt2;
            GetComponent<Renderer>().enabled = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 dir = new Vector2(other.GetComponent<Transform>().position.x - transform.position.x, other.GetComponent<Transform>().position.y - transform.position.y);
        dir *= 1.2f;
        other.transform.Translate(dir);
    }
}
