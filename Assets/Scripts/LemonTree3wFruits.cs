using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonTree3wFruits : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;

    private const float FACTEUR_CROISSANCE_MAX = 1.001f, FACTEUR_CROISSANCE_MIN = 1.0001f;

    private const float TAILLE_MIN = 1f, TAILLE_MAX = 2.5f;

    private float tailleMax;
    private float fc;
    

    private void OnEnable()
    {
        Player.EventTicTac += grandir;
    }

    private void OnDisable()
    {
        Player.EventTicTac -= grandir;

    }


    // Start is called before the first frame update
    void Start()
    {
        fc = Random.Range(FACTEUR_CROISSANCE_MIN, FACTEUR_CROISSANCE_MAX);
        tailleMax = Random.Range(TAILLE_MIN, TAILLE_MAX);

        //Debug.Log("LemonTree3wFruits fc= " + fc + " tailleMax= " + tailleMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void grandir()
    {
        if(transform.localScale.x < tailleMax)
        {
            transform.localScale *= fc;
        }
        else // On ne peut plus grandir, on se désabonne
        {
            Player.EventTicTac -= grandir;
        }
    }
}
