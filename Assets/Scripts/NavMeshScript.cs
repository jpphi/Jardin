using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    private Animator _animatorController;
    private NavMeshAgent _navMashAgent;

    private const float TESTARRIVE = 0.2f;

    [SerializeField] private GameObject destination;

    private GameObject[] destinations;

    private int position = 0, positionEnd= 0;
    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _navMashAgent= GetComponent<NavMeshAgent>();

        _navMashAgent.SetDestination(destination.transform.position);

        destinations= GameObject.FindGameObjectsWithTag("NavMeshPoint");

        positionEnd = destinations.Length -1;
        position= 0;

        Debug.Log("destinations count " + positionEnd);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("En route vers avant if: " + destinations[position].transform.position + " position perso " + transform.position +
            " _navMashAgent.destination " + _navMashAgent.destination + " _navMashAgent.destination Magnitude " + 
            (_navMashAgent.destination - transform.position).magnitude);

        if ( (_navMashAgent.destination - transform.position).magnitude < TESTARRIVE)
        {
            Debug.Log("En route vers: " + destinations[position].transform.position);
            position++;
            if (position >= destinations.Length)
            {
                position = 0;
            }
            _navMashAgent.SetDestination(destinations[position].transform.position);
        }

        //_animatorController.SetFloat("Speed", _navMashAgent.velocity.magnitude);

    }
}
