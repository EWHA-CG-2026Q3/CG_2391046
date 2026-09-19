using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_CustomPolygonMesh_Square : MonoBehaviour
{
    void Start()
    {
        // TODO 1: 정점 좌표 5개 정의 (오각형)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 1f, 0f),       // 0: 상단
            new Vector3(0.95f, 0.31f, 0f),  // 1: 우상단
            new Vector3(0.59f, -0.81f, 0f), // 2: 우하단
            new Vector3(-0.59f, -0.81f, 0f),// 3: 좌하단
            new Vector3(-0.95f, 0.31f, 0f)  // 4: 좌상단
        };

        // TODO 2: 정점 3개씩 묶어 삼각형 3개 구성
        int[] triangles = new int[]
        {
            0, 1, 2, // 첫 번째 삼각형
            0, 2, 3, // 두 번째 삼각형
            0, 3, 4  // 세 번째 삼각형
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}