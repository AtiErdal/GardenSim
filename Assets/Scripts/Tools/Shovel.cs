using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Shovel : MonoBehaviour
{

    [SerializeField] GameObject placeableObjectPrefab = null;
    [SerializeField] GameObject previewObject = null;
    [SerializeField] GameObject Full_Dirt = null;
    GameObject preview, plants, current;
    int layer_mask;

    Camera fpsCam;

    private void Awake()
    {
        layer_mask = LayerMask.GetMask("Soil");
    }

    private void Start()
    {
        fpsCam = GameObject.FindObjectOfType<Camera>();
    }


    private void Update()
    {
        MoveCurrentPlaceableObjectToMouse();
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {

        RaycastHit hitInfo;

        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.SphereCast(ray.origin, 0.5f, ray.direction, out hitInfo, 5, layer_mask);

        if (isHit && hitInfo.collider.tag == "Soil")
        {
            if (preview == null)
            {
                preview = Instantiate(previewObject);
            }

            preview.transform.position = hitInfo.point + new Vector3(0.017f, 0.055f, 0.109f);

            if (Input.GetMouseButtonDown(0))
            {
                plants = Instantiate(placeableObjectPrefab, hitInfo.point + new Vector3(0.017f, 0.055f, 0.109f), Quaternion.identity);
                //DONT DELETE THIS COMMENT hitInfo.point + new Vector3(0.017f,0,0.109f)
                plants.transform.parent = GameObject.Find("PLANTS").gameObject.transform;
                Destroy(preview);
            }
        }
        else if (isHit && hitInfo.collider.tag == "Pile")
        {
            Destroy(preview);
            if (Input.GetMouseButtonDown(0))
            {
                preview = hitInfo.collider.transform.gameObject;
                if (preview.transform.childCount == 0)
                {
                    Destroy(preview);
                }
                else if (preview.transform.childCount == 1)
                {
                    current = Instantiate(Full_Dirt, preview.transform.position, Quaternion.identity);

                    current.transform.parent = GameObject.Find("PLANTS").transform;

                    preview.transform.GetChild(0).parent = current.transform;

                    Destroy(preview);
                }
            }
        }
        else
        {
            Destroy(preview);
        }
    }

    private void OnDestroy()
    {
        Destroy(preview);
    }
}
