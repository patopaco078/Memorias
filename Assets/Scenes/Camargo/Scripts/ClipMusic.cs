using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Events;
//camargo

[System.Serializable]
public class ClipMusic
{
    enum Distance { DistanceLong, DistanceShort };

    [SerializeField] Distance DistanceOfArco;
    [SerializeField] float FinishTime;
    [SerializeField] float ErrorRange;

    
    private float speed;
    public float Speed { get => speed;}

    public ClipMusic()
    {
        switch (DistanceOfArco)
        {
            case Distance.DistanceLong:
                speed = 3f;
                Debug.Log("x");
                break;

            case Distance.DistanceShort:
                speed = 1f;
                Debug.Log("a");
                break;
        }

        Debug.Log(speed);
    }
}

[CustomEditor(typeof(ClipMusic))]
public class ClipMusicEditor : Editor
{
    private SerializedProperty distanceOfArcoProperty;

    private void OnEnable()
    {
        distanceOfArcoProperty = serializedObject.FindProperty("DistanceOfArco");
        UnityEventTools.AddVoidPersistentListener(distanceOfArcoProperty.OnValueChanged, OnDistanceOfArcoChanged);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(distanceOfArcoProperty);

        serializedObject.ApplyModifiedProperties();
    }

    private void OnDistanceOfArcoChanged()
    {
        Debug.Log("La distancia de arco ha cambiado");
    }
}

