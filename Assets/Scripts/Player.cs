using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //[SerializeField] private ScObj _scobj;
    //[SerializeField] private Slider _slider;

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
        Debug.Log("Quitter !");

        Application.Quit();
    }


}
