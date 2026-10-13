using UnityEngine;

public class MeasureTest : MonoBehaviour
{
    public Transform Ball_Sphere;
    public Transform Moon_Mesh;
    public MeshFilter Diamond_Mesh;        // 다이아몬드 본체
    public MeshFilter Diamond_Moon_Mesh;   // 다이아몬드 달

    // Update에서 재면 공·다이아몬드 모두 직전 프레임 값으로 맞춰짐
    void Update()
    {
        if (Ball_Sphere == null || Moon_Mesh == null ||
            Diamond_Mesh == null || Diamond_Moon_Mesh == null) return;

        // 공: 구 메시는 피벗이 중심이고 지름 1이라 Transform으로 재도 됨
        float ballDist = Vector3.Distance(Moon_Mesh.position, Ball_Sphere.position);
        float ballSize = Moon_Mesh.lossyScale.x;

        // 다이아몬드: 실제 정점에서 중심과 크기를 구함
        GetDiamond(Diamond_Mesh, out Vector3 dCenter, out _);
        GetDiamond(Diamond_Moon_Mesh, out Vector3 mCenter, out float mSize);
        float diaDist = Vector3.Distance(mCenter, dCenter);

        Debug.Log($"공 달 거리: {ballDist:F3} / 크기: {ballSize:F3} || 다이아몬드 달 거리: {diaDist:F3} / 크기: {mSize:F3}");
    }

    static void GetDiamond(MeshFilter mf, out Vector3 center, out float size)
    {
        Vector3[] v = mf.sharedMesh.vertices;
        Vector3 bottom = mf.transform.TransformPoint(v[0]); // 아래 꼭짓점
        Vector3 top    = mf.transform.TransformPoint(v[5]); // 위 꼭짓점
        center = (bottom + top) * 0.5f;
        size   = Vector3.Distance(bottom, top);             // 높이 = 월드 크기
    }
}