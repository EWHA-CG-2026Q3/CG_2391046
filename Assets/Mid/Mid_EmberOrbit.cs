using UnityEngine;

public class Mid_EmberOrbit : MonoBehaviour
{
    public Transform ember;
    public float orbitSpeed = 60f;
    public float spinSpeed = 240f;
    public float bobHeight = 0.05f;
    public float bobSpeed = 2f;

    Vector3 emberStart;

    void Start()
    {
        if (ember != null)
        {
            emberStart = ember.localPosition;
        }
    }

    void Update()
    {
        transform.Rotate(0f, orbitSpeed * Time.deltaTime, 0f, Space.Self);

        if (ember != null)
        {
            ember.localPosition = emberStart + new Vector3(0f, Mathf.Sin(Time.time * bobSpeed) * bobHeight, 0f);
            ember.Rotate(0f, 0f, spinSpeed * Time.deltaTime, Space.Self);
        }
    }
}