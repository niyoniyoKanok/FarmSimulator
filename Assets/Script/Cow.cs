using UnityEngine;

public class Cow : Animal
{
    private float milk;
    public float Milk
    {
        get { return milk; }
        set
        {
            if (value < 0)
                milk = 0;
            else if (value > 50)
                milk = 50;
            else
                milk = value;
        }
    }
    public void Init(string newName, int newHunger, int newHappiness,int newMilk)
    {
        base.Init(newName, newHunger, newHappiness);
        newMilk = 0;
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
}
