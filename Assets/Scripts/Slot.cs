using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string desc;
    public bool empty;

    public Transform slotIconGo;
    public Sprite icon;

    private void Start()
    {
        slotIconGo = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        slotIconGo.GetComponent<Image>().sprite = icon;
    }
}
