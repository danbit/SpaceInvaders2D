using UnityEngine;

namespace Destructible2D
{
	// This component throws random prefabs upwards
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Thrower")]
	public class D2dThrower : MonoBehaviour
	{
		public GameObject[] ThrowPrefabs;
		
		public float DelayMin = 0.5f;
		
		public float DelayMax = 2.0f;

		public float SpeedMin = 10.0f;

		public float SpeedMax = 20.0f;

		public float Spread = 10.0f;

		private float cooldown;

		protected virtual void Update()
		{
			cooldown -= Time.deltaTime;

			if (cooldown <= 0.0f)
			{
				cooldown = Random.Range(DelayMin, DelayMax);

				if (ThrowPrefabs != null && ThrowPrefabs.Length > 0)
				{
					var index     = Random.Range(0, ThrowPrefabs.Length);
					var prefab    = ThrowPrefabs[index];
					var instance  = Instantiate(prefab);
					var rigidbody = instance.GetComponent<Rigidbody2D>();

					instance.transform.position = transform.position;

					if (rigidbody != null)
					{
						var angle = Random.Range(-0.5f, 0.5f) * Spread * Mathf.Deg2Rad;
						var speed = Random.Range(SpeedMin, SpeedMax);

						rigidbody.velocity        = new Vector2(Mathf.Sin(angle) * speed, Mathf.Cos(angle) * speed);
						rigidbody.angularVelocity = Random.Range(-180.0f, 180.0f);
					}
				}
			}
		}
	}
}