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

    public override void Produce()
    {
        if (Happiness >= 70)
        {
            Egg += 2;
            Debug.Log($"{Name} laid {Egg} eggs, Total egg is {Egg}");
        }
    }


}
