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
    public void Init(string newName, int newHunger, int newHappiness,int newEgg)
    {
        base.Init(newName,newHunger,newHappiness);
        newEgg = 0;
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


}
