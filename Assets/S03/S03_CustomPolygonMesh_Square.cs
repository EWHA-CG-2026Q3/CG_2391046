// 1차 커밋용 코드 상태
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_CustomPolygonMesh_Square : MonoBehaviour
{
    void Start()
    {
        // 정점 5개 정의
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 1.5f, 0f),
            new Vector3(-1f, 0.5f, 0f),
            new Vector3(1f, 0.5f, 0f),
            new Vector3(-0.7f, -1f, 0f),
            new Vector3(0.7f, -1f, 0f)
        };

        int[] triangles = new int[] { };
    }
}