using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class OutlineIntersection : MonoBehaviour
{
    public Color outlineColor = Color.white;
    public Material outlineMaterial;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        // Get the MeshFilter and MeshRenderer components
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();

        // Set the material to the outline material
        _meshRenderer.material = outlineMaterial;
    }

    // Rest of the code for drawing the outline
}