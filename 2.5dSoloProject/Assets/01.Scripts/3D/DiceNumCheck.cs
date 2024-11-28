using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceNumCheck : MonoBehaviour
{
    public List<Vector3> faceNormals = new List<Vector3>();
    public List<Vector3> faceCenters = new List<Vector3>();

    [SerializeField] private LayerMask _whatIsGround;

    private void Update()
    {
        DrawRayCheck();
    }

    private void DrawRayCheck()
    {
        for(int i = 0; i < 20; i++)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(faceNormals[i]), 0.86f, _whatIsGround))
            {
                Debug.Log($"맞아따잇{i}번째");
            }
        }
    }

    private void OnDrawGizmos()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null) return;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            int index0 = triangles[i];
            int index1 = triangles[i + 1];
            int index2 = triangles[i + 2];

            Vector3 v0 = transform.TransformPoint(vertices[index0]);
            Vector3 v1 = transform.TransformPoint(vertices[index1]);
            Vector3 v2 = transform.TransformPoint(vertices[index2]);

            Vector3 faceCenter = (v0 + v1 + v2) / 3f;

            Vector3 edge1 = v1 - v0;
            Vector3 edge2 = v2 - v0;
            Vector3 faceNormal = Vector3.Cross(edge1, edge2).normalized;
            

        }
    }
}
