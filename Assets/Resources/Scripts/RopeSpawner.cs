using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawner : Spawner {

    public string type = "blue";
    public Vector3 velocity = new Vector3(4, 0, 0);
	public override void spawn()
    {
        base.timer = 0;
        base.activated = true;
        base.timeToNext = 500;
        GameObject rupee = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/rupees/" + type));
        rupee.transform.position = transform.position;
        rupee.GetComponent<Rigidbody>().velocity = velocity;
        rupee.GetComponent<Shootable>().destroyTimer = 200;
    }

    public override void perTick()
    {
        if (timer == 60)
        {
            GameObject rupee = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/rupees/" + type));
            rupee.transform.position = transform.position;
            rupee.GetComponent<Rigidbody>().velocity = velocity;
            rupee.GetComponent<Shootable>().destroyTimer = 200;
        }
        if (timer == 120)
        {
            GameObject rupee = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/rupees/" + type));
            rupee.transform.position = transform.position;
            rupee.GetComponent<Rigidbody>().velocity = velocity;
            rupee.GetComponent<Shootable>().destroyTimer = 200;
        }
    }
}
