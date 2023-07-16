using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectCopyPasteHandler
{
    private static Object copiedObject;

    [MenuItem("Assets/Copy ScriptableObject", true)]
    public static bool ValidateCopy()
    {
        return Selection.activeObject is ScriptableObject && Selection.objects.Length == 1;
    }

    [MenuItem("Assets/Copy ScriptableObject")]
    public static void Copy()
    {
        copiedObject = Selection.activeObject;
    }

    [MenuItem("Assets/Paste ScriptableObject", true)]
    public static bool ValidatePaste()
    {
        if (copiedObject == null) return false;

        System.Type type = copiedObject.GetType();

        foreach (var selectedObject in Selection.objects)
        {
            if (selectedObject.GetType() == type)
                return true;
        }

        return false;
    }

    [MenuItem("Assets/Paste ScriptableObject")]
    public static void Paste()
    {
        ScriptableObjectCopyPasteWindow.OpenWindow(copiedObject as ScriptableObject);
    }

    public static List<Object> GetEligibleObjects(Object copiedObject)
    {
        List<Object> eligibleObjects = new List<Object>();

        System.Type type = copiedObject.GetType();
        if (type == null) return eligibleObjects;

        foreach (var selectedObject in Selection.objects)
        {
            if (selectedObject.GetType() == type)
            {
                eligibleObjects.Add(selectedObject);
            }
        }

        return eligibleObjects;
    }

    public static void PasteSelectedValues(Object copiedObject, Dictionary<FieldInfo, bool> fieldInfoList)
    {
        ScriptableObjectCopyPasteHandler.copiedObject = copiedObject;

        List<Object> eligibleObjects = GetEligibleObjects(copiedObject);
        int counter = 0;
        foreach (var selectedObject in eligibleObjects)
        {
            Undo.RecordObject(selectedObject, "Paste ScriptableObject Values");

            foreach (var fieldInfo in fieldInfoList.Keys)
            {
                if (fieldInfoList[fieldInfo])
                {
                    object value = fieldInfo.GetValue(copiedObject);
                    fieldInfo.SetValue(selectedObject, value);
                }
            }

            EditorUtility.SetDirty(selectedObject);
            counter++;
        }

        Debug.Log(
            $"<b>Paste operation <color=#00FF00>completed</color> on <color=#FF0000>{counter}</color> objects</b>");
    }
}