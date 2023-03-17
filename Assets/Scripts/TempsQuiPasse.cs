using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class TempsQuiPasse : MonoBehaviour
{
    private bool tempo;

    public delegate void TicTac();
    public static TicTac EventTicTac;

    [SerializeField] private ScObj _scobj;
    [SerializeField][Tooltip("Régle la valeur de la vitesse de rafraichissement.")]
        private float rafraichissement = 1f;

    [SerializeField] private Slider _slider;

    //[SerializeField] private Slider _slider;


    // Start is called before the first frame update
    void Start()
    {
        tempo = true;
        _scobj.TempsUniversel = 0f;
        _scobj.jour = 1;
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

            if (_scobj.heure >= 24)
            {
                _scobj.heure = _scobj.heure % 24;
                _scobj.jourAn = (_scobj.jourAn >= 365) ? 1 : _scobj.jourAn + 1; // numéro du jour dans l'année

                // On change la valeur du coef du shader en fonction du jour
                //_temps.GestionSaison(); //_jour

                _scobj.jour++;

            }

            //Debug.Log("TempsQuiPasse Update. jourAn= " + _scobj.jourAn + " heure " + _scobj.heure + " _scobj.PasTemporel " + _scobj.pasTemporel +
            //    " jour " + _scobj.jour + " Rafraichissement " + rafraichissement);


            EventTicTac?.Invoke();

            StartCoroutine(tempsQuiPasse());
        }
    }


    public IEnumerator tempsQuiPasse()
    {
        yield return new WaitForSeconds(rafraichissement);
        tempo = true;

    }
    public void ValueChangedRafraichissement()
    {
        rafraichissement = _slider.value;
        //Debug.Log("ValueChangedRafraichissement, rafraichissement... : " + rafraichissement);
    }

}
