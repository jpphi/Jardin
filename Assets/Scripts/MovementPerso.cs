using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementPerso : MonoBehaviour
{
    private Animator _animatorController;
    private NavMeshAgent _navMashAgent;

    private const float TESTARRIVE = 0.2f;

    //[SerializeField] private GameObject destination;

    private GameObject[] destinations;

    private int position = 0, nbPoints= 0;

    private float _force = 300f, velocity= 0f;

    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _navMashAgent= GetComponent<NavMeshAgent>();

        destinations= GameObject.FindGameObjectsWithTag("NavMeshPoint");

        nbPoints = destinations.Length;

        InitBehavior();

        //_animatorController.SetTrigger("Jump");
        //GetComponent<Rigidbody>().AddForce(Vector3.up * _force);

    }

    public void InitBehavior()
    {
        if (nbPoints > 1)
        {
            //position = 1;
            _navMashAgent.isStopped = false;

            _navMashAgent.SetDestination(destinations[position].transform.position);

        }

    }

    public void MovePerso()
    {
        //Debug.Log("En route vers avant if: " + destinations[position].transform.position + " position perso " + transform.position +
        //    " _navMashAgent.destination " + _navMashAgent.destination + " _navMashAgent.destination Magnitude " +
        //    (_navMashAgent.destination - transform.position).magnitude);

        _navMashAgent.isStopped = false;

        if ((_navMashAgent.destination - transform.position).magnitude < TESTARRIVE)
        {
            position++;
            if (position >= nbPoints)
            {
                position = 0;
            }

            Debug.Log("Arrivée... ! En route vers: " + destinations[position].transform.position);
            _navMashAgent.SetDestination(destinations[position].transform.position);

            //_animatorController.SetTrigger("Jump");
            //GetComponent<Rigidbody>().AddForce(Vector3.up * _force);

        }

        Debug.Log("Velocity: ? _navMashAgent.velocity.magnitude= " + _navMashAgent.velocity.magnitude);
        velocity = Mathf.Clamp(_navMashAgent.velocity.magnitude, 0f, 9f); //  * Time.deltaTime 
        _animatorController.SetFloat("Speed", velocity);

    }


    public void StopPerso()
    {
        _navMashAgent.isStopped = true;
        _navMashAgent.velocity = Vector3.zero;
        _animatorController.SetFloat("Speed", 0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Contact sol");

            _animatorController.SetTrigger("TouchGround");
        }
    }
}
