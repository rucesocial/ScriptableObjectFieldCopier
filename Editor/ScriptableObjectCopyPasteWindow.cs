using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RuceSocial.ScriptableObjectFieldCopier
{
    public class ScriptableObjectCopyPasteWindow : EditorWindow
    {
        private Object selectedObject;
        private Object lastSelectedObject;
        private string searchString = "";

        private Vector2 scrollPos;
        private Dictionary<FieldInfo, bool> fieldInfoList = new Dictionary<FieldInfo, bool>();

        private static ScriptableObjectCopyPasteWindow instance;
        private int EligibleObjectCount => ScriptableObjectCopyPasteHandler.GetEligibleObjects(selectedObject).Count;

        public static void OpenWindow(Object selectedObject)
        {
            if (instance == null)
            {
                instance = GetWindow<ScriptableObjectCopyPasteWindow>("Field List");
                instance.minSize = new Vector2(400, 300);
            }

            instance.selectedObject = selectedObject;
            instance.ListFields();
            instance.Show();
        }

        [MenuItem("Tools/ScriptableObject Field Copier")]
        public static void OpenWindow()
        {
            OpenWindow(Selection.activeObject is ScriptableObject ? Selection.activeObject : null);
        }

        private void OnEnable()
        {
            ListFields();
        }

        private void OnGUI()
        {
            GUILayout.Label("Selected Object", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(ScriptableObject), true);

            // Add a refresh button next to the selectedObject field
            if (GUILayout.Button(EditorGUIUtility.IconContent("d_RotateTool"), GUILayout.Width(30),
                    GUILayout.Height(20)))
            {
                ListFields();
            }

            EditorGUILayout.EndHorizontal();

            if (selectedObject == null)
            {
                EditorGUILayout.HelpBox("Selected Object is null. Please select an object.", MessageType.Warning);
                return;
            }

            EditorGUILayout.Space(10);
            GUILayout.Label("Search Fields", EditorStyles.boldLabel);
            string newSearchString = EditorGUILayout.TextField(searchString);

            if (!string.Equals(newSearchString, searchString))
            {
                searchString = newSearchString;
                ListFields(); // refresh the field list when the search string changes
            }

            GUILayout.Label($"Eligible Objects: {EligibleObjectCount}");

            if (GUILayout.Button("Paste Selected Fields"))
            {
                Paste();
            }

            EditorGUILayout.Space(20);

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            GUIStyle labelStyle = EditorStyles.label;
            GUIStyle toggleStyle = EditorStyles.toggle;
            GUIStyle backgroundStyle = GUI.skin.box;

            foreach (var fieldInfo in fieldInfoList.Keys.ToArray())
            {
                // filter fields based on the search string
                if (fieldInfo.Name.ToLower().Contains(searchString.ToLower()))
                {
                    EditorGUILayout.BeginHorizontal(backgroundStyle);

                    fieldInfoList[fieldInfo] =
                        EditorGUILayout.Toggle(fieldInfoList[fieldInfo], toggleStyle, GUILayout.Width(20));
                    EditorGUILayout.LabelField($"{fieldInfo.Name}:", labelStyle);
                    EditorGUILayout.LabelField(fieldInfo.GetValue(selectedObject)?.ToString() ?? "null", labelStyle);

                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(10);

            UpdateSelectedObjectAndListFields();
        }

        private void UpdateSelectedObjectAndListFields()
        {
            if (selectedObject != lastSelectedObject)
            {
                if (selectedObject == null)
                    return;

                ListFields();
                lastSelectedObject = selectedObject;
            }
        }

        private void ListFields()
        {
            if (selectedObject == null)
            {
                return;
            }

            // Remember the current toggle status of the fields before clearing the list
            var oldFieldInfoList = new Dictionary<FieldInfo, bool>(fieldInfoList);
            fieldInfoList.Clear();

            FieldInfo[] fields = selectedObject.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes(typeof(SerializeField), true).Length > 0 || f.IsPublic)
                .ToArray();

            foreach (var field in fields)
            {
                bool toggleStatus = !oldFieldInfoList.TryGetValue(field, out var value) || value;
                fieldInfoList.Add(field, toggleStatus);
            }
        }


        private void Paste()
        {
            ScriptableObjectCopyPasteHandler.PasteSelectedValues(selectedObject, fieldInfoList);
        }
    }
}