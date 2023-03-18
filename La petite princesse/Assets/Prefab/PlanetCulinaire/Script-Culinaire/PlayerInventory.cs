using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfIngredients { get; private set; }

    public UnityEvent<PlayerInventory> OnIngredientCollected;

    public void IngredientCollected()
    {
        NumberOfIngredients++;
        OnIngredientCollected.Invoke(this);
    }
}