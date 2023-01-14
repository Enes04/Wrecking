using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class ArenaManager : MonoBehaviour
{
    public List<GameObject> arena;
    public float levelTime;
    private float currentTime;
    public Material redMaterial, yellowMaterial;

    private List<GameObject> currentPartArena;
    private int maxArenaLevel = 5;
    private int currentArenaLevel = 6;
    private float closedTime;


    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > levelTime)
        {
            currentTime = 0;
            SetCurrentPart();
        }
    }

    [NaughtyAttributes.Button("CloseArena")]
    public void SetCurrentPart()
    {
        if (arena.Count > 0)
        {
            closedTime = .5f;
            currentPartArena = new List<GameObject>();
            for (int i = 0; i < currentArenaLevel * maxArenaLevel; i++)
            {
                currentPartArena.Add(arena[0]);
                arena.RemoveAt(0);
            }
            RedColor();
        }
    }

    public void CloseArenaPart()
    {
        for (int i = 0; i < currentArenaLevel * maxArenaLevel; i++)
        {
            GameObject currentArenaPart = currentPartArena[0];
            currentPartArena.RemoveAt(0);
            currentArenaPart.GetComponent<ArenaPartDestroy>().DestroyPart(4);
            currentArenaPart.GetComponent<Rigidbody>().isKinematic = false;
            currentArenaPart.isStatic = false;
        }

        currentArenaLevel -= 1;
        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();
    }

    public void RedColor()
    {
        for (int i = 0; i < currentArenaLevel * maxArenaLevel; i++)
        {
            Material currentMat = currentPartArena[i].GetComponent<Renderer>().material;
            currentMat = redMaterial;
            currentPartArena[i].GetComponent<Renderer>().material = currentMat;
        }

        Invoke(nameof(YellowColor), closedTime);
    }

    public void YellowColor()
    {
        for (int i = 0; i < currentArenaLevel * maxArenaLevel; i++)
        {
            Material currentMat = currentPartArena[i].GetComponent<Renderer>().material;
            currentMat = yellowMaterial;
            currentPartArena[i].GetComponent<Renderer>().material = currentMat;
        }

        if (closedTime > .1f)
            Invoke(nameof(RedColor), closedTime);
        else
        {
            CloseArenaPart();
        }

        closedTime -= 0.1f;
    }
}