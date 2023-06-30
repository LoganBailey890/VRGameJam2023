using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandsOnInput : MonoBehaviour
{
    public InputActionProperty PinchAction;
    public InputActionProperty GripAction;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue =  PinchAction.action.ReadValue<float>();
        float gripValue =  GripAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);
        animator.SetFloat("Grip", gripValue);
    }
}
