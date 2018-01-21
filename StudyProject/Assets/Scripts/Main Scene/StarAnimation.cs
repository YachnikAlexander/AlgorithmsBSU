using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour {

    private SpriteRenderer star;
    private float movementSpeed = 0.1f;

    void Start() {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
    }

    void Update() {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 2.5f, 1));

        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }
}
