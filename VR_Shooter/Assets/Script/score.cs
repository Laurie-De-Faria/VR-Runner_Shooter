using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public Text t_score;
    private float increment;
    public int i_score = 0;
	// Use this for initialization
	void Start () {
        increment = 1;
        t_score.text = "Score: " + i_score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (increment <= 0)
        {
            i_score++;
            t_score.text = "Score: " + i_score.ToString();
            increment = 1;
        }
        else
            increment -= Time.deltaTime;
	}
}
