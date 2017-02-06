using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    bool firePushed = false;
    bool fireReleased = false;

    public int points = 0;

    int holdTimer = 0;
    int cooldown = 20;

    public Vector3 aimloc;
    Transform spawnerParent;

    public GameObject bow;

    public bool gameStarted = false;


    int spawnerTimer = 400;
    int t = 0;

	// Use this for initialization
	void Start () {
        bow.GetComponent<Bow>().unreadyArrowAnim();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spawnerParent = GameObject.Find("spawners").transform;
    }
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            firePushed = true;
            bow.GetComponent<Bow>().readyArrowAnim();
        }

        if (Input.GetButtonUp("Fire1"))
            fireReleased = true;

        
	}

    void FixedUpdate()
    {
        if (firePushed)
            holdTimer++;

        if (fireReleased && holdTimer >= cooldown)
        {
            bow.GetComponent<Bow>().unreadyArrowAnim();
            fire();
            fireReleased = false;
            firePushed = false;
            holdTimer = 0;
        }

        RaycastHit rh;
        if (Physics.Raycast(transform.position, transform.forward, out rh, 20))
        {
            aimloc = rh.point - (0.1f * transform.forward);
            transform.FindChild("crosshair").localPosition = new Vector3(0, 0, rh.distance - 0.3f);
            transform.FindChild("crosshair").localScale = 0.02f * rh.distance * Vector3.one;
            transform.FindChild("crosshair").LookAt(rh.point - rh.normal);
        }
        GameObject.Find("Canvas").transform.FindChild("val").gameObject.GetComponent<Text>().text = points.ToString();

        if (gameStarted && t < spawnerTimer)
            t++;
        else if (gameStarted && t >= spawnerTimer)
        {
            nextSpawner();
            t = 0;
        }
    }

    void fire()
    {
        GameObject arrow = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/arrow"));
        arrow.transform.position = bow.transform.position;
        arrow.transform.rotation = transform.rotation;
        arrow.GetComponent<Rigidbody>().velocity = 50 * bow.transform.forward;
    }

    void nextSpawner()
    {
        spawnerParent = GameObject.Find("spawners").transform;
        int next = (int)Random.Range(0, spawnerParent.childCount);
        GameObject spawner = spawnerParent.GetChild(next).gameObject;
        Debug.Log(spawner.name);
        spawner.GetComponent<Spawner>().spawn();
        if (spawnerTimer > 120)
            spawnerTimer -= 10;
    }

}
