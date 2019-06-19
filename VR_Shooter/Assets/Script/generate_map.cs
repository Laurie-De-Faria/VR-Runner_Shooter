using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_map : MonoBehaviour {

    public GameObject obstacle;
    public GameObject spaceship;
    private GameObject clone;
    private float timer;
    [SerializeField]
    private float timer_max;
    [SerializeField]
    private float distance_min;
    private float distance_min_spawn_spaceship;
    public List<GameObject> Obstacles;
    private int random;
	// Use this for initialization
	void Start ()
    {
        Obstacles = GameObject.Find("Obstacle_List").GetComponent<Obstacle_List>().Obstacle;
	}

    // Update is called once per frame
    void Update() {
    }

    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            for (int spawn = 3; spawn > 0; spawn--)
            {
                random = Random.Range(0, 4);
                distance_min_spawn_spaceship = spaceship.transform.localPosition.z + distance_min;
                clone = Instantiate(Obstacles[random], new Vector3(Random.Range(-10f, 10f), Random.Range(-2f, 5f), Random.Range(distance_min_spawn_spaceship, distance_min_spawn_spaceship + 10f)), new Quaternion(1, 1, 1, 1));
                //Destroy(clone, 5);
            }
            timer = timer_max;
        }
        else
        {
            timer -= 1;
        }
    }
}