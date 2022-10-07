using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateManager : MonoBehaviour
{
    [SerializeField] List<State> states;

    public State currentState { get; private set; }

    void Awake()
    {
        states = GetComponents<State>().ToList();
    }

    public void Initialize(Agent agent)
    {
        foreach (var state in states)
            state.Initialize(agent);
    }

    public void TransitionToState(StateType stateType)
    {
        Debug.Log($"TransitionToState({stateType})");

        currentState?.Exit();
        currentState = GetStateByType(stateType);
        currentState?.Enter();
    }

    State GetStateByType(StateType type)
    {
        return states.Find((e) => e.Type() == type);
    }
}
