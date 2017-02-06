using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public int deleteTime = 120;
    int t = 0;
    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
            
        }
        else
        {
            var em = transform.FindChild("trail").gameObject.GetComponent<ParticleSystem>().emission;
            em.rateOverTime = new ParticleSystem.MinMaxCurve(0);
        }

        if (t < deleteTime)
            t++;
        else
            GameObject.DestroyImmediate(this.gameObject);

    }
    void OnTriggerEnter (Collider c)
    {
        if (c.gameObject.layer == 8)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            if (c.gameObject.GetComponent<Shootable>() != null)
            {
                c.gameObject.GetComponent<Shootable>().hit();
                GameObject.Destroy(this.gameObject);
            }
        } 
    }
}
