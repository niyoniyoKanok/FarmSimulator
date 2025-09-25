using UnityEngine;

public class Chicken : Animal
{
    private int egg;
    public int Egg
    {
        get { return egg; }
        private set
        {
            if (value < 0)
                egg = 0;
            else if (value > 50)
                egg = 50;
            else
                egg = value;
        }
    }
    public void Init(string newName)
    {
        base.Init(newName, Hunger,Happiness);
        Egg = 0;
        PreferredFood = FoodType.Grain;
    }


    public override void MakeSound()
    {
        Debug.Log($"{Name} says Ekk!");
    }
    public void Sleep()
    {
        AdjustHunger(5);
        AdjustHappiness(20);
    Debug.Log($"{Name} slept and feels a little hungry, but very happy!");
        GetStatus();
    }

    public override string Produce()
    {
        string logMessage = "";
        int eggLaid;
        if (Happiness > 80)
        {
            eggLaid = 3;
          
        }

        else if (Happiness >= 51)
        {
            eggLaid = 2;

        }
        else
        {
            eggLaid = 0;
            logMessage = $"{Name} is not in the mood to lay egg. Total egg {Egg}";
            Debug.Log(logMessage);
            return logMessage;
        }


        Egg += eggLaid;
        logMessage = $"{Name} laid {eggLaid} eggs, Total egg is {Egg} units.";
        Debug.Log(logMessage);
        return logMessage;
    }


}
