using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_GrassMesh : MonoBehaviour
{
    public int blades = 40;
    public float radius = 0.35f;
    public float height = 0.45f;
    public float width = 0.03f;
    public float lean = 0.15f;
    public int seed = 1;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "GrassMesh";

        Random.State oldState = Random.state;
        Random.InitState(seed);

        Vector3[] vertices = new Vector3[blades * 3];
        Vector2[] uvs = new Vector2[blades * 3];
        int[] triangles = new int[blades * 3];

        for (int i = 0; i < blades; i++)
        {
            float angle = 360f / blades * i * Mathf.Deg2Rad + Random.Range(-0.3f, 0.3f);
            float dist = Random.Range(0f, radius);
            float h = height * Random.Range(0.6f, 1.2f);
            float turn = Random.Range(0f, Mathf.PI * 2f);

            Vector3 root = new Vector3(Mathf.Cos(angle) * dist, 0f, Mathf.Sin(angle) * dist);
            Vector3 side = new Vector3(Mathf.Cos(turn), 0f, Mathf.Sin(turn)) * width;
            Vector3 tip = root + new Vector3(Mathf.Cos(angle) * lean * h, h, Mathf.Sin(angle) * lean * h);

            int v = i * 3;
            vertices[v] = root - side;
            vertices[v + 1] = root + side;
            vertices[v + 2] = tip;
            uvs[v] = new Vector2(0f, 0f);
            uvs[v + 1] = new Vector2(1f, 0f);
            uvs[v + 2] = new Vector2(0.5f, 1f);

            triangles[v] = v;
            triangles[v + 1] = v + 2;
            triangles[v + 2] = v + 1;
        }

        Random.state = oldState;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}