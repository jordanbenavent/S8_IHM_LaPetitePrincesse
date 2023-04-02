using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGlowEffect : MonoBehaviour
{
    public Color glowColor = Color.red;
    public float glowIntensity = 1f;
    public float auraRadius = 1.5f;
    public int auraSegments = 32;
    public float auraThickness = 0.1f;

    private MeshFilter glowMeshFilter;
    private MeshRenderer glowMeshRenderer;
    private Material glowMaterial;

    private void Start()
    {
        // Create a new mesh for the glowing aura
        Mesh auraMesh = new Mesh();
        Vector3[] vertices = new Vector3[auraSegments * 2];
        int[] triangles = new int[auraSegments * 6];
        Vector2[] uv = new Vector2[auraSegments * 2];
        float angle = 0f;
        float angleDelta = Mathf.PI * 2 / auraSegments;
        for (int i = 0; i < auraSegments; i++)
        {
            int index = i * 2;
            vertices[index] = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * (auraRadius - auraThickness);
            vertices[index + 1] = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * auraRadius;
            uv[index] = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            uv[index + 1] = uv[index];
            angle += angleDelta;

            // Define triangles
            if (i == auraSegments - 1)
            {
                triangles[i * 6] = i * 2;
                triangles[i * 6 + 1] = i * 2 + 1;
                triangles[i * 6 + 2] = 0;
                triangles[i * 6 + 3] = 0;
                triangles[i * 6 + 4] = i * 2 + 1;
                triangles[i * 6 + 5] = 1;
            }
            else
            {
                triangles[i * 6] = i * 2;
                triangles[i * 6 + 1] = i * 2 + 1;
                triangles[i * 6 + 2] = i * 2 + 3;
                triangles[i * 6 + 3] = i * 2;
                triangles[i * 6 + 4] = i * 2 + 3;
                triangles[i * 6 + 5] = i * 2 + 2;
            }
        }
        auraMesh.vertices = vertices;
        auraMesh.triangles = triangles;
        auraMesh.uv = uv;

        // Create a new mesh object for the glowing aura
        GameObject glowObject = new GameObject("GlowObject");
        glowObject.transform.position = transform.position;
        glowObject.transform.rotation = transform.rotation;
        glowObject.transform.localScale = transform.localScale;
        glowMeshFilter = glowObject.AddComponent<MeshFilter>();
        glowMeshFilter.mesh = auraMesh;
        glowMeshRenderer = glowObject.AddComponent<MeshRenderer>();
        glowMeshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        glowMeshRenderer.receiveShadows = false;

        // Create a new material for the glowing aura
        glowMaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
        glowMaterial.color = glowColor;
        glowMaterial.SetFloat("_Mode", 2); // Set material to use transparent rendering mode
        glowMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        glowMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        glowMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        glowMaterial.SetInt("_ZWrite", 0);
        glowMaterial.DisableKeyword("_ALPHATEST_ON");
        glowMaterial.EnableKeyword("_ALPHABLEND_ON");
        glowMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        glowMaterial.renderQueue = 3000; // Set render queue to render after opaque objects
        glowMeshRenderer.material = glowMaterial;
    }

    private void Update()
    {
        // Position the glowing aura at the center of the object
        glowMeshFilter.transform.position = transform.position;

        // Scale the glowing aura according to the object's size
        float objectSize = transform.localScale.magnitude;
        glowMeshFilter.transform.localScale = new Vector3(objectSize, objectSize, objectSize) * auraRadius;

        // Adjust the opacity of the glow based on distance from camera
        float distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        float minDistance = 1f;
        float maxDistance = 10f;
        float distanceFactor = Mathf.Clamp01((distanceFromCamera - minDistance) / (maxDistance - minDistance));
        Color glowColorWithAlpha = new Color(glowColor.r, glowColor.g, glowColor.b, distanceFactor * glowIntensity);
        glowMaterial.color = glowColorWithAlpha;
    }

}
