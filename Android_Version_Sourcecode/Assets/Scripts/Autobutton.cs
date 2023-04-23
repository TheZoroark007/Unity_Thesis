using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Autobutton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button startClientButton;
    void Start()
    {
         //Automatically click the client button once a QR code has been scanned
         startClientButton.onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
