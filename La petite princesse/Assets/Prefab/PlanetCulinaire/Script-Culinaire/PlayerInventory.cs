using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfIngredients { get; private set; }

    public UnityEvent<PlayerInventory> OnIngredientCollected;

    public void IngredientCollected()
    {
        NumberOfIngredients++;
        Console.WriteLine("Number of collected ingredients : " + NumberOfIngredients);
        if (NumberOfIngredients == 4)
        {
            Console.WriteLine("All ingredients are collected !");
        }
        OnIngredientCollected.Invoke(this);

        
    }
}