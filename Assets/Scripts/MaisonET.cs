using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisonET : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;

    [SerializeField] private Renderer rd;

    private float CoefV = 0;

    private void OnEnable()
    {
        TempsQuiPasse.EventTicTac += VieillissementPeinture;
        rd = GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        TempsQuiPasse.EventTicTac -= VieillissementPeinture;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VieillissementPeinture()
    {
        int j = _scobj.jour;

        CoefV = (CoefV >= 1)?1: ((float)j - 101f)/ 100f;

        //change the Material properties

        //rd.GetPropertyBlock(mpb);

        //Debug.Log("ICI material " + rd.material + " coef = " + coef + " _CoefS1S2= " + mpb.GetFloat("_CoefS1S2")  +" --- " +
        //    rd.material.shader.GetPropertyDescription(2) + " --- "  );
        //Debug.Log("VieillissementPeinture: Jour= " + j + " CoefV= " + CoefV);
        rd.material.SetFloat("_CoefT1T2", CoefV);


    }
}
