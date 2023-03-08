using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temps : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;
    [SerializeField] private GameObject _go;

    private MaterialPropertyBlock mpb;
    //[SerializeField] private MaterialPropertyBlock mpb;

    [SerializeField] private Renderer rd;

    private void OnEnable()
    {
        rd = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();

    

        Debug.Log("Renderer: " + rd.material);

    }

    

    void Update()
    {
        int chance = Random.Range(0, 100);

        if(chance> 1)
        {
            //Debug.Log("chance !");
            GestionSaison();
        }

    }
    public void GestionSaison() //float j
    {

        int j = _scobj.jourAn;
        float coef = (j<183)? ((float)j * 20f - 1830f)/181f : ( -(float)j * 20f + 5470f) / 183f;

        //coef = 10;



        //change the Material properties

        rd.GetPropertyBlock(mpb);

        //Debug.Log("ICI material " + rd.material + " coef = " + coef + " _CoefS1S2= " + mpb.GetFloat("_CoefS1S2")  +" --- " +
        //    rd.material.shader.GetPropertyDescription(2) + " --- "  );
        Debug.Log("GestionSaison: Jour= " + j + " Coef= " + coef);
        rd.material.SetFloat("_CoefS1S2", coef);

        //for(int i= 0; i < rd.material.shader.GetPropertyCount(); i++)
        //{
        //    rd.material.shader.f (i);

        //}


        //mpb.SetFloat("_CoefS1S2", coef);
        //renderer.SetPropertyBlock(mpb);
        //MaterialPropertyBlock mpb;

        //mpb.SetFloat("CoefS1S2", CoefS1S2);



    }
}
