using UnityEngine;

public class Penguin : Animal
{
    private float guano;
    public float Guano
    {
        get { return guano; }
        private set
        {
            if (value < 0)
                guano = 0;
            else if (value > 50)
                guano = 50;
            else
                guano = value;
        }
    }

    public void Init(string newName)
    {
        base.Init(newName, Hunger, Happiness);
        Guano = 0;
        PreferredFood = FoodType.Fish;
    }

    public override void MakeSound()
    { 
        Debug.Log($"{Name} says Honk!");
    }

    public override void Produce()
    {
       if (Happiness >= 70)
        {
            guano += 2;
            Debug.Log($"{Name} produced {guano} units of guano, Total guano is {guano}.");

        }
    }
}
