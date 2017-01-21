using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getTriggerWaves : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 dir = new Vector2(other.GetComponent<Transform>().position.x - transform.position.x, other.GetComponent<Transform>().position.y - transform.position.y);
        dir *= 1.01f;
        other.transform.Translate(dir * Time.deltaTime);
    }
}
