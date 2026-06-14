#if UNITY_EDITOR


using DragonResonance.Miscellany;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Miscellany
{
	[InitializeOnLoad]
	internal static class HierarchySeparatorDrawer
	{
		private const int FONT_SIZE       = 10;
		private const float BORDER_HEIGHT = 2f;


		private static GUIStyle _style_internal = null;	// Caching only, use the method instead


		#region Constructors

			static HierarchySeparatorDrawer()
			{
				EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyItemGUI;
			}

		#endregion


		#region Events

			private static void OnHierarchyItemGUI(int instanceId, Rect selectionRect)
			{
				GameObject gameObject = EditorUtility.EntityIdToObject(instanceId) as GameObject;
				if (gameObject == null) return;
				HierarchySeparator separator = gameObject.GetComponent<HierarchySeparator>();
				if (separator == null) return;


				if (Event.current.type == EventType.DragUpdated || Event.current.type == EventType.DragPerform) {
					if (selectionRect.Contains(Event.current.mousePosition)) {
						DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
						Event.current.Use();
						return;
					}
				}

				//	Full separator rect
				selectionRect.x = 0f;
				selectionRect.width = Screen.width;	// Screen represents the window, not the device
				EditorGUI.DrawRect(selectionRect, separator.BackgroundColor);

				//	Accent bottom line
				Rect lineRect = selectionRect;
				lineRect.y = selectionRect.yMax - BORDER_HEIGHT;
				lineRect.height = BORDER_HEIGHT;
				EditorGUI.DrawRect(lineRect, separator.AccentColor);

				//	Text label
				GetStyle().normal.textColor = separator.TextColor;
				EditorGUI.LabelField(selectionRect, separator.DisplayLabel.ToUpperInvariant(), GetStyle());
			}

		#endregion


		#region Privates

			[MenuItem("GameObject/Create Separator", false, 0)]
			private static void CreateSeparator(MenuCommand command)
			{
				GameObject gameObject = new("New Separator");
				gameObject.AddComponent<HierarchySeparator>();

				GameObjectUtility.SetParentAndAlign(gameObject, null);	// Always on root

				Undo.RegisterCreatedObjectUndo(gameObject, "Create Separator");
				Selection.activeGameObject = gameObject;
			}

			private static GUIStyle GetStyle()
			{
				return _style_internal ??= new GUIStyle(EditorStyles.boldLabel) {
					alignment = TextAnchor.MiddleCenter,
					fontSize = FONT_SIZE,
					fontStyle = FontStyle.Bold,
				};
			}

		#endregion
	}
}


#endif


/*       ________________________________________________________________       */
/*           _________   _______ ________  _______  _______  ___    _           */
/*           |        \ |______/ |______| |  _____ |       | |  \   |           */
/*           |________/ |     \_ |      | |______| |_______| |   \__|           */
/*           ______ _____ _____ _____ __   _ _____ __   _ _____ _____           */
/*           |____/ |____ [___  |   | | \  | |___| | \  | |     |____           */
/*           |    \ |____ ____] |___| |  \_| |   | |  \_| |____ |____           */
/*       ________________________________________________________________       */
/*                                                                              */
/*           David Tabernero M.  <https://github.com/davidtabernerom>           */
/*           Dragon Resonance    <https://github.com/dragonresonance>           */
/*                  Copyright © 2021-2026. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */