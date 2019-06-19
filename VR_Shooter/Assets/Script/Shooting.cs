using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Shooting : MonoBehaviour {

    public VRTK_ControllerEvents Control;
    private Rigidbody clone;
    [SerializeField]
    private Transform spawnerPos;
    public int speed;
    public float destroyTime;
    private bool cooldown = true;
    [SerializeField]
    private float timer_cooldown;
    public List<GameObject> Bullets;
    private int color;
    // Use this for initialization
    void Start () {
        Bullets = GameObject.Find("Bullet_List").GetComponent<Bullet_List>().Bullet;
        color = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Control.triggerPressed && cooldown == true)
        {
            color = check_color(color);
            clone = Instantiate(Bullets[color].GetComponent<Rigidbody>(), spawnerPos.position, transform.rotation);
            clone.velocity = transform.forward * speed;
            Destroy(clone.gameObject, 5);
            cooldown = false;
            StartCoroutine(WaitShoot(timer_cooldown));
        }
    }

    private IEnumerator WaitShoot(float timer)
    {
        yield return new WaitForSeconds(timer);
        cooldown = true;
    }

    private int check_color(int color)
    {
        if (Control.gripClicked)
        {
            if (gameObject.name == "droneRight")
            {
                if (color == 1)
                    color = 0;
                else
                    color = 1;
            }
            else
            {
                if (color == 1)
                    color = 2;
                else
                    color = 1;
            }
        }
        return (color);
    }
}
