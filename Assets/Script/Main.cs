using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
  public Cow cow;
    public Chicken chicken;
    public Penguin penguin;
    public List<Animal> FarmAnimals = new List<Animal>();
    private void Start()
    {
        cow.Init("Michael");
        chicken.Init("Jackson");
        penguin.Init("Penpen");

        FarmAnimals.Add(cow);
        FarmAnimals.Add(chicken);
        FarmAnimals.Add(penguin);
        Debug.Log("Welcome to farm simulator!");
        Debug.Log($"There are {FarmAnimals.Count} animals living in the Happy Farm!");

       foreach (var animal in FarmAnimals)
        {
            animal.GetStatus();
        }
        
        Debug.Log("");
       foreach (var animal in FarmAnimals)
        {
            animal.MakeSound();
            animal.Feed(5);
        }
    
        Debug.Log("");
        cow.Feed(10);
        chicken.Feed(FoodType.RottenFood,10);
        chicken.Feed(FoodType.AnimalFood,10);
        for (int i = 0; i < 3 ; i++) 
        {
            penguin.Feed(FoodType.Fish,20);
            penguin.Produce();
        }

        cow.AdjustHappiness(-1000); cow.AdjustHunger(-1000);
        cow.GetStatus();
        cow.AdjustHappiness(+1000); cow.AdjustHunger(+1000);
        cow.GetStatus();




    }
}

        /*      Debug.Log("Welcome to farm simulator!");
              Debug.Log($"There are {FarmAnimals.Count} animals living in the Happy Farm!");

              foreach (var animal in FarmAnimals)
              {
                  animal.GetStatus();
              }

              foreach (var animal in FarmAnimals)
              {
                  animal.MakeSound();
                  animal.Feed(5);
              } 

              cow.Produce();
              cow.GetStatus();
              cow.AdjustHappiness(15);
              cow.Moo();
              cow.Produce();
              chicken.Sleep();
              chicken.Produce();
              chicken.AdjustHappiness(20);
              chicken.Produce();
              penguin.AdjustHappiness(30);
              penguin.GetStatus();
              penguin.Produce();


              cow.Feed(FoodType.Hay, 10);
              penguin.Feed(FoodType.Grain,10);
              chicken.Feed(FoodType.Grain,10);
              cow.AdjustHappiness(-1000);
              cow.GetStatus();
              cow.AdjustHappiness(+1000);
              cow.GetStatus();

              for (int i = 0; i < 3; i++)
              {
                  penguin.Feed(FoodType.Fish, 10);
              } */
