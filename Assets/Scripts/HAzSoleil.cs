using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HAzSoleil : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _jour;
    [SerializeField] private double _heure;
    [SerializeField] private double _latitude = 45;
    //[SerializeField] private float temps = 0.1f;

    [SerializeField] private ScObj _scobj;

    [SerializeField] private Slider _slider;

    //private Temps _temps;

    private double declinaison;
    private double angleHoraire;
    private double azimut;
    private double hauteur;

    private bool tempo;

    void Start()
    {
        _jour = 181; _heure = 10f;
        _latitude = Mathf.PI * _latitude / 180;

        _scobj.TempsUniversel = 0f;


        tempo = false;

        //_temps = gameObject.AddComponent<Temps>();

        calculHAz(_jour, (float)_heure);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(tempsQuiPasse());
        if (tempo)
        {
            tempo = false;
            float deltatps = 1 / _scobj.AccTemps;
            _heure = _heure + deltatps;
            _scobj.TempsUniversel += deltatps;


            Debug.Log("HAzSoleil Update. _heure " + _heure + " _scobj.AccTemps " + _scobj.AccTemps);

            if (_heure >= 24)
            {
                _heure = 0;
                _jour++;

                if (_jour >= 366)
                {
                    _jour = 1;
                }

                // On change la valeur du coef du shader en fonction du jour
                //_temps.GestionSaison(); //_jour

                _scobj.jour = _jour;

            }
            calculHAz(_jour, (float)_heure);
        }
    }

    private IEnumerator tempsQuiPasse()
    {
        yield return new WaitForSeconds(1);
        tempo = true;

    }

    private void calculHAz(int j, float h) // j= jour h= heure
    {
        angleHoraire = Mathf.PI * (h / 12 - 1);
        declinaison = Mathf.Asin((float)0.398 * Mathf.Sin((float)(0.985 * j - 80)));

        hauteur = Mathf.Asin(Mathf.Sin((float)_latitude) * Mathf.Sin((float)declinaison) + Mathf.Cos((float)_latitude) *
            Mathf.Cos((float)declinaison) * Mathf.Cos((float)angleHoraire));

        azimut = Mathf.Asin(Mathf.Cos((float)declinaison) * Mathf.Sin((float)angleHoraire) / Mathf.Cos((float)hauteur));

        hauteur = 180 * hauteur / Mathf.PI;
        azimut = 180 * azimut / Mathf.PI;
        Debug.Log(" _jour= " + _jour + " heure = " + h + " hauteur= " + hauteur + " azimut= " + azimut);

        transform.rotation = Quaternion.Euler((float)hauteur, (float)azimut, 0);

    }

    public void ValueChanged()
    {
        _scobj.AccTemps = _slider.value;
        Debug.Log("ValueChanged, Temps... : " + _scobj.AccTemps);
    }

 
}