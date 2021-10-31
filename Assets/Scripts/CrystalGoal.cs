using UnityEngine;

namespace DefaultNamespace {

    class CrystalGoal {
	    public LiquidBlob liquid;
		public int initiallyNeededAmount;
		public int remainingAmount;
		
		CrystalGoal(LiquidBlob liquid, int necessaryAmount)
		{
			this.liquid = liquid;
			this.remainingAmount = this.initiallyNeededAmount = necessaryAmount;
		}
		
		public bool IsApplyable(LiquidBlob someLiquid)
		{
			if(someLiquid?.color.Equals(this.liquid.color))
			{
				return true;
			} else
			{
				return false;
			}
		}
		
		public void Apply(LiquidBlob someLiquid)
		{
			if(this.isApplyable(someLiquid))
			{
				this.remainingAmount -= 1;
			}
		}
		
		public static List<CrystalGoal> GenerateGoals(int totalAmount)
		{
			int remainingAmount = totalAmount;
			List<CrystalGoal> list = new List<CrystalGoal>();
			int currentIteration = 0;
			int biggestAmountVal = 0;
			int biggestAmountIndex = 0;
			
			for(; remainingAmount > 0; currentIteration++)
			{
				int randVal = Random.Range(50.0f, 250.0f);
				LiquidBlob randLiquid = this.RandomLiquid();
				list.Add(new CrystalGoal(randLiquid, randVal));
				
				remainingAmount -= randVal;
				if(randVal > biggestAmountVal)
				{
					biggestAmountVal = randVal;
					biggestAmountIndex = currentIteration;
				}
			}
			
			// reduce the biggest goal by the overshot we got
			if(remainingAmount < 0)
			{
				list[biggestAmountIndex].initiallyNeededAmount += remainingAmount;
				
				remainingAmount = 0;
			}
			return list;
		}
		public static LiquidBlob[] validLiquids = {
			LiquidBlob(255, 0, 0),
			LiquidBlob(0, 0, 255),
			LiquidBlob(255, 0, 255) };
		public static LiquidBlob RandomLiquid()
		{
			int randVal = Random.Range(0, CrystalGoal.validLiquids.Count);
			return validLiquids[randVal];
		}
	}
}