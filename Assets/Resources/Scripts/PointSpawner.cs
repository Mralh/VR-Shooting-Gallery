using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : Spawner {

    public int stayTime = 120;
    public string type = "green";

    GameObject rupee;
    public override void spawn()
    {
        base.timer = 0;
        base.activated = true;
        base.timeToNext = 500;
        rupee = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/rupees/" + type));
        rupee.transform.position = transform.position;
        rupee.GetComponent<Shootable>().destroyTimer = stayTime + 30;
    }

    public override void perTick()
    {
        if (base.timer < stayTime)
        {
            if (rupee != null)
                rupee.transform.position = Vector3.Lerp(rupee.transform.position, transform.position + Vector3.up, 5f * Time.deltaTime);
        }
        else
        {
            if (rupee != null)
                rupee.transform.position = Vector3.Lerp(rupee.transform.position, transform.position, 5f * Time.deltaTime);
        }

    }
}
