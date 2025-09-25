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

    public override string Produce()
    {
        string logMessage = "";
        int guanoRush = 0;
        if (Hunger <= 20 && Happiness >= 50)
        {
            guanoRush += 5;
        }

        else if (Hunger <= 40 && Happiness >= 50)
        {
            guanoRush += 3;
        }

        else if (Hunger <= 50 && Happiness >= 50)
        {
            guanoRush = 1;
        }

        else
        {
            guanoRush = 0;
            logMessage  = $"{Name} is not in the mood to produce guano. Total guano: {Guano}";
            Debug.Log(logMessage);
            return logMessage;
        }

        Guano += guanoRush;
        logMessage = $"{Name} produced {guanoRush} units of guano, Total guano is {Guano} units.";      
        Debug.Log(logMessage);
        return logMessage;
    }
}
