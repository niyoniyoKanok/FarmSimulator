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
        cow.Init("Michael", 50, 10);
        chicken.Init("Jackson", 40, 10);
        penguin.Init("Penpen", 30, 10);
        
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

        foreach (var animal in FarmAnimals)
        {
            Debug.Log("");
            if (animal is Cow)
            {
                animal.Feed("Hay", 5);
                cow.Moo();
            }
            else if (animal is Chicken)
            {
                animal.Feed("Corn", 3);
                chicken.Sleep();
            }
            else if (animal is Penguin)
            {
                animal.Feed("Fish", 4);
            }           
        }

    }
}
