//Time.deltaTime

using System.Collections.Generic;
using UnityEngine;

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
	
	private void GameLoop()
	{
		while(this.isRunning)
		{
			if()
			foreach(Tickable curTickable in this.tickableList)
			{
				curTickable.tick();
			}
			//TODO: search the respective wait/sleep method
			//sleep(MIN_SECONDS_BETWEEN_TICKS);
		}
	}
}