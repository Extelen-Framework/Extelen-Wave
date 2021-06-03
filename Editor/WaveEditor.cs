using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Wave))]
public class WaveEditor : Editor
{

    //Set Params
    private SerializedProperty m_waveable = null;
    private SerializedProperty m_unscaledDeltaTime = null;

    private SerializedProperty m_moveInX = null;
    private SerializedProperty m_angleX = null;
    private SerializedProperty m_offsetX = null;
    private SerializedProperty m_intensityX = null;
    private SerializedProperty m_speedX = null;

    private SerializedProperty m_moveInY = null;
    private SerializedProperty m_angleY = null;
    private SerializedProperty m_offsetY = null;
    private SerializedProperty m_intensityY = null;
    private SerializedProperty m_speedY = null;

    private SerializedProperty m_moveInZ = null;
    private SerializedProperty m_angleZ = null;
    private SerializedProperty m_offsetZ = null;
    private SerializedProperty m_intensityZ = null;
    private SerializedProperty m_speedZ = null;

    //Methods
    private void OnEnable()
    {
        m_waveable = serializedObject.FindProperty("m_waveable");
        m_unscaledDeltaTime = serializedObject.FindProperty("m_unscaledDeltaTime");

        m_moveInX = serializedObject.FindProperty("m_moveInX");
        m_angleX = serializedObject.FindProperty("m_angleX");
        m_offsetX = serializedObject.FindProperty("m_offsetX");
        m_intensityX = serializedObject.FindProperty("m_intensityX");
        m_speedX = serializedObject.FindProperty("m_speedX");

        m_moveInY = serializedObject.FindProperty("m_moveInY");
        m_angleY = serializedObject.FindProperty("m_angleY");
        m_offsetY = serializedObject.FindProperty("m_offsetY");
        m_intensityY = serializedObject.FindProperty("m_intensityY");
        m_speedY = serializedObject.FindProperty("m_speedY");

        m_moveInZ = serializedObject.FindProperty("m_moveInZ");
        m_angleZ = serializedObject.FindProperty("m_angleZ");
        m_offsetZ = serializedObject.FindProperty("m_offsetZ");
        m_intensityZ = serializedObject.FindProperty("m_intensityZ");
        m_speedZ = serializedObject.FindProperty("m_speedZ");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_waveable);

        if (m_waveable.objectReferenceValue)
        {
            EditorGUILayout.PropertyField(m_unscaledDeltaTime);
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_moveInX);
            if (m_moveInX.boolValue)
            {
                EditorGUILayout.PropertyField(m_angleX);
                EditorGUILayout.PropertyField(m_offsetX);
                EditorGUILayout.PropertyField(m_intensityX);
                EditorGUILayout.PropertyField(m_speedX);
                EditorGUILayout.Space();
            }

            EditorGUILayout.PropertyField(m_moveInY);
            if (m_moveInY.boolValue)
            {
                EditorGUILayout.PropertyField(m_angleY);
                EditorGUILayout.PropertyField(m_offsetY);
                EditorGUILayout.PropertyField(m_intensityY);
                EditorGUILayout.PropertyField(m_speedY);
                EditorGUILayout.Space();
            }

            EditorGUILayout.PropertyField(m_moveInZ);
            if (m_moveInZ.boolValue)
            {
                EditorGUILayout.PropertyField(m_angleZ);
                EditorGUILayout.PropertyField(m_offsetZ);
                EditorGUILayout.PropertyField(m_intensityZ);
                EditorGUILayout.PropertyField(m_speedZ);
                EditorGUILayout.Space();
            }

            //EditorGUILayout.HelpBox("It is recommended that you have a different transform in the waveable parameter.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.HelpBox("You can't use the wave without assign the waveable parameter.", MessageType.Error);
        }

        serializedObject.ApplyModifiedProperties();
    }

}