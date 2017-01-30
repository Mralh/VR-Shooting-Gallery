using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool fireHeld = false;
    bool fireReleased = false;

    float power = 1;

    public float maxPower = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire"))
            fireHeld = true;

        if (Input.GetButtonUp("Fire"))
            fireReleased = true;
	}

    void FixedUpdate()
    {
        if (fireHeld)
            power += .5f;
        if (fireReleased)
        {
            power = 1;
            fire();
            fireHeld = false;
            fireReleased = false;
        }
    }

    void fire()
    {

    }

}
