using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.Events;


public class MoveSpace : MonoBehaviour {

    public GameObject MiniShip;
    public GameObject Head;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(MiniShip.transform.position.x, MiniShip.transform.position.y, Head.transform.position.z);
        this.transform.rotation = MiniShip.transform.rotation;
    }
}
