using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxHorizontal : MonoBehaviour
{
    public float speed = 1f;
    private Material skyboxMaterial;
    private float rotation;

    private void Start()
    {
        skyboxMaterial = RenderSettings.skybox;
        rotation = 0;
    }

    private void Update()
    {
        rotation += Time.deltaTime * speed;
        skyboxMaterial.SetFloat("_Rotation", rotation);
    }
}