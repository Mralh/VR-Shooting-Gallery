using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    protected Transform spawnerParent;
    protected int timeToNext = 300;
    protected bool activated = false;
    protected int timer = 0;

    void Start()
    {
        spawnerParent = GameObject.Find("spawners").transform;
    }

    void FixedUpdate()
    {
        if (activated && timer < timeToNext)
            timer++;
        else if (activated && timer >= timeToNext)
        {
            //triggerNextSpawner();
            timer = 0;
            activated = false;
        }
        perTick();
    }

    public virtual void spawn() { }
    public virtual void perTick() { }

    public void triggerNextSpawner()
    {
        int next = (int) Random.Range(0, spawnerParent.childCount);
        GameObject spawner = spawnerParent.GetChild(next).gameObject;
        Debug.Log(spawner.name);
        spawner.GetComponent<Spawner>().spawn();
    }
}
