using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//camargo

[CustomEditor(typeof(ClipVideo))]
public class ClipVideoEditor : Editor
{
    ClipVideo clipVideo;
    public SerializedObject SOClipVideo;

    public SerializedProperty TimeAnimation;
    public SerializedProperty BehaviorMove;
    public SerializedProperty CallFuntions;

    public ClipVideo ClipVideo { get => clipVideo;}

    private void OnEnable()
    {
        clipVideo = (ClipVideo)target;
        SOClipVideo = new SerializedObject(target);

        TimeAnimation = SOClipVideo.FindProperty("TimeAnimation");
        BehaviorMove = SOClipVideo.FindProperty("BehaviorMove");
        CallFuntions = SOClipVideo.FindProperty("CallFuntions");
    }

    public override void OnInspectorGUI()
    {
        string[] Funciones = new string[] { "Movimiento", "Accion" };
        EditorGUI.BeginChangeCheck();
        clipVideo.Pestaña = GUILayout.Toolbar(clipVideo.Pestaña, Funciones);

        switch (clipVideo.Pestaña)
        {
            case 0:
                EditorGUILayout.PropertyField(TimeAnimation);
                EditorGUILayout.PropertyField(BehaviorMove);
                break;
            case 1:
                EditorGUILayout.PropertyField(CallFuntions);
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            SOClipVideo.ApplyModifiedProperties();
        }
    }
}
