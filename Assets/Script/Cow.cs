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

    public override void Produce()
    {
        if (Happiness >= 70)
        {
            Milk += 2;
            
            Debug.Log($"{Name} produces {Milk} liters of milk,Total milk is {Milk}");
        }
    }
}
