namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class CrystalElement : FlowElement
    {
		// from 0 (nothing) to 1000 (completed) 
		int growthStage {
			get;
			set;
		}
		const int MAX_GROWTH_STAGE = 1000;
		CrystalElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
			// from 0 (nothing) to 1000 (completed)
			this.growthStage = 0;
        }
		
		public override void tick()
		{
			if(null != this.content)
			{
				// from 0 (nothing) to 1000 (completed)
				if(this.growthStage < CrystalElement.MAX_GROWTH_STAGE)
				{
					this.growthStage += 1;
				}
				
				this.content = null;
			}
		}
		
		public bool IsComplete()
		{
			if(CrystalElement.MAX_GROWTH_STAGE == this.growthStage)
			{
				return true;
			} else
			{
				return false;
			}
		}
		
		public double CompletionInPercent()
		{
			return (this.growthStage * 100.00 / CrystalElement.MAX_GROWTH_STAGE);
		}
		
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
			this.content = blob;
			
            // TODO: figure out
            // the real magic happens here
			return true;
        }

        //non-sensical for this class
        public override void FlowFurther()
        {
            return;
        }
    }
}