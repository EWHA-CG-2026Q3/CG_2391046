using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Mid_LanternFloat : MonoBehaviour
{
    public float floatHeight = 0.15f;
    public float floatSpeed = 0.8f;
    public float spinSpeed = 20f;
    public float swingAngle = 6f;
    public float swingSpeed = 0.6f;
    public float breathAmount = 0.05f;
    public float breathSpeed = 1.5f;
    public Transform lanternLight;
    public Vector3 lightPoint = new Vector3(0f, 0.5f, 0f);

    Mesh mesh;
    Vector3[] baseVertices;

    void Update()
    {
        if (baseVertices == null)
        {
            mesh = GetComponent<MeshFilter>().sharedMesh;
            if (mesh == null || mesh.vertexCount == 0) return;
            baseVertices = mesh.vertices;
        }

        float time = Time.time;

        Vector3 t = new Vector3(0f, Mathf.Sin(time * floatSpeed) * floatHeight, 0f);
        Quaternion r = Quaternion.Euler(Mathf.Sin(time * swingSpeed) * swingAngle, time * spinSpeed, Mathf.Cos(time * swingSpeed) * swingAngle);
        float scale = 1f + Mathf.Sin(time * breathSpeed) * breathAmount;
        Vector3 s = new Vector3(scale, scale, scale);

        Matrix4x4 M = Matrix4x4.TRS(t, r, s);

        Vector3[] verts = new Vector3[baseVertices.Length];
        for (int i = 0; i < baseVertices.Length; i++)
        {
            verts[i] = M.MultiplyPoint(baseVertices[i]);
        }

        mesh.vertices = verts;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        if (lanternLight != null)
        {
            lanternLight.localPosition = M.MultiplyPoint(lightPoint);
        }
    }
}