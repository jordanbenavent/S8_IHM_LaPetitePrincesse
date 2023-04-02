using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class OutlineIntersection : MonoBehaviour
{
    // Define the plane's normal vector and distance from the origin
    Vector3 normal = new Vector3(0, 0, 1);
    float distance = 0f;
    Plane plane;

    // Define the material to use for the outline
    public Material outlineMaterial;

    void Start()
    {
        // Create the plane object using the normal and distance values
        plane = new Plane(normal, distance);// Get the mesh renderer and mesh filter components of the game object
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        // Get the vertices and triangles of the mesh
        Mesh mesh = meshFilter.mesh;
        List<Vector3> intersectingVertices = mesh.GetIntersectingVertices(plane).ToList();

        int[] triangles = mesh.triangles; // get the triangles array
        int triangleCount = triangles.Length / 3; // calculate the number of triangles
        int vertexCount = mesh.vertexCount; // get the total number of vertices
        int[] submeshIndices = mesh.subMeshCount > 1 ? mesh.GetTriangles(1) : null; // get the indices of the existing submesh, if there is one

        List<int> newSubmeshIndices = new List<int>(); // create a new list to store the indices of the new submesh

        for (int i = 0; i < triangleCount; i++) {
            int index0 = triangles[i * 3];
            int index1 = triangles[i * 3 + 1];
            int index2 = triangles[i * 3 + 2];

            // check if any of the vertices in the current triangle are in the list of vertices to change
            if (intersectingVertices.Contains(mesh.vertices[index0]) || intersectingVertices.Contains(mesh.vertices[index1]) || intersectingVertices.Contains(mesh.vertices[index2])) {
                // add the indices of the vertices to the new submesh indices list
                newSubmeshIndices.Add(index0);
                newSubmeshIndices.Add(index1);
                newSubmeshIndices.Add(index2);
            }
        }

        // create a new submesh with the new material
        int[] newSubmeshIndicesArray = newSubmeshIndices.ToArray();
        mesh.subMeshCount++;
        mesh.SetTriangles(submeshIndices, 0); // set the indices of the original submesh
        mesh.SetTriangles(newSubmeshIndicesArray, 1); // set the indices of the new submesh
        mesh.SetSubMesh(1, new SubMeshDescriptor(0, newSubmeshIndicesArray.Length, MeshTopology.Triangles)); // set the submesh descriptor for the new submesh
        mesh.SetSubMesh(0, new SubMeshDescriptor(0, submeshIndices.Length, MeshTopology.Triangles)); // set the submesh descriptor for the original submesh    
    }

    void Update()
    {
        
    }
}
