using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Inventory))]
public class InventoryEditor : Editor {

	private SerializedProperty itemImagesProperty;
	private SerializedProperty itemsProperty;


	private bool[] showItemSlots = new bool[Inventory.numItemSlots];

	private const string inventoryPropItemImagesName = "itemImages";
	private const string inventoryPropItemsName = "items";


	private void onEnable(){

		itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
		itemsProperty = serializedObject.FindProperty(inventoryPropItemsName);

	}

	public override void OnInspectorGUI(){

		serializedObject.Update();



		serializedObject.ApplyModifiedProperties();

	}

	private void ItemSlotGUI(int index){

		EditorGUILayout.BeginHorizontal(GUI.skin.box);
		EditorGUI.indentLevel++;

		showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot " + index);

		//------------------------  continue HERE!!!

		EditorGUI.indentLevel--;
		EditorGUILayout.EndHorizontal();

	}

}
