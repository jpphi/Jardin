using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;

    private bool tempo = false;

    public delegate void TicTac();
    public static TicTac EventTicTac;


    void Start()
    {
        //Debug.Log("Temps... : " + _scobj.AccTemps);

        StartCoroutine(tempsQuiPasse());

    }

    // Update is called once per frame
    void Update()
    {
        if (tempo)
        {
            tempo = false;
            //float deltatps = 0.1f;// / _scobj.AccTemps;
            _scobj.heure += _scobj.pasTemporel;
            _scobj.TempsUniversel += _scobj.pasTemporel;


            Debug.Log("Player Update. jourAn= " + _scobj.jourAn + " heure " + _scobj.heure + " _scobj.AccTemps " + _scobj.AccTemps +
                " jour " + _scobj.jour);

            if (_scobj.heure >= 24)
            {
                _scobj.heure = 0;
                _scobj.jourAn = (_scobj.jourAn >= 365) ? 1 : _scobj.jourAn + 1; // numéro du jour dans l'année

                // On change la valeur du coef du shader en fonction du jour
                //_temps.GestionSaison(); //_jour

                _scobj.jour++;

            }
            //calculHAz(_scobj.jourAn, _scobj.heure);
            if( EventTicTac!= null )
            {
                EventTicTac();
            }

            StartCoroutine(tempsQuiPasse());
        }
    }

    public void Quitter()
    {
        Debug.Log("Quitter !");

        Application.Quit();
    }

    public IEnumerator tempsQuiPasse()
    {
        yield return new WaitForSeconds(1 / _scobj.AccTemps);
        tempo = true;

    }


}


/*

public class ExampleClass : MonoBehaviour
{
    UnityEvent m_MyEvent;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();

        m_MyEvent.AddListener(Ping);
    }

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke();
        }
    }

    void Ping()
    {
        Debug.Log("Ping");
    }
}

 */

