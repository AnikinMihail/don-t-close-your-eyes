using System;
using UnityEngine;

public class FlashlightMech : MonoBehaviour
{
    [SerializeField] private GameObject lightSource;
    
    
    private InputManager _inputManager;
    private Transform _cameraTransform;
    
    private bool isOn = false;

    private void Start()
    {
        
        _inputManager = InputManager.Instance;
        _cameraTransform = Camera.main.transform;
    }
    
    private void Update()
    {
        
        if (_inputManager.PlayerInteractedThisFrame())
        {
            if (!isOn)
            {
                lightSource.SetActive(true);
                
            }
            else
            {
                lightSource.SetActive(false);
            }

            isOn = !isOn;
        }
    }
}
