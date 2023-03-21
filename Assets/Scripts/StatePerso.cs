using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(MovementPerso))]
public class StatePerso : MonoBehaviour
{
    enum PersoState
    {
        None,
        Patrol,
        Talk
    };

    [SerializeField] PersoState persoState;
    [SerializeField] PersoState nextPersoState;

    private MovementPerso movementPerso;

    // Start is called before the first frame update
    void Start()
    {
        movementPerso= GetComponent<MovementPerso>();
        nextPersoState= persoState = PersoState.Patrol;     
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();

        if(ChangeBehavior())
        {
            Transition();
        }

    }

    void Behavior()
    {

        switch(persoState)
        {
            case PersoState.Patrol:
                movementPerso.MovePerso();
                break;

            case PersoState.Talk:
                break;
        }

    }

    void Transition()
    {
        // Fin de l'état précédent
        EndState();

        persoState = nextPersoState;

        StartState();
    }

    void EndState()
    {
        switch (persoState)
        {
            case PersoState.Patrol:
                movementPerso.StopPerso();
                break;

            case PersoState.Talk:
                GetComponent<Animator>().SetBool("Talk", false);
                break;
        }
    }

    void StartState()
    {
        switch (persoState)
        {
            case PersoState.Patrol:
                movementPerso.InitBehavior();
                break;

            case PersoState.Talk:
                GetComponent<Animator>().SetBool("Talk", true);
                break;
        }
    }

    private bool ChangeBehavior()
    {

        Keyboard kb = Keyboard.current;

        switch (persoState)
        {
            case PersoState.Patrol:
                if (kb.tKey.wasPressedThisFrame)
                {
                    nextPersoState = PersoState.Talk;
                }
                break;

            case PersoState.Talk:
                if (kb.tKey.wasPressedThisFrame)
                {
                    nextPersoState = PersoState.Patrol;
                }
                break;
        }

        return (nextPersoState != persoState);
    }

}
