using UnityEngine;

public class AICharacter : Character
{
    [SerializeField]
    private State currentState;

    public void SetNewState(State newState)
    {
        currentState = newState;
    }

    public void Update()
    {
        currentState.Execute();
    }
}