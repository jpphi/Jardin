using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
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

        //positionEnd = destinations.Length -1;
        nbPoints= destinations.Length;

        if (nbPoints > 1 )
        {
            position = 1;
            _navMashAgent.SetDestination(destinations[position].transform.position);

        }

        //Debug.Log("destinations count " + positionEnd);

        _animatorController.SetTrigger("Jump");
        GetComponent<Rigidbody>().AddForce(Vector3.up * _force);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("En route vers avant if: " + destinations[position].transform.position + " position perso " + transform.position +
            " _navMashAgent.destination " + _navMashAgent.destination + " _navMashAgent.destination Magnitude " + 
            (_navMashAgent.destination - transform.position).magnitude);

        if ((_navMashAgent.destination - transform.position).magnitude < TESTARRIVE)
        {
            Debug.Log("En route vers: " + destinations[position].transform.position);
            position++;
            if (position >= nbPoints)
            {
                position = 0;
            }
            _navMashAgent.SetDestination(destinations[position].transform.position);

            _animatorController.SetTrigger("Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * _force);

        }

        velocity = Mathf.Clamp(_navMashAgent.velocity.magnitude, 0f, 5f); //  * Time.deltaTime 
        _animatorController.SetFloat("Speed", velocity);

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
