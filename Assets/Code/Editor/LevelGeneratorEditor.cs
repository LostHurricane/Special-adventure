using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SpecialAdventure
{
    [CustomEditor(typeof(LevelGeneratorView))]
    public class LevelGeneratorEditor : Editor
    {
        private LevelGenerateController _levelGeneratorController;

        private void OnEnable()
        {
            var view = (LevelGeneratorView)target;

            _levelGeneratorController = new LevelGenerateController(view);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var tileMap = serializedObject.FindProperty("_tilemap");
            EditorGUILayout.PropertyField(tileMap);

            var tiles = serializedObject.FindProperty("_tiles");
            EditorGUILayout.PropertyField(tiles);

            var width = serializedObject.FindProperty("_widthMap");
            EditorGUILayout.PropertyField(width);

            var heigh = serializedObject.FindProperty("_heightMap");
            EditorGUILayout.PropertyField(heigh);

            var factorSmooth = serializedObject.FindProperty("_factorSmooth");
            EditorGUILayout.PropertyField(factorSmooth);

            var randomFillingPercent = serializedObject.FindProperty("_randomFillingPercent");
            EditorGUILayout.PropertyField(randomFillingPercent);

            if (GUI.Button(new Rect (10, 220, 70, 50), "Generate"))
            {
                _levelGeneratorController.Start();
            }

            if (GUI.Button(new Rect(150, 220, 60, 50), "Clear"))
            {
                _levelGeneratorController.Clean();
            }
            GUILayout.Space(100);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
