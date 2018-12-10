﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    public int mapSize;
    public GameObject hexPrefab;
    public Material[] hexMaterials;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for(int col = 0; col < mapSize; col++)
        {
            for (int row = 0; row < mapSize; row++)
            {
                Hex hex = new Hex(col, row);
                GameObject go =  Instantiate(hexPrefab, hex.Position(), Quaternion.identity, transform) as GameObject;
                MeshRenderer mr = go.GetComponentInChildren<MeshRenderer>();
                mr.material = hexMaterials[Random.Range(0, hexMaterials.Length)];
            }
        }
        StaticBatchingUtility.Combine(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
