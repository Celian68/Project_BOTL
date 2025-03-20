using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AbstractEffect), true)]
public class EffectPropertyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Laisse Unity calculer la hauteur (avec recursion pour les sous-propriétés)
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Si la référence gérée est nulle, proposer de créer une instance via un menu contextuel
        if (property.managedReferenceValue == null)
        {
            // On affiche un bouton "Create Instance"
            Rect buttonRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            if (EditorGUI.DropdownButton(buttonRect, new GUIContent("Create " + fieldInfo.FieldType.Name), FocusType.Passive))
            {
                GenericMenu menu = new GenericMenu();
                // Utilisation de TypeCache pour obtenir tous les types dérivés de Effect
                foreach (Type type in TypeCache.GetTypesDerivedFrom<AbstractEffect>())
                {
                    if (!type.IsAbstract)
                    {
                        menu.AddItem(new GUIContent(type.Name), false, () =>
                        {
                            property.managedReferenceValue = Activator.CreateInstance(type);
                            property.serializedObject.ApplyModifiedProperties();
                        });
                    }
                }
                menu.ShowAsContext();
            }
        }
        else
        {
            // Sinon, on dessine la propriété normalement
            EditorGUI.PropertyField(position, property, label, true);

            // On ajoute également un bouton pour réinitialiser (supprimer) la référence
            Rect resetButtonRect = new Rect(position.x + position.width - 50, position.y, 50, EditorGUIUtility.singleLineHeight);
            if (GUI.Button(resetButtonRect, "Clear"))
            {
                property.managedReferenceValue = null;
                property.serializedObject.ApplyModifiedProperties();
            }
        }
        EditorGUI.EndProperty();
    }
}
