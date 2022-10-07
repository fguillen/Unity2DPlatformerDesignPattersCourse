using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateManager : MonoBehaviour
{
    [SerializeField] List<State> states;

    public State currentState { get; private set; }

    void Awake()
    {
        states = GetComponentsInChildren<State>().ToList();
    }

    void Update()
    {
        currentState?.StateUpdate();
    }

    void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
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

        if(currentState == null)
            throw new ArgumentException($"State not found: '{stateType}'");

        currentState.Enter();
    }

    State GetStateByType(StateType type)
    {
        return states.Find((e) => e.Type() == type);
    }
}
