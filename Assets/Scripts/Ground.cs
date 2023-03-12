using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField] private ScObj _scobj;

    [SerializeField] private Renderer rd;

    private void OnEnable()
    {
        TempsQuiPasse.EventTicTac += GestionSaisonGround;
        rd = GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        TempsQuiPasse.EventTicTac -= GestionSaisonGround;
    }

    public void GestionSaisonGround() //float j
    {

        int j = _scobj.jourAn;
        float coef = (j < 183) ? ((float)j * 20f - 1830f) / 181f : (-(float)j * 20f + 5470f) / 183f;

        //change the Material properties

        //rd.GetPropertyBlock(mpb);

        //Debug.Log("ICI material " + rd.material + " coef = " + coef + " _CoefS1S2= " + mpb.GetFloat("_CoefS1S2")  +" --- " +
        //    rd.material.shader.GetPropertyDescription(2) + " --- "  );
        Debug.Log("GestionSaisonGround: Jour= " + j + " Coef= " + coef);
        rd.material.SetFloat("_CoefS1S2G", coef);


        //mpb.SetFloat("_CoefS1S2", coef);

    }

}
