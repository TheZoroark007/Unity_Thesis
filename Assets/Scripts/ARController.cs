using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class ARController : MonoBehaviour
{
    [SerializeField] private ARSession arSession;

    private void Awake()
    {
        if (arSession == null)
        {
            arSession = FindObjectOfType<ARSession>();
        }
    }

    private void Start()
    {
        if (ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.CheckingAvailability)
        {
            ARSession.stateChanged += OnSessionStateChanged;
        }
        else
        {
            StartSession();
        }
    }

    private void OnSessionStateChanged(ARSessionStateChangedEventArgs args)
    {
        if (args.state == ARSessionState.Ready)
        {
            ARSession.stateChanged -= OnSessionStateChanged;
            StartSession();
        }
    }

    private void StartSession()
    {
        if (arSession != null)
        {
            arSession.enabled = true;
        }
    }
}