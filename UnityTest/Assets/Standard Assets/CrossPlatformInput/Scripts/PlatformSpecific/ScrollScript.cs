using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {

    float scrollSpeed = -40f;
    Vector2 startPos;


	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newpos = Mathf.Repeat(Time.time * scrollSpeed, 30);
        transform.position = startPos + Vector2.right * newpos;
	}
}
