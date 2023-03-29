using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryFlourUI : MonoBehaviour
{
    private TextMeshProUGUI TomatoText;

    // Start is called before the first frame update
    void Start()
    {
        TomatoText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFlourText(Inventory playerInventory)
    {
        TomatoText.text = playerInventory.NumberOfFlour.ToString() + "/1";
       
    }
}
