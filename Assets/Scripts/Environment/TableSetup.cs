using UnityEngine;

/// <summary>
/// Script for creating and managing the table with boxes.
/// </summary>
public class TableSetup : MonoBehaviour
{
    [Header("Table Configuration")]
    [SerializeField] private float tableWidth = 3f;
    [SerializeField] private float tableDepth = 2f;
    [SerializeField] private float tableHeight = 1f;
    [SerializeField] private Material tableMaterial;
    
    [Header("Box Configuration")]
    [SerializeField] private int boxCount = 3;
    [SerializeField] private Vector3 boxSize = new Vector3(0.6f, 0.6f, 0.6f);
    [SerializeField] private Material boxMaterial;
    
    private void Start()
    {
        CreateTable();
        CreateBoxes();
    }
    
    /// <summary>
    /// Creates the main table.
    /// </summary>
    private void CreateTable()
    {
        // Create table top
        GameObject tableTop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tableTop.name = "TableTop";
        tableTop.transform.parent = transform;
        tableTop.transform.localPosition = new Vector3(0, tableHeight / 2, 0);
        tableTop.transform.localScale = new Vector3(tableWidth, 0.1f, tableDepth);
        
        if (tableMaterial != null)
        {
            tableTop.GetComponent<MeshRenderer>().material = tableMaterial;
        }
        
        // Create table legs
        float legOffset = 0.2f;
        CreateTableLeg(new Vector3(-tableWidth / 2 + legOffset, tableHeight / 2, -tableDepth / 2 + legOffset));
        CreateTableLeg(new Vector3(tableWidth / 2 - legOffset, tableHeight / 2, -tableDepth / 2 + legOffset));
        CreateTableLeg(new Vector3(-tableWidth / 2 + legOffset, tableHeight / 2, tableDepth / 2 - legOffset));
        CreateTableLeg(new Vector3(tableWidth / 2 - legOffset, tableHeight / 2, tableDepth / 2 - legOffset));
    }
    
    /// <summary>
    /// Creates a table leg.
    /// </summary>
    private void CreateTableLeg(Vector3 position)
    {
        GameObject leg = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leg.name = "TableLeg";
        leg.transform.parent = transform;
        leg.transform.localPosition = position;
        leg.transform.localScale = new Vector3(0.1f, tableHeight, 0.1f);
        Destroy(leg.GetComponent<BoxCollider>());
    }
    
    /// <summary>
    /// Creates the boxes on the table.
    /// </summary>
    private void CreateBoxes()
    {
        float spacing = tableWidth / (boxCount + 1);
        
        for (int i = 0; i < boxCount; i++)
        {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.name = $"Box_{i + 1}";
            box.transform.parent = transform;
            
            float xPos = -tableWidth / 2 + spacing * (i + 1);
            float yPos = tableHeight + boxSize.y / 2;
            box.transform.localPosition = new Vector3(xPos, yPos, 0);
            box.transform.localScale = boxSize;
            
            if (boxMaterial != null)
            {
                box.GetComponent<MeshRenderer>().material = boxMaterial;
            }
            
            // Add BoxInteraction script
            BoxInteraction boxInteraction = box.AddComponent<BoxInteraction>();
            
            // Create lid for the box
            GameObject lid = GameObject.CreatePrimitive(PrimitiveType.Cube);
            lid.name = $"Box_{i + 1}_Lid";
            lid.transform.parent = box.transform;
            lid.transform.localPosition = new Vector3(0, boxSize.y / 2, 0);
            lid.transform.localScale = new Vector3(1, 0.1f, 1);
            Destroy(lid.GetComponent<BoxCollider>());
            
            if (boxMaterial != null)
            {
                lid.GetComponent<MeshRenderer>().material = boxMaterial;
            }
        }
    }
}
