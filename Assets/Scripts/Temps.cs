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

        float j = _scobj.jour;
        float coef = 5/91*j-915/91;

        coef = 10;



        //change the Material properties

        rd.GetPropertyBlock(mpb);

        //Debug.Log("ICI material " + rd.material + " coef = " + coef + " _CoefS1S2= " + mpb.GetFloat("_CoefS1S2")  +" --- " +
        //    rd.material.shader.GetPropertyDescription(2) + " --- "  );
        Debug.Log("Jour= " + j);
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
