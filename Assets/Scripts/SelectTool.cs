using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectTool : MonoBehaviour
{

    public MeshDeformation meshDeformation;
    public VertexPainting vertexPainting;

    private int curentscript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            meshDeformation.enabled = !meshDeformation.enabled;
            vertexPainting.enabled = !vertexPainting.enabled;
        }   
    }
}
