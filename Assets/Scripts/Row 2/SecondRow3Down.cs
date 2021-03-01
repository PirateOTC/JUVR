using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using WindowsInput;

public class SecondRow3Down : MonoBehaviour
{
    public void OnPress(Hand hand)
    {
        // Build an input simulator instance
        InputSimulator inputSimulator = new InputSimulator();
        // Then call the keyboard key down method, pass in the enum virtual key code you want to press
        
        inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_U);
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }
}
