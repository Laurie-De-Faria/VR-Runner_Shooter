using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class MoveHead : MonoBehaviour {

    public Transform head;
    private float x = 0;
    public GameObject Player;
    public GameObject Ship;
    public float RotationSpeed;
    public int Centre_X;
    public int Centre_Y;
    public int Ellipse_A;
    public int Ellipse_B;
    private float result;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(transform.position.x, head.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update () {
        if (head.rotation.z > 0.05 && InRange_Area(transform.position.x - RotationSpeed * 0.1f, transform.position.y))
        {
            transform.position = new Vector3(transform.position.x - RotationSpeed * 0.1f, transform.position.y, transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 180, (head.transform.rotation.z * -100) + 90);
        }
        else if (head.rotation.z  < -0.05 && InRange_Area(transform.position.x + RotationSpeed * 0.1f, transform.position.y))
        {
            transform.position = new Vector3(transform.position.x + RotationSpeed * 0.1f, transform.position.y, transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 180, (head.transform.rotation.z * 100) + 90);
        }
        if (head.rotation.x > 0.05 && InRange_Area(transform.position.x, transform.position.y - RotationSpeed * 0.1f))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - RotationSpeed * 0.1f, transform.position.z);
        }
        else if (head.rotation.x < -0.05 && InRange_Area(transform.position.x, transform.position.y + RotationSpeed * 0.1f))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + RotationSpeed * 0.1f, transform.position.z);
        }
        else
        {
            Ship.transform.rotation = Quaternion.Euler(0, 180, 90);
        }
        Player.transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z - 1.5f);
    }

    private bool InRange_Area(float x, float y)
    {
        result = Mathf.Pow(((x - Centre_X) / Ellipse_A), 2) + Mathf.Pow(((y - Centre_Y) / Ellipse_B), 2);
        if (result <= 1)
            return (true);
        return (false);
    }
}
