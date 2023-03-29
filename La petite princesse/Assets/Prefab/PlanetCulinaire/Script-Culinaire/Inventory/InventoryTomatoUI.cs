using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryTomatoUI : MonoBehaviour
{
    private TextMeshProUGUI TomatoText;

    // Start is called before the first frame update
    void Start()
    {
        TomatoText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTomatoText(Inventory playerInventory)
    {
        TomatoText.text = playerInventory.NumberOfTomato.ToString() + "/2";
        /*if (playerInventory.NumberOfTomato == 1)
        {
            TomatoText.enabled = false;
        }*/
    }
}
