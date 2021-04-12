using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public GameObject[] seeds;
    GameObject currendSeed;
    Camera fpsCam;

    int layer_mask;


    private void Awake()
    {
        layer_mask = LayerMask.GetMask("Soil");
    }
    private void Start()
    {
        fpsCam = GameObject.FindObjectOfType<Camera>();
    }
    void Update()
    {
        if (seeds.Length != 0)
        {
            PlaceSeed();
        }

    }
    void selectPlant()
    {
        if (Input.GetKeyDown("1"))
        {
            currendSeed = seeds[0];
        }
        else if (Input.GetKeyDown("2"))
        {
            currendSeed = seeds[1];
        }
    }

    private void PlaceSeed()
    {
        selectPlant();
        RaycastHit hitInfo;

        if (Physics.SphereCast(fpsCam.ScreenPointToRay(Input.mousePosition), 0.5f, out hitInfo, 5, layer_mask) && hitInfo.collider.tag == "Pile")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currendSeed != null)
                {
                    if (hitInfo.transform.childCount == 0)
                    {
                        var plant = Instantiate(currendSeed, hitInfo.collider.transform.position, Quaternion.identity);
                        plant.transform.parent = hitInfo.collider.transform;
                    }
                }
            }
        }
    }
}
