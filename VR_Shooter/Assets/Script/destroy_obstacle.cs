using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_obstacle : MonoBehaviour {
    private GameObject spaceship;
    private Transform obstacle;
    private GameObject score;
    private score script_score;
	// Use this for initialization
	void Start () {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        obstacle = GetComponent<Transform>();
        score = GameObject.FindGameObjectWithTag("Score");
        script_score = score.GetComponent<score>();
	}

    // Update is called once per frame
    void Update () {
        if (obstacle.position.z <= spaceship.transform.position.z - 10)
        {
            Destroy(obstacle.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && other.gameObject.name == "GreenSphere(Clone)" && this.gameObject.name == "GreenObstacle(Clone)")
        {
            script_score.i_score = script_score.i_score + 10;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet" && other.gameObject.name == "BlueSphere(Clone)" && this.gameObject.name == "BlueObstacle(Clone)")
        {
            script_score.i_score = script_score.i_score + 10;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet" && other.gameObject.name == "RedSphere(Clone)" && this.gameObject.name == "RedObstacle(Clone)")
        {
            script_score.i_score = script_score.i_score + 10;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
