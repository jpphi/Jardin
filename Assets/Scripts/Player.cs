using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;
    [SerializeField] private Slider _slider;

    void Start()
    {
        //Debug.Log("Temps... : " + _scobj.AccTemps);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quitter()
    {
        //Debug.Log("Quitter !");

        Application.Quit();
    }


    public void ValueChangedPasTemporel()
    {
        _scobj.pasTemporel = _slider.value;
        //Debug.Log("ValueChangedPasTemporel, PasTemporel... : " + _scobj.pasTemporel);
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

