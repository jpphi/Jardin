using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
//using UnityEngine.InputSystem;

public class Perso : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI txt;

    public XRNode xrnode= XRNode.LeftHand;

    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrnode, devices);
        device = devices.FirstOrDefault();

    }

    private void OnEnable()
    {
        if(!device.isValid)
        {
            GetDevice();

            Debug.Log("OnEnable, device est valid " + device.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Ca print ou ?");

        txt.text = "TEST";
 
        //List<InputDevice> devices = new List<InputDevice>();

        //InputDevices.GetDevices(devices);

        //Debug.Log("Perso: "+ devices.Count);
        



        //foreach(var device in devices)
        //{
        //    Debug.Log("XX " + device.name + " " + device.characteristics);
        //}

 
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButton("Fire1") )
        //{
        //    Debug.Log("Fire!");
        //}

        //if (controler != null) { }

        if(!device.isValid)
        {
            GetDevice();
            Debug.Log("Update");
            txt.text = "Update, !deviceisValid";
        }
        else
        {
            txt.text = "Pas de composant valid !";
        }

        List<InputFeatureUsage> features= new List<InputFeatureUsage>();
        device.TryGetFeatureUsages(features);
        
        foreach(var feature in features)
        {
            Debug.Log("Nom: " + feature.name + " type " + feature.type);
            txt.text = "Update, foreach featurename= " + feature.name + " feature.type : " + feature.type;
        }


    }
}
