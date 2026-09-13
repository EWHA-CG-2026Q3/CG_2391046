using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S04_CustomPyramidMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "CustomPyramidMesh";

        // 정점 5개 (상단 꼭짓점 1개 + 밑면 모서리 4개)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f,  1f,  0f), // 0: 피라미드 꼭짓점
            new Vector3(-1f, 0f,  1f), // 1: 밑면 앞-좌
            new Vector3(1f,  0f,  1f), // 2: 밑면 앞-우
            new Vector3(1f,  0f, -1f), // 3: 밑면 뒤-우
            new Vector3(-1f, 0f, -1f)  // 4: 밑면 뒤-좌
        };

        // 삼각형 6개 (밑면 2개 + 옆면 4개)
        int[] triangles = new int[]
        {
            1, 2, 3,  1, 3, 4, // 밑면 사각형
            0, 2, 1,           // 정면 옆면
            0, 3, 2,           // 우측 옆면
            0, 4, 3,           // 후면 옆면
            0, 1, 4            // 좌측 옆면
        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0.5f, 1.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 1.0f)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}