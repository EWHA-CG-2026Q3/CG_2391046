using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_CustomPolygonMesh_Square : MonoBehaviour
{
    void Start()
    {
        // 정점 좌표 6개 정의 (정육각형)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 1f, 0f),         // 0: 상단
            new Vector3(0.87f, 0.5f, 0f),    // 1: 우상단
            new Vector3(0.87f, -0.5f, 0f),   // 2: 우하단
            new Vector3(0f, -1f, 0f),        // 3: 하단
            new Vector3(-0.87f, -0.5f, 0f),  // 4: 좌하단
            new Vector3(-0.87f, 0.5f, 0f)    // 5: 좌상단
        };

        // 정점 3개씩 묶어 삼각형 4개 구성
        int[] triangles = new int[]
        {
            0, 1, 2, // 첫 번째 삼각형
            0, 2, 3, // 두 번째 삼각형
            0, 3, 4, // 세 번째 삼각형
            0, 4, 5  // 네 번째 삼각형
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}