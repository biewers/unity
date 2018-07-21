using UnityEngine;

public class GameState : MonoBehaviour {

    public static State currentState = State.WORLD;

    public static State GetStateFromString(string name)
    {
        switch(name)
        {
            case "NA":
                return State.NA;
                
            case "SA":
                return State.SA;
                
            case "AF":
                return State.AF;
                
            case "ME":
                return State.ME;
                
            case "EU":
                return State.EU;
                
            case "AS":
                return State.AS;
                
            case "OC":
                return State.OC;
                
            default:
                return State.WORLD;

        }
    }
}

public enum State
{
    WORLD, NA, SA, AF, ME, EU, AS, OC, LEVEL
}
