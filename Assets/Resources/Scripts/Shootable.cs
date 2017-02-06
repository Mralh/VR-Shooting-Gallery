using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

    public int pointValue = 1;
    public GameObject explosion;
    public int destroyTimer = 120;
    int t = 0;

    public int overrideMaterial = 0;
    public bool starter = false;

    void Start()
    {
        if (overrideMaterial == 1)
        {
            GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("Materials/Rupees/rupee_blue");
            transform.FindChild("core").gameObject.GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("Materials/Rupees/rupee_blue");
        }
        if (overrideMaterial == 2)
        {
            GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("Materials/Rupees/rupee_red");
            transform.FindChild("core").gameObject.GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("Materials/Rupees/rupee_red");
        }
        if (overrideMaterial == 3)
        {
            GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("Materials/Rupees/rupee_gold");
            transform.FindChild("core").gameObject.GetComponent<Renderer>().sharedMaterial = Resources.Load<Material>("Materials/Rupees/rupee_gold");
        }
    }

    void FixedUpdate ()
    {
        if (t < destroyTimer)
            t++;
        else if (destroyTimer > 0)
            Destroy(gameObject);
    }

    public void hit ()
    {
        GameObject.Find("Player").GetComponent<Player>().points += pointValue;
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);

        if (starter)
        {
            GameObject spawner = GameObject.Find("spawners").transform.GetChild(
                (int)Random.Range(0, GameObject.Find("spawners").transform.childCount - 1)).gameObject;
            Debug.Log(spawner.name);
            GameObject.Find("Player").GetComponent<Player>().gameStarted = true;
            spawner.GetComponent<Spawner>().spawn();
        }
    }
}
