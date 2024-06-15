﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorScript : MonoBehaviour
{
    public Texture2D cursorTex;
    public int cursorSize = 100;
    int sizeX;
    int sizeY;

    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        sizeX = cursorSize;
        sizeY = cursorSize;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        sizeX = cursorSize;
        sizeY = cursorSize;
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (cursorSize / 2), Event.current.mousePosition.y - (cursorSize / 2), sizeX, sizeY), cursorTex);
    }
}
