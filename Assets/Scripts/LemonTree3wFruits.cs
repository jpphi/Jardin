using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonTree3wFruits : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;

    private const float TAILLEMAX = 2f;
    private const float FACTEUR_CROISSANCE_MAX = 1.001f;
    private const float FACTEUR_CROISSANCE_MIN = 1.0001f;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void grandir()
    {
        if(transform.localScale.x < TAILLEMAX)
        {
            float fc = Random.Range(FACTEUR_CROISSANCE_MIN, FACTEUR_CROISSANCE_MAX);
            transform.localScale *= fc;
        }

    }
}
