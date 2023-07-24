using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VertexPainting : MonoBehaviour
{
    [Range(0f, 255f)]
    public float red = 0f;
    [Range(0f, 255f)]
    public float green = 0f;
    [Range(0f, 255f)]
    public float blue = 0f;

    public Color color = new Color(1f, 1f, 1f);

    public GameObject ball;

    [Range(0.5f, 5f)]

    public float radius = 2f;

    Mesh mesh;
    Vector3[] vertices;

    Color[] colors;

    // Start is called before the first frame update
    void Start()
    {

        mesh = ball.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        colors = new Color[vertices.Length];

        //for (int i = 0; i < vertices.Length; i++)
        //{
        //    int first = vertices.Length / 2;

        //    //if (vertices[i])

        //    if (i < first)
        //    {
        //        colors[i] = Color.red;
        //    }
        //    if  (i > first)
        //    {
        //        colors[i] = Color.green;
        //    }
        //}
        // assign the array of colors to the Mesh.

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point);

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 distance = vertices[i] - hit.point;


                if (distance.sqrMagnitude < radius)
                {
                    if (Input.GetMouseButton(0))
                    {
                        colors[i] = Color.green;
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        colors[i] = Color.red;
                    }
                }
            }

        }
        mesh.colors = colors;
    }
}
