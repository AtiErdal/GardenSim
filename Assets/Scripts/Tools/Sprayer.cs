using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprayer : MonoBehaviour
{
    Camera fpsCam;

    private void Start()
    {
        fpsCam = GameObject.FindObjectOfType<Camera>();
    }

    private void Update()
    {
        gameObject.transform.rotation = fpsCam.transform.rotation;
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }
    /*
    private void OnParticleCollision(GameObject other)
    {
        //other.transform.GetComponent<Feeding>().ModifyWater(+0.5f);
        other.transform.GetComponent<Grow>().grow();
    }
    */
    private void OnDestroy()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }
}
