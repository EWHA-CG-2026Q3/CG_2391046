using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_SkyLanternMesh : MonoBehaviour
{
    public int sides = 6;
    public float bottomRadius = 0.35f;
    public float topRadius = 0.5f;
    public float height = 1.0f;
    public float capHeight = 0.25f;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "SkyLanternMesh";

        int n = sides;
        int ring = n + 1;
        int capStart = ring * 2;
        int apex = capStart + n;
        int bottomStart = apex + 1;
        int bottomCenter = bottomStart + n;

        Vector3[] vertices = new Vector3[bottomCenter + 1];
        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i <= n; i++)
        {
            float angle = 360f / n * i * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle);
            float z = Mathf.Sin(angle);
            float u = (float)i / n;

            vertices[i] = new Vector3(x * bottomRadius, 0f, z * bottomRadius);
            vertices[ring + i] = new Vector3(x * topRadius, height, z * topRadius);
            uvs[i] = new Vector2(u, 0f);
            uvs[ring + i] = new Vector2(u, 1f);
        }

        for (int i = 0; i < n; i++)
        {
            float angle = 360f / n * i * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle);
            float z = Mathf.Sin(angle);

            vertices[capStart + i] = new Vector3(x * topRadius, height, z * topRadius);
            vertices[bottomStart + i] = new Vector3(x * bottomRadius, 0f, z * bottomRadius);
            uvs[capStart + i] = new Vector2(0.5f + x * 0.5f, 0.5f + z * 0.5f);
            uvs[bottomStart + i] = new Vector2(0.5f + x * 0.5f, 0.5f + z * 0.5f);
        }

        vertices[apex] = new Vector3(0f, height + capHeight, 0f);
        vertices[bottomCenter] = new Vector3(0f, 0f, 0f);
        uvs[apex] = new Vector2(0.5f, 0.5f);
        uvs[bottomCenter] = new Vector2(0.5f, 0.5f);

        int[] triangles = new int[n * 12];
        int t = 0;

        for (int i = 0; i < n; i++)
        {
            int b0 = i;
            int b1 = i + 1;
            int t0 = ring + i;
            int t1 = ring + i + 1;

            triangles[t++] = b0;
            triangles[t++] = t0;
            triangles[t++] = t1;

            triangles[t++] = b0;
            triangles[t++] = t1;
            triangles[t++] = b1;
        }

        for (int i = 0; i < n; i++)
        {
            int next = (i + 1) % n;

            triangles[t++] = capStart + i;
            triangles[t++] = apex;
            triangles[t++] = capStart + next;

            triangles[t++] = bottomCenter;
            triangles[t++] = bottomStart + i;
            triangles[t++] = bottomStart + next;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}