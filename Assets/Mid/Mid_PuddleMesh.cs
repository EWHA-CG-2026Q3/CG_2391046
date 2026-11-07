using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_PuddleMesh : MonoBehaviour
{
    public int segments = 48;
    public float radius = 0.6f;
    public float wobble = 0.18f;
    public float seed = 1.3f;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "PuddleMesh";

        int n = segments;
        Vector3[] vertices = new Vector3[n + 1];
        Vector2[] uvs = new Vector2[n + 1];
        float maxRadius = radius * (1f + wobble * 2f);

        vertices[0] = Vector3.zero;
        uvs[0] = new Vector2(0.5f, 0.5f);

        for (int i = 0; i < n; i++)
        {
            float angle = 360f / n * i * Mathf.Deg2Rad;
            float r = radius * (1f
                + wobble * Mathf.Sin(2f * angle + seed)
                + wobble * 0.6f * Mathf.Sin(3f * angle + seed * 2.1f)
                + wobble * 0.3f * Mathf.Sin(5f * angle + seed * 3.7f));

            float x = Mathf.Cos(angle) * r;
            float z = Mathf.Sin(angle) * r;

            vertices[i + 1] = new Vector3(x, 0f, z);
            uvs[i + 1] = new Vector2(0.5f + x / (2f * maxRadius), 0.5f + z / (2f * maxRadius));
        }

        int[] triangles = new int[n * 3];
        for (int i = 0; i < n; i++)
        {
            int next = (i + 1) % n;
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = next + 1;
            triangles[i * 3 + 2] = i + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}