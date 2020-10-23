using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public Color brushColor;
    Color[] colors;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        percentage = (paintedVertexCount / mesh.vertexCount)*100;
        colors = new Color[mesh.vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(1,1,1,1);
        }
        paintedVertexCount = 0;
    }
    public float percentage;
    public int paintedVertexCount;
    
    void Update()
    {
        if (Helper.IsBrushState() && Input.GetMouseButton(0))
        {
            RaycastHit hit;

            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition+ new Vector3(i*10f,0,j*10f)), out hit))
                        return;


                    if (!hit.collider.CompareTag("Wall"))
                        return;

                    mesh = hit.collider.GetComponent<MeshFilter>().mesh;
                    if (mesh == null || mesh == null)
                        return;


                    int triangleIndex = hit.triangleIndex;
                    int mod = triangleIndex % 2;

                    Color(ref hit, triangleIndex * 3 + 0);
                    Color(ref hit, triangleIndex * 3 + 1);
                    Color(ref hit, triangleIndex * 3 + 2);
                    Color(ref hit, ((triangleIndex + mod * -2) + 1) * 3 + 0);

                    Color(ref hit, ((triangleIndex + mod * -8) + 7) * 3 + 1);
                    Color(ref hit, ((triangleIndex + mod * -8) + 7) * 3 + 2);
                    Color(ref hit, ((triangleIndex + mod * -8) + 7) * 3 + 0);
                }
            }

            percentage = ((float)paintedVertexCount / (float)mesh.vertexCount)*100f;

            GameManager.main.game.UpdateWallPercentage(percentage);

            mesh.colors = colors;
        }
    }

    public void Color(ref RaycastHit hit, int index)
    {
        if (colors[mesh.triangles[index]] != brushColor)
        {
            colors[mesh.triangles[index]] = brushColor;
            paintedVertexCount++;
        }
    }
}
