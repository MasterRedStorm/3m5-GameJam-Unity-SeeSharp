//Time.deltaTime

using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace {

class GameController : MonoBehaviour {
	
	[SerializeField]
	private List<Tickable> tickableList = new List<Tickable>();
	
	// set this to false, to stop the GameLoop
	[SerializeField]
	private bool isRunning = true;
	
	[SerializeField]
	private double lastTickTime = 0;
	
	
	// tick 10 times a second
	[SerializeField]
	private double MIN_SECONDS_BETWEEN_TICKS = 0.1;
	
	
	public void Initialize() {
		// TODO: include Lars Wobus' Code in this method
		
		StartCoroutine("GameLoop");
	}
	
	private IEnumerable<WaitForSeconds> GameLoop()
	{
		while(this.isRunning)
		{
			if(1 == Time.timeScale)
			{
				double curTime = Time.timeSinceLevelLoadAsDouble;
				double deltaSinceLastRun = curTime - this.lastTickTime;
				if(deltaSinceLastRun >= MIN_SECONDS_BETWEEN_TICKS)
				{
					foreach(Tickable curTickable in this.tickableList)
					{
						curTickable.tick();
					}
					this.lastTickTime = curTime;
				}
				
			}

			// wait a little
			yield return new WaitForSeconds((float) MIN_SECONDS_BETWEEN_TICKS);
		}
	}
}

}