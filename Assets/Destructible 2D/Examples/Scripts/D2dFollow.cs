using UnityEngine;

namespace Destructible2D
{
#if UNITY_EDITOR
	[UnityEditor.CanEditMultipleObjects]
	[UnityEditor.CustomEditor(typeof(D2dFollow))]
	public class D2dFollow_Editor : D2dEditor<D2dFollow>
	{
		protected override void OnInspector()
		{
			DrawDefault("Target");
		}
	}
#endif

	// This component causes the current GameObject to follow the target Transform
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Follow")]
	public class D2dFollow : MonoBehaviour
	{
		[Tooltip("The target object you want this GameObject to follow")]
		public Transform Target;
		
		public void UpdatePosition()
		{
			if (Target != null)
			{
				var position = transform.position;
				
				position.x = Target.position.x;
				position.y = Target.position.y;
				
				transform.position = position;
			}
		}
		
		protected virtual void Update()
		{
			UpdatePosition();
		}
	}
}