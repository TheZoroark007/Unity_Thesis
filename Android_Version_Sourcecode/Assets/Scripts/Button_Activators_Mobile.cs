using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Activators_Mobile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;
    public GameObject ExitButton;
    public GameObject ScanQRCodeButton;
    public GameObject HowToButton;
    [SerializeField] private Button HowToButton_button;
    [SerializeField] private Button ExitButton_button;
    [SerializeField] private Button ScanQRCode_button;

    void Start()
    {  

    }

   private void Awake()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {   //Check if the ScanQRCodeButton is currently visible
        if (ScanQRCodeButton.activeInHierarchy)
        {   //If the HowToButton is pressed, proceed to turorial
            HowToButton_button.onClick.AddListener(() =>
            {
                uiObject.SetActive(true);
                ExitButton.SetActive(true);
                ScanQRCodeButton.SetActive(false);
                HowToButton.SetActive(false);

            }
                     );
            //Else continue to QR Code scan and disable all buttons
            ScanQRCode_button.onClick.AddListener(() =>
            {
                uiObject.SetActive(false);
                ExitButton.SetActive(false);
                ScanQRCodeButton.SetActive(false);
                HowToButton.SetActive(false);
            }
                     );
        }
        else if (!ScanQRCodeButton.activeInHierarchy)
        {
            ExitButton_button.onClick.AddListener(() =>
            {
                uiObject.SetActive(false);
                ExitButton.SetActive(false);
                ScanQRCodeButton.SetActive(true);
                HowToButton.gameObject.SetActive(true);

            }
                     );
        }
    }
}
