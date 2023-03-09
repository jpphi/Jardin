using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAzSoleil : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private int _jour;
    //[SerializeField] private double _heure;
    //[SerializeField] private float temps = 0.1f;

    [SerializeField] private ScObj _scobj;

    //private Temps _temps;

    private float declinaison;
    private float angleHoraire;
    private float azimut;
    private float hauteur;
    private float _latitude;

    //private bool tempo;

    private void OnEnable()
    {
        Player.EventTicTac += calculHAz; 
    }

    private void OnDisable()
    {
        Player.EventTicTac -= calculHAz;

    }
    void Start()
    {

        _scobj.TempsUniversel = 0f;

    }

    // Update is called once per frame
    void Update()
    {
 
    }


    private void calculHAz() //int j, float h) // j= jour h= heure
    {
        _latitude = Mathf.PI * _scobj.latitude / 180f;

        angleHoraire = Mathf.PI * (_scobj.heure / 12f - 1f);
        declinaison = Mathf.Asin(0.398f * Mathf.Sin((0.985f * (float)_scobj.jourAn - 80f)));

        hauteur = Mathf.Asin(Mathf.Sin(_latitude) * Mathf.Sin(declinaison) + Mathf.Cos(_latitude) *
            Mathf.Cos(declinaison) * Mathf.Cos(angleHoraire));

        azimut = Mathf.Asin(Mathf.Cos(declinaison) * Mathf.Sin(angleHoraire) / Mathf.Cos(hauteur));

        hauteur = 180f * hauteur / Mathf.PI;
        azimut = 180f * azimut / Mathf.PI;
        Debug.Log("jourAn= " + _scobj.jourAn + " heure = " + _scobj.heure + " hauteur= " + hauteur + " azimut= " + azimut +
            " _scobj.AccTemps" + _scobj.AccTemps);

        transform.rotation = Quaternion.Euler(hauteur, azimut, 0f);

    }

  
}