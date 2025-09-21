using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    private string name;
    private int hunger;
    private int happiness;
    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                name = "Michael";
            else
                name = value;
        }
    }

    public int Hunger
    {
        get { return hunger; }
        private set
        {
            if (value < 0)
                hunger = 0;
            else if (value > 50)
                hunger = 50;
            else
                hunger = value;
        }
    }

    public int Happiness
    {
        get { return happiness; }
        private set
        {
            if (value < 0)
                happiness = 0;
            else if (value > 50)
                happiness = 50;
            else
                happiness = value;

        }
    }
    public virtual void Init(string newName, int newHunger, int newHappiness)
    {
        Name = newName;
        Hunger = newHunger;
        Happiness = newHappiness;
    }

    public void AdjustHunger(int increaseHunger)
    {
        Hunger += increaseHunger;
    }

    public void AdjustHappiness(int increaseHappiness)
    {
        Happiness += increaseHappiness;
    }

    public virtual void MakeSound()
    {
        Debug.Log($"{Name} says Cluck!");
    }

    public virtual void Feed(int foodAmount)
    {
        AdjustHunger(-foodAmount);
        Debug.Log($"{Name} was fed {foodAmount} units of food. ");
    }

    public virtual void Feed(string foodType, int foodAmount)
    {
        AdjustHunger(-foodAmount);
        Debug.Log($"{Name} was fed {foodAmount} of {foodType}.");
    }

    public void GetStatus()
    {
        Debug.Log($"Current {Name} status : Hunger = {Hunger} point , Happiness = {Happiness} point");
    }

}




