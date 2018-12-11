using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    public int numRows = 5;
    public int numCols = 10;
    public float hexTileSize = 2;
    public GameObject hexPrefab;
    public Material[] hexMaterials;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for(int col = 0; col < numCols; col++)
        {
            for (int row = 0; row < numRows; row++)
            {
                Hex hex = new Hex(col, row, hexTileSize);
                GameObject go =  Instantiate(hexPrefab, transform.position+hex.Position(), Quaternion.identity, transform) as GameObject;
                MeshRenderer mr = go.GetComponentInChildren<MeshRenderer>();
                go.transform.localScale = new Vector3(hexTileSize, hexTileSize, hexTileSize);
                mr.material = hexMaterials[Random.Range(0, hexMaterials.Length)];
            }
        }
        //StaticBatchingUtility.Combine(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
