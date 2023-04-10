using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryEggUI : MonoBehaviour
{
    private TextMeshProUGUI EggText;

    // Start is called before the first frame update
    void Start()
    {
        EggText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateEggText(Inventory playerInventory)
    {
        EggText.text = playerInventory.NumberOfEggs.ToString() + "/2";
       
    }
}
