using UnityEngine;
using UnityEngine.Events;

public class ExitDoor : MonoBehaviour
{
    public UnityEvent OnDoorActivated;

    Canvas canvas;
    bool doorTouched = false;
    bool doorActivated = false;

    void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }

    void Start()
    {
        canvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            DoorTouched(other.GetComponent<Agent>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            DoorUntouched(other.GetComponent<Agent>());
    }

    void DoorTouched(Agent agent)
    {
        agent.agentInput.OnMovement += DetectUpKey;
        doorTouched = true;
        canvas.enabled = true;
    }

    void DoorUntouched(Agent agent)
    {
        agent.agentInput.OnMovement -= DetectUpKey;
        doorTouched = false;
        doorActivated = false;
        canvas.enabled = false;
    }

    void DetectUpKey(Vector2 movement)
    {
        if(doorTouched && !doorActivated && movement.y >= 1)
        {
            doorActivated = true;
            OnDoorActivated?.Invoke();
        }

        if(movement.y < 1)
            doorActivated = false;
    }
}
