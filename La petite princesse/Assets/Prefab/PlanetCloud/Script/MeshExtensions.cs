using UnityEngine;
using System.Collections.Generic;

public static class MeshExtensions
{
    public static Vector3[] GetIntersectingVertices(this Mesh mesh, Plane plane)
    {
        var intersectingVertices = new List<Vector3>();
        var vertices = mesh.vertices;
        var triangles = mesh.triangles;
        var triangleCount = triangles.Length / 3;

        for (var i = 0; i < triangleCount; i++)
        {
            var index0 = triangles[i * 3];
            var index1 = triangles[i * 3 + 1];
            var index2 = triangles[i * 3 + 2];

            var vertex0 = vertices[index0];
            var vertex1 = vertices[index1];
            var vertex2 = vertices[index2];

            var side0 = plane.GetSide(vertex0);
            var side1 = plane.GetSide(vertex1);
            var side2 = plane.GetSide(vertex2);

            if (side0 == side1 && side1 == side2)
            {
                continue; // Triangle is completely on one side of the plane
            }

            // Find intersection points of each triangle edge with the plane
            var intersectionPoints = new List<Vector3>();

            if (GetIntersection(vertex0, vertex1, plane, out var intersectionPoint01))
            {
                intersectionPoints.Add(intersectionPoint01);
            }

            if (GetIntersection(vertex1, vertex2, plane, out var intersectionPoint12))
            {
                intersectionPoints.Add(intersectionPoint12);
            }

            if (GetIntersection(vertex2, vertex0, plane, out var intersectionPoint20))
            {
                intersectionPoints.Add(intersectionPoint20);
            }

            // Add vertices on the intersection of the plane and the triangle
            intersectingVertices.AddRange(intersectionPoints);
        }

        return intersectingVertices.ToArray();
    }

    private static bool GetIntersection(Vector3 vertexA, Vector3 vertexB, Plane plane, out Vector3 intersectionPoint)
    {
        var distanceA = plane.GetDistanceToPoint(vertexA);
        var distanceB = plane.GetDistanceToPoint(vertexB);

        if (distanceA * distanceB > 0f)
        {
            // Both vertices are on the same side of the plane
            intersectionPoint = Vector3.zero;
            return false;
        }

        // Calculate intersection point using linear interpolation
        var t = Mathf.Abs(distanceA) / (Mathf.Abs(distanceA) + Mathf.Abs(distanceB));
        intersectionPoint = Vector3.Lerp(vertexA, vertexB, t);
        return true;
    }
}