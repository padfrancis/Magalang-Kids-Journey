﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    MenuCreator myMenu;

    [SerializeField] private GameObject dummyCanvas;

    void Start()
    {
        dummyCanvas.SetActive(true);
        myMenu.ShowMenu();
    }
}
