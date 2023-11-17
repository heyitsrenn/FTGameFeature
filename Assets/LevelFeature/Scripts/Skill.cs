using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public enum State 
    { 
        Locked, 
        Unlocked, 
        Activated
    }
    public State state;

    public void SetState(State _state)
    {
        state = _state;
    }
}
