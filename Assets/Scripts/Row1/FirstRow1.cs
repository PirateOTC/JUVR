﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using WindowsInput;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;


public class FirstRow1 : MonoBehaviour
{

    InputSimulator IS;

    void Start()
    {
        IS = new InputSimulator();
    }

    public void OnPress(Hand hand)
    {
        // Build an input simulator instance
        InputSimulator inputSimulator = new InputSimulator();
        // Then call the keyboard key down method, pass in the enum virtual key code you want to press
        inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_5);
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }
}

