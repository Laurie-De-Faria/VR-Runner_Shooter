using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

    public float speed;
    private float times;
    private int nb = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        times = Time.timeSinceLevelLoad;
        if (times - nb > 0)
        {
            speed = speed * 1.1f;
            nb += 3;
        }
	}
}
