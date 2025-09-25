using UnityEngine;
using UnityEngine.InputSystem.Switch;

public enum FoodType
{
    Hay,
    Grain,
    Fish,
}


public abstract class Animal : MonoBehaviour
{
    private FoodType lastFoodFed = FoodType.Hay;
    private int sameFoodCount = 0;
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
    public FoodType PreferredFood { get; protected set; }

    public int Hunger
    {
        get { return hunger; }
        private set
        {
            if (value < 0)
                hunger = 0;
            else if (value > 100)
                hunger = 100;
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
            else if (value > 100)
                happiness = 100;
            else
                happiness = value;

        }
    }
    public virtual void Init(string newName, int newHunger, int newHappiness)
    {
        Name = newName;
        Hunger = 50;
        Happiness = 50;
    }

    public void AdjustHunger(int increaseHunger)
    {
        Hunger += increaseHunger;
    }

    public void AdjustHappiness(int increaseHappiness)
    {
        Happiness += increaseHappiness;
    }

    public abstract void MakeSound();

    public virtual void Feed(int foodAmount)
    {
        AdjustHunger(-foodAmount);
        int happinessIncrease = foodAmount / 2;
        AdjustHappiness(happinessIncrease);
        Debug.Log($"{Name} was fed {foodAmount} units of food.Happiness increased by {happinessIncrease} ");
    }

    public virtual void Feed(FoodType foodType, int foodAmount)
    {
        AdjustHunger(-foodAmount);
        CheckSameFood(foodType);

        int favouriteFoodHappniessChange = 0;
        if (sameFoodCount > 2)
        {
            AdjustHappiness(-foodAmount);      
            Debug.Log($"{Name} is fully content or too bored with {foodType}. Happiness will NOT increase.");
        }
        if (foodType == PreferredFood)
        {
            favouriteFoodHappniessChange = foodAmount;
            AdjustHappiness(favouriteFoodHappniessChange);
            Debug.Log($"The happy animal receives its favorite food ({foodType}), name : {Name}, receives {foodAmount} units, its current Happiness is {Happiness}");
        }

        else
        {
            favouriteFoodHappniessChange = -(foodAmount / 2);
            AdjustHappiness(favouriteFoodHappniessChange);
            Debug.Log($"The animal dislikes the food. The food name given is {foodType}, name : {Name}, receives {foodAmount} units, its Happiness decreases by {favouriteFoodHappniessChange},its current Happiness is {Happiness}");
        }

    }

    public void GetStatus()
    {
        Debug.Log($"Current {Name} status : Hunger = {Hunger} point , Happiness = {Happiness} point");
    }

    public abstract void Produce();

    private void CheckSameFood(FoodType currentFood)
    {
        if (currentFood == lastFoodFed)
        {
            sameFoodCount++;
            int happinessdecrease = 5;
            if (sameFoodCount > 2)
            {
               AdjustHappiness(-happinessdecrease);
                Debug.Log($"{Name} is bored with {lastFoodFed}, so Happiness decreases by {happinessdecrease}, its current Happiness is {Happiness}.");
            }
        }
        else
        {
            sameFoodCount = 1;
            lastFoodFed = currentFood;
        }

    }
}




