using UnityEngine;

/// <summary>
/// Script for creating room walls and environment.
/// </summary>
public class RoomSetup : MonoBehaviour
{
    [Header("Room Configuration")]
    [SerializeField] private float roomWidth = 10f;
    [SerializeField] private float roomDepth = 10f;
    [SerializeField] private float roomHeight = 5f;
    [SerializeField] private float wallThickness = 0.2f;
    [SerializeField] private Material wallMaterial;
    
    private void Start()
    {
        CreateRoomWalls();
    }
    
    /// <summary>
    /// Creates the room walls procedurally.
    /// </summary>
    private void CreateRoomWalls()
    {
        // Back wall
        CreateWall("Back Wall", new Vector3(0, roomHeight / 2, roomDepth / 2), new Vector3(roomWidth, roomHeight, wallThickness));
        
        // Front wall
        CreateWall("Front Wall", new Vector3(0, roomHeight / 2, -roomDepth / 2), new Vector3(roomWidth, roomHeight, wallThickness));
        
        // Left wall
        CreateWall("Left Wall", new Vector3(-roomWidth / 2, roomHeight / 2, 0), new Vector3(wallThickness, roomHeight, roomDepth));
        
        // Right wall
        CreateWall("Right Wall", new Vector3(roomWidth / 2, roomHeight / 2, 0), new Vector3(wallThickness, roomHeight, roomDepth));
        
        // Ceiling
        CreateWall("Ceiling", new Vector3(0, roomHeight, 0), new Vector3(roomWidth, wallThickness, roomDepth));
    }
    
    /// <summary>
    /// Creates an individual wall.
    /// </summary>
    private void CreateWall(string name, Vector3 position, Vector3 scale)
    {
        GameObject wall = new GameObject(name);
        wall.transform.parent = transform;
        wall.transform.localPosition = position;
        wall.transform.localScale = scale;
        
        MeshFilter meshFilter = wall.AddComponent<MeshFilter>();
        meshFilter.mesh = CreateCubeMesh();
        
        MeshRenderer meshRenderer = wall.AddComponent<MeshRenderer>();
        if (wallMaterial != null)
        {
            meshRenderer.material = wallMaterial;
        }
        
        BoxCollider collider = wall.AddComponent<BoxCollider>();
    }
    
    /// <summary>
    /// Creates a simple cube mesh.
    /// </summary>
    private Mesh CreateCubeMesh()
    {
        Mesh mesh = new Mesh();
        
        Vector3[] vertices = new Vector3[24];
        int[] triangles = new int[36];
        
        // Define cube vertices (8 unique vertices with 3 copies for different normals)
        float w = 0.5f, h = 0.5f, d = 0.5f;
        
        // Front face
        vertices[0] = new Vector3(-w, -h, d);
        vertices[1] = new Vector3(w, -h, d);
        vertices[2] = new Vector3(w, h, d);
        vertices[3] = new Vector3(-w, h, d);
        
        // Back face
        vertices[4] = new Vector3(w, -h, -d);
        vertices[5] = new Vector3(-w, -h, -d);
        vertices[6] = new Vector3(-w, h, -d);
        vertices[7] = new Vector3(w, h, -d);
        
        // Top face
        vertices[8] = new Vector3(-w, h, d);
        vertices[9] = new Vector3(w, h, d);
        vertices[10] = new Vector3(w, h, -d);
        vertices[11] = new Vector3(-w, h, -d);
        
        // Bottom face
        vertices[12] = new Vector3(-w, -h, -d);
        vertices[13] = new Vector3(w, -h, -d);
        vertices[14] = new Vector3(w, -h, d);
        vertices[15] = new Vector3(-w, -h, d);
        
        // Left face
        vertices[16] = new Vector3(-w, -h, -d);
        vertices[17] = new Vector3(-w, -h, d);
        vertices[18] = new Vector3(-w, h, d);
        vertices[19] = new Vector3(-w, h, -d);
        
        // Right face
        vertices[20] = new Vector3(w, -h, d);
        vertices[21] = new Vector3(w, -h, -d);
        vertices[22] = new Vector3(w, h, -d);
        vertices[23] = new Vector3(w, h, d);
        
        // Define triangles
        int idx = 0;
        // Front
        triangles[idx++] = 0; triangles[idx++] = 2; triangles[idx++] = 1;
        triangles[idx++] = 0; triangles[idx++] = 3; triangles[idx++] = 2;
        // Back
        triangles[idx++] = 4; triangles[idx++] = 6; triangles[idx++] = 5;
        triangles[idx++] = 4; triangles[idx++] = 7; triangles[idx++] = 6;
        // Top
        triangles[idx++] = 8; triangles[idx++] = 10; triangles[idx++] = 9;
        triangles[idx++] = 8; triangles[idx++] = 11; triangles[idx++] = 10;
        // Bottom
        triangles[idx++] = 12; triangles[idx++] = 14; triangles[idx++] = 13;
        triangles[idx++] = 12; triangles[idx++] = 15; triangles[idx++] = 14;
        // Left
        triangles[idx++] = 16; triangles[idx++] = 18; triangles[idx++] = 17;
        triangles[idx++] = 16; triangles[idx++] = 19; triangles[idx++] = 18;
        // Right
        triangles[idx++] = 20; triangles[idx++] = 22; triangles[idx++] = 21;
        triangles[idx++] = 20; triangles[idx++] = 23; triangles[idx++] = 22;
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        
        return mesh;
    }
}
