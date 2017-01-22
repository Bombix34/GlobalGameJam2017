using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BehaviourScriptp2 : MonoBehaviour
{

    public float Speed;
    private float _x = 0f;
    private float _y = 0f;
    private bool dashUp;
    private float dashCd = 0;
    private Rigidbody2D rb2d;
    public static bool ready = false;
   /* private bool jumping = false;
    private float jumpTime = 1;
    private float jumpCd = 2;*/

    // Use this for initialization
    void Start()
    {
        dashUp = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkFin();

        if (dashCd > 0){
            dashCd -= Time.deltaTime;
        }
        else
        {
            dashUp = true;
        }

        if (Input.GetKey(KeyCode.UpArrow)){
            _y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow)){
            _y = -1;
        }
        else
        {
            _y = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _x = -1;
        }
        else
        {
            _x = 0;
        }



        if (Input.GetKey(KeyCode.N) && dashUp)
        {
            _x *= 10;
            _y *= 10;
            dashUp = false;
            dashCd = 1;
        }
        Vector2 move = new Vector2(_x, _y);
        rb2d.MovePosition(rb2d.position + move * Speed);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void rotateTowardMouse()
    {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = 10; //The distance between the camera and object
        var object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        var angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void checkFin()
    {
        if (scriptElmt.endGame)
        {
            transform.position = new Vector2(5,1);
            ready = true;
            if(BehaviourScriptp1.ready == true) {
                ready = false;
                BehaviourScriptp1.ready = true;
                scriptElmt.endGame = false;     
           }

        }
    }
}