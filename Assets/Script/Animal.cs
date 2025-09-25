using UnityEngine;
using UnityEngine.InputSystem.Switch;

public enum FoodType
{
    Hay,
    Grain,
    Fish,
    RottenFood,
    AnimalFood,
}


public abstract class Animal : MonoBehaviour
{
  //  private FoodType lastFoodFed = FoodType.Hay;
  //  private int sameFoodCount = 0;
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
        //โค้ดเช็คประเภทอาหาร
        /*
        CheckSameFood(foodType);
        int favouriteFoodHappniessChange = 0;
        if (sameFoodCount > 2)
        {
            favouriteFoodHappniessChange = 5;
            AdjustHappiness(-favouriteFoodHappniessChange);      
            Debug.Log($"{Name} is fully content or too bored with {foodType}. Happiness will NOT increase.");
        } */
        AdjustHunger(-foodAmount);
        int happinessIncrease = 0;
        int happinessDecrease = 0;
        if (foodType == PreferredFood)
        {
            happinessIncrease = 15;
            AdjustHappiness(happinessIncrease);
            Debug.Log($"{Name} receives its favorite food: {foodType}, receives {foodAmount} units, its Happiness increase by {happinessIncrease}, its current Happiness is {Happiness}, Hunger is {Hunger}");
        }

        else if (foodType == FoodType.RottenFood)
        {
            happinessDecrease = 20;
            AdjustHappiness(-happinessDecrease);
            Debug.Log($"{Name} has suffered from {foodType}, resulting Happiness decrease by {happinessDecrease} , its current Happiness is {Happiness}, Hunger is {Hunger}");
        }

        else if (foodType == FoodType.AnimalFood)
        {
            Debug.Log($"You gave {Name} some food; it didn’t really like it, but it could eat it, its current Happiness is {Happiness}, Hunger is {Hunger}");
        }

        else
        {
            happinessDecrease = 5;
            AdjustHappiness(-happinessDecrease);
            Debug.Log($"{Name} dislikes the food. The food given is {foodType}, receives {foodAmount} units, its Happiness decreases by {-happinessDecrease}, its current Happiness is {Happiness}, Hunger is {Hunger}");
        }
    }
        

    

    public void GetStatus()
    {
        Debug.Log($"Current {Name} status : Hunger = {Hunger} point , Happiness = {Happiness} point");
    }

public abstract string Produce();

    //โค้ดเช็คประเภทอาหาร
 /*   private void CheckSameFood(FoodType currentFood)
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
        } */

 }





