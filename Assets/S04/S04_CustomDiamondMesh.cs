using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomDiamondMesh : MonoBehaviour
{
    void Start()
    {
        // 6개 정점 정의 (허리띠 4개 + 위/아래 꼭짓점 2개)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),     // 0 (허리띠: 앞-좌)
            new Vector3(1f, 0f, 0f),     // 1 (허리띠: 앞-우)
            new Vector3(1f, 0f, 1f),     // 2 (허리띠: 뒤-우)
            new Vector3(0f, 0f, 1f),     // 3 (허리띠: 뒤-좌)
            new Vector3(0.5f, 1f, 0.5f),  // 4 (위쪽 꼭짓점)
            new Vector3(0.5f, -1f, 0.5f), // 5 (아래쪽 꼭짓점)
        };

        // 총 8개 면 (위쪽 4개 + 아래쪽 4개 삼각형)
        // 바깥에서 봤을 때 시계 방향(Winding Order) 정렬
        int[] triangles = new int[]
        {
            // 위쪽 4면 (정점 4 + 허리띠 인접 두 점)
            4, 1, 0, // 정면 위 삼각형
            4, 2, 1, // 우측 위 삼각형
            4, 3, 2, // 후면 위 삼각형
            4, 0, 3, // 좌측 위 삼각형

            // 아래쪽 4면 (정점 5 + 허리띠 인접 두 점)
            5, 0, 1, // 정면 아래 삼각형
            5, 1, 2, // 우측 아래 삼각형
            5, 2, 3, // 후면 아래 삼각형
            5, 3, 0  // 좌측 아래 삼각형
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}