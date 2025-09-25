using UnityEngine;

public class Cow : Animal
{
    private float milk;
    public float Milk
    {
        get { return milk; }
        private set
        {
            if (value < 0)
                milk = 0;
            else if (value > 50)
                milk = 50;
            else
                milk = value;
        }
    }
    public void Init(string newName)
    {
        base.Init(newName, Hunger, Happiness);
        Milk = 0;
        PreferredFood = FoodType.Hay;
    }



    public override void MakeSound()
    {
        Debug.Log($"{Name} says Moo!");
    }
 
    public void Moo()
    {
        AdjustHappiness(20);
        Debug.Log($"{Name} gives a loud MooMooMoo, Current Happiness {Happiness}!");
        GetStatus();

    }

    public override string Produce()
    {
        string logMessage = "";
        int milkProduced = 0;
        if (Happiness > 70)
        {
            milkProduced = Happiness / 10;
        }

        else
        {
            logMessage = $"{Name} is not in the mood to produce milk. Total milk: {Milk}";
            Debug.Log(logMessage);
            return logMessage;
        }


        logMessage = $"{Name} produces {milkProduced} units.";
        Debug.Log(logMessage);
        return logMessage;
    }
}
