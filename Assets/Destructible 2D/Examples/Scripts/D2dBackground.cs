using UnityEngine;
using System.Collections.Generic;

namespace Destructible2D
{
#if UNITY_EDITOR
	[UnityEditor.CanEditMultipleObjects]
	[UnityEditor.CustomEditor(typeof(D2dBackground))]
	public class D2dBackground_Editor : D2dEditor<D2dBackground>
	{
		protected override void OnInspector()
		{
			DrawDefault("Prefab");

			DrawDefault("TileAxis");

			DrawDefault("OffsetPerSecond");

			DrawDefault("Offset");

			DrawDefault("OverrideSorting");

			if (Any(t => t.OverrideSorting == true))
			{
				BeginIndent();
				{
					DrawDefault("SortingOrder");
				}
				EndIndent();
			}
		}
	}
#endif

	// This component automatically spawns tiles based on the main camera's orthographic size
	[ExecuteInEditMode]
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Background")]
	public class D2dBackground : MonoBehaviour
	{
		public enum Axes
		{
			Horizontal,
			Vertical,
			HorizontalAndVertical
		}
		
		public D2dTile Prefab;
		
		public Axes TileAxis = Axes.HorizontalAndVertical;
		
		public Vector2 OffsetPerSecond;
		
		public Vector2 Offset;
		
		public bool OverrideSorting;
		
		public int SortingOrder;
		
		[SerializeField]
		private List<D2dTile> tiles;
		
		[System.NonSerialized]
		private Camera mainCamera;
		
		protected virtual void Update()
		{
			Offset += OffsetPerSecond * Time.deltaTime;
			
			UpdateTiles();
		}
		
		private void UpdateTiles()
		{
			var tileCount = 0;
			
			if (Prefab != null && Prefab.Size.x > 0.0f && Prefab.Size.y > 0.0f)
			{
				if (mainCamera == null) mainCamera = Camera.main;
				
				if (mainCamera != null && mainCamera.orthographic == true)
				{
					var width  = Mathf.CeilToInt(mainCamera.orthographicSize * mainCamera.aspect / Prefab.Size.x);
					var height = Mathf.CeilToInt(mainCamera.orthographicSize                     / Prefab.Size.y);
					
					if (TileAxis == Axes.Horizontal) height = 0;
					if (TileAxis == Axes.Vertical  ) width  = 0;
					
					for (var y = -height; y <= height; y++)
					{
						for (var x = -width; x <= width; x++)
						{
							// Expand tile array?
							if (tileCount == tiles.Count)
							{
								tiles.Add(null);
							}
							
							// Get tile at this index
							var tile = tiles[tileCount];
							
							// Create tile?
							if (tile == null)
							{
								tile = Instantiate(Prefab);
								
								tile.enabled = false;
								
								tile.transform.SetParent(transform, false);
								
								tiles[tileCount] = tile;
							}
							
							if (OverrideSorting == true)
							{
								tile.UpdateRenderer(SortingOrder);
							}
							
							// Update this tile
							tile.Offset.X = x;
							tile.Offset.Y = y;
							
							tile.UpdatePosition(Offset);
							
							// Increment tile count
							tileCount += 1;
						}
					}
				}
			}
			
			// Remove unused tiles
			for (var i = tiles.Count - 1; i >= tileCount; i--)
			{
				var tile = tiles[i];
				
				if (tile != null)
				{
					D2dHelper.Destroy(tile.gameObject);
				}
				
				tiles.RemoveAt(i);
			}
		}
	}
}