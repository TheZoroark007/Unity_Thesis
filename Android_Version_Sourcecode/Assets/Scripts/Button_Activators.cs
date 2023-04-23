using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Activators : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;
    public GameObject ExitButton;
    public GameObject CreateQRCodeButton;
    public GameObject HowToButton;
    public GameObject TitleText;

    //Button Gameobject for client here 
    public GameObject ClientStartButton;
    [SerializeField] private Button HowToButton_button;
    [SerializeField] private Button ExitButton_button;
    [SerializeField] private Button CreateQRCode_button;

    void Start()
    {  

    }

   private void Awake()
    {   
        
    }

    // Update is called once per frame
    void Update()
    
    {   //Client button check first to avoid errors on the mobile device
        if(ClientStartButton != null){
            ClientStartButton.SetActive(false);
        }
        //Check if the CreateQRCodeButton is currently visible
        else if (CreateQRCodeButton.activeInHierarchy)
        {   //If the HowToButton is pressed, proceed to turorial
            HowToButton_button.onClick.AddListener(() =>
            {
                uiObject.SetActive(true);
                ExitButton.SetActive(true);
                CreateQRCodeButton.SetActive(false);
                HowToButton.SetActive(false);
                TitleText.SetActive(false);

            }
                     );
            //Else continue to QR Code generation and disable all buttons
            CreateQRCode_button.onClick.AddListener(() =>
            {
                uiObject.SetActive(false);
                ExitButton.SetActive(false);
                CreateQRCodeButton.SetActive(false);
                HowToButton.SetActive(false);
                TitleText.SetActive(false);
            }
                     );
        }
        else if (!CreateQRCodeButton.activeInHierarchy)
        {
            ExitButton_button.onClick.AddListener(() =>
            {
                uiObject.SetActive(false);
                ExitButton.SetActive(false);
                CreateQRCodeButton.SetActive(true);
                HowToButton.gameObject.SetActive(true);
                TitleText.SetActive(true);

            }
                     );
        }
        
    }
}
