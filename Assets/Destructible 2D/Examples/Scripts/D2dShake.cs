using UnityEngine;

namespace Destructible2D
{
#if UNITY_EDITOR
	[UnityEditor.CanEditMultipleObjects]
	[UnityEditor.CustomEditor(typeof(D2dShake))]
	public class D2dShake_Editor : D2dEditor<D2dShake>
	{
		protected override void OnInspector()
		{
			DrawDefault("Shake");
		}
	}
#endif

	// This component automatically adds shake to the D2dCameraShake component
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Shake")]
	public class D2dShake : MonoBehaviour
	{
		public float Shake;
		
		protected virtual void Awake()
		{
			D2dCameraShake.Shake += Shake;
		}
	}
}