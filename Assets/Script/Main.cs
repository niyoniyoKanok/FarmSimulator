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

        foreach (var animal in FarmAnimals)
        {
            animal.MakeSound();
            animal.Feed(5);
        }

        cow.Produce();
        cow.GetStatus();
        cow.Moo();
        cow.Produce();


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
        }
    }
}
