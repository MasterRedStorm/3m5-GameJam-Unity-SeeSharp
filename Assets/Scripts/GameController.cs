//Time.deltaTime

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace {

class GameController : MonoBehaviour {
	
	public static GameController theOneAndOnly;
	
	public GameController()
	{
		GameController.theOneAndOnly = this;
	}
	// should be called by Unity
	public Start()
	{
		this.CrystalGoals = CrystalGoal.GenerateGoals();
	}
	public Update()
	{
	}
	
	public List<CrystalGoal> CrystalGoals = null;
	
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
	
	
	public void Initialize(List<FlowElement> flowElements) {
		GameController.theOneAndOnly = this;
		
		tickableList.AddRange(flowElements);
	}
	
	public void run()
	{
		this.isRunning = true;
		StartCoroutine("GameLoop");
	}
	
	private IEnumerator GameLoop()
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