using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {
    Vector3 aimAt;
    GameObject player;
    GameObject arrow;
    bool arrowReady = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        arrow = transform.FindChild("arrow").gameObject;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        aimAt = player.GetComponent<Player>().aimloc;
        transform.LookAt(aimAt);
        transform.position = Vector3.Lerp(transform.position,
            player.transform.position + (0.8f * Vector3.forward - 0.1f * player.transform.right - 0.55f * Vector3.up),
            15.0f * Time.deltaTime);
        if (arrowReady)
            arrow.transform.localPosition = Vector3.Lerp(arrow.transform.localPosition,
                new Vector3(-0.0284f, 0.0402f, -0.015f), 
                8.0f * Time.deltaTime);
    }

    public void readyArrowAnim()
    {
        arrow.SetActive(true);
        arrowReady = true;
    }
    public void unreadyArrowAnim()
    {
        arrow.SetActive(false);
        arrowReady = false;
        arrow.transform.localPosition = new Vector3(-0.0284f, 0.0402f, 0.237f);
    }
}
