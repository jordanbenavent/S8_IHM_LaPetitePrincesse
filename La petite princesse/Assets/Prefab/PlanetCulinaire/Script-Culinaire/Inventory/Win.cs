using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class Win : MonoBehaviour
{
    private TextMeshProUGUI WinText;

    // Start is called before the first frame update
    void Start()
    {
        WinText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateWinText(Inventory playerInventory)
    {
        if (playerInventory.NumberOfIngredients == 9)
        {
            WinText.text = "You have all the ingredients for the pizza !!";
            StartCoroutine(DisplayTextForTwoSeconds());
        }
        //You win
        menuManager mM = FindObjectOfType<menuManager>();
        mM.givePizzaTrophy();
        SceneManager.LoadScene(0);  
    }

    private IEnumerator DisplayTextForTwoSeconds()
    {
        yield return new WaitForSeconds(2f);
        WinText.text = "";
    }
}
