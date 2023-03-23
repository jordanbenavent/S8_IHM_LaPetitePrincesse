using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Inventory : MonoBehaviour
{

    public int NumberOfIngredients { get; private set; }
    public int NumberOfCheese { get; private set; }
    public int NumberOfEggs { get; private set; }
    public int NumberOfTomato { get; private set; }
    public int NumberOfFlour { get; private set; }

    public UnityEvent<Inventory> OnCheeseCollected;

    public void IngredientCollected()
    {
        NumberOfIngredients++;        
        //OnIngredientCollected.Invoke(this);
    }
    
    public void CheeseCollected()
    {
        NumberOfCheese++;
        OnCheeseCollected.Invoke(this);
    }
    
    public void EggsCollected()
    {
        NumberOfEggs++;
        OnCheeseCollected.Invoke(this);
    }
    
    public void TomatoCollected()
    {
        NumberOfTomato++;
        OnCheeseCollected.Invoke(this);
    }
    
    public void FlourCollected()
    {
        NumberOfFlour++;
        OnCheeseCollected.Invoke(this);
    }
}
