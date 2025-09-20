using UnityEngine;

public class Penguin : Animal
{

    public void Init(string newName, int newHunger, int newHappiness)
    {
        base.Init(newName, newHunger, newHappiness);
    }

    public override void MakeSound()
    { 
        Debug.Log($"{Name} says Honk!");
    }
}
