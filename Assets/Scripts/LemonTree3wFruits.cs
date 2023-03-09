using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonTree3wFruits : MonoBehaviour
{
    [SerializeField] private ScObj _scobj;

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

    }
}
