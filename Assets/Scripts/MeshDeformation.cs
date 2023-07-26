using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.ProBuilder;

public class MeshDeformation : MonoBehaviour
{
    [Range(0.5f, 5f)]

    public float radius = 2f;

    [Range(0.5f, 10f)]
    public float stength = 2f;


    public GameObject ball;

    public Mesh mesh;

    private Vector3[] defauld, modified;

    // Start is called before the first frame update
    void Start()
    {
        mesh = ball.GetComponent<MeshFilter>().mesh;
        defauld = mesh.vertices;
        modified = mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        

        if (Physics.Raycast(ray , out hit, Mathf.Infinity))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point);

            for (int i = 0; i < modified.Length; i++)
            {
                float distance = Vector3.Distance(modified[i], hit.point);

                float smoothingFactor = 2f;
                float force = stength / (1f + hit.point.sqrMagnitude);

                if (distance < 0.1f)
                {
                    Vector3 direction = Vector3.Normalize(modified[i] - ball.transform.position);

                    if (Input.GetMouseButton(0)) 
                    {
                        modified[i] = modified[i] + (direction * force) / smoothingFactor;
                    }
                    else if (Input.GetMouseButton(1)) 
                    {
                        modified[i] = modified[i] + (direction * force) / smoothingFactor;
                    }
                }

            }



        }
        MeshRecalculate();
    }

    void MeshRecalculate()
    {
        mesh.vertices = modified;
        ball.GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    void ResetMesh()
    {
        mesh.vertices = defauld;
        ball.GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateBounds();
    }
}
