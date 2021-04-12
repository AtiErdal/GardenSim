using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] GameObject[] tools = null;
    GameObject current;

    private void Start()
    {
        current = tools[0];
        create();
    }
    private void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            createHandTool();
        }
        else if (Input.GetKeyDown("4"))
        {
            createShovelTool();
        }
        else if (Input.GetKeyDown("5"))
        {
            createSprayerTool();
        }
    }
    private void create()
    {
        current = Instantiate(current, gameObject.transform.position, Quaternion.identity);
        current.transform.parent = gameObject.transform;
    }

    public void createHandTool()
    {
        destroy();
        current = tools[0];
        create();
    }
    public void createShovelTool()
    {
        destroy();
        current = tools[1];
        create();
    }
    public void createSprayerTool()
    {
        destroy();
        current = tools[2];
        create();
    }

    private void destroy()
    {
        Destroy(current);
    }
}
