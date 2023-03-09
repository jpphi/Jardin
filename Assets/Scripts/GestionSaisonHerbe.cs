using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSaisonHerbe : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;

    private MaterialPropertyBlock mpb;
    //[SerializeField] private MaterialPropertyBlock mpb;

    [SerializeField] private Renderer rd;

    private void OnEnable()
    {
        Player.EventTicTac += GestionSaison;
        rd = GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        Player.EventTicTac -= GestionSaison;
    }



    void Update()
    {

    }
    public void GestionSaison() //float j
    {

        int j = _scobj.jourAn;
        float coef = (j<183)? ((float)j * 20f - 1830f)/181f : ( -(float)j * 20f + 5470f) / 183f;

        //change the Material properties

        //rd.GetPropertyBlock(mpb);

        //Debug.Log("ICI material " + rd.material + " coef = " + coef + " _CoefS1S2= " + mpb.GetFloat("_CoefS1S2")  +" --- " +
        //    rd.material.shader.GetPropertyDescription(2) + " --- "  );
        Debug.Log("GestionSaison: Jour= " + j + " Coef= " + coef);
        rd.material.SetFloat("_CoefS1S2", coef);


        //mpb.SetFloat("_CoefS1S2", coef);

    }
}
