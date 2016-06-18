using UnityEngine;
using System.Collections;

namespace SP2D.Utils{
	
	public class CoroutineUtilities {

		public static IEnumerator WaitForRealTime(float delay){
			while(true){
				float pauseEndTime = Time.realtimeSinceStartup + delay;
				while (Time.realtimeSinceStartup < pauseEndTime){
					yield return 0;
				}
				break;
			}
		}

	}

}