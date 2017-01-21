using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BehaviourScript : MonoBehaviour {

    private float Speed = 0.25f;
    private float _x = 0f;
    private float _y = 0f;
    private bool dashUp;
    private float dashCd = 0;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        dashUp = true;
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(dashCd > 0) {
            dashCd -= Time.deltaTime;
        }else {
            dashUp = true;
        }
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        
        if(Input.GetKey(KeyCode.LeftShift) && dashUp) {
            _x *= 7;
            _y *= 7;
            dashUp = false;
            dashCd = 1;
        }
        Vector2 move = new Vector2(_x, _y);
        rb2d.MovePosition(rb2d.position + move * Speed);
	}
}
