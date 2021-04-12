using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    public InventoryScript inventory;
    public bool inventoryEnabled;
    public GameObject showInventory;
    public GameObject instructions;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Plant")
        {
            instructions.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                var item = other.GetComponent<GroundItem>();
                if (item)
                {
                    inventory.AddItem(new Item(item.item),1);
                    Destroy(other.gameObject);
                    instructions.SetActive(false);
                }
            }
    }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plant")
        {
            instructions.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryEnabled)
            {
                inventoryEnabled = false;
                FindObjectOfType<MouseLook>().freezeCamera(false);
            }
            else
            {
                inventoryEnabled = true;
                FindObjectOfType<MouseLook>().freezeCamera(true);
            }
                
            //inventoryEnabled = !inventoryEnabled;
        }
            

        if (inventoryEnabled == true)
        {
            showInventory.SetActive(true);
        }
        else
        {
            showInventory.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[32];
    }
}
