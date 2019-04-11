using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField]
    private State nextState;

    [SerializeField]
    private AICharacter yo;

    public State NextState { get => nextState; set => nextState = value; }
    public AICharacter Yo { get => yo;}

    public abstract void Execute();

    /*
    protected void SwitchToNextState()
    {
        if (NextState != null)
        {
            Toggle(false);
            NextState.Toggle(true);
        }
    }

    public void Toggle(bool val)
    {
        this.enabled = val;

        if (val)
        {
            Execute();
        }
    }
    */
    // Verificar distancia entre el jugador y yo.
    public float CheckDistanceToPlayer()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);

        return distance;
    }
}