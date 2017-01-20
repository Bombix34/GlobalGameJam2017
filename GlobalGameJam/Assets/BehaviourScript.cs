using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BehaviourScript : MonoBehaviour {

    private float Speed = 0.5f;
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
        if (Input.GetKey(KeyCode.UpArrow)) {
            _y = 1.0f;
        }else if (Input.GetKey(KeyCode.DownArrow)) {
            _y = -1.0f;
        }else { 
            _y = 0.0f;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            _x = -1.0f;
        }else if(Input.GetKey(KeyCode.RightArrow)) {
            _x = 1.0f;
        }else {
            _x = 0.0f;
        }
        if(Input.GetKey(KeyCode.LeftShift) && dashUp) {
            _x += 5 * System.Math.Sign(_x);
            _y += 5 * System.Math.Sign(_y);
            dashUp = false;
            dashCd = 1;
        }
        Vector2 move = new Vector2(_x, _y);
        //transform.position += move * Speed * Time.deltaTime;
        rb2d.MovePosition(rb2d.position + move * Speed);
	}
}
