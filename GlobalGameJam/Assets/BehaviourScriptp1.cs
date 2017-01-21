using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BehaviourScriptp1 : MonoBehaviour
{

    public float Speed;
    private float _x = 0f;
    private float _y = 0f;
    private bool dashUp;
    private float dashCd = 0;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        dashUp = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashCd > 0)
        {
            dashCd -= Time.deltaTime;
        }
        else
        {
            dashUp = true;
        }
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("dashp1") && dashUp)
        {
            StartCoroutine(launchDash());
        }
        Vector2 move = new Vector2(_x, _y);
        rb2d.MovePosition(rb2d.position + move * Speed);
    }

    public IEnumerator launchDash()
    {
        _x *= 10;
        _y *= 10;
        dashUp = false;
        dashCd = 1;
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}