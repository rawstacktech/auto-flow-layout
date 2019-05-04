using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemGenerator))]
public class ItemGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ItemGenerator itemGenerator = (ItemGenerator)target;
        if (GUILayout.Button("Generate Items"))
        {
            itemGenerator.GenerateItems();
        }

        if (GUILayout.Button("Clear"))
        {
            itemGenerator.Clear();
        }
    }
}
