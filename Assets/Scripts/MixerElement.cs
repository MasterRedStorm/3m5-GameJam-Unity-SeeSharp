namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class MixerElement : FlowElement
    {
        MixerElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
        }
		
		public override void tick()
		{
			this.FlowFurther();
		}
        
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            // TODO: make it dependent on button press!
			
			if(null != this.content)
			{
				this.content.MixBlob(blob);
			} else
			{
				this.content = null;
			}
			// TODO: Reconsider this
			return true;
        }


        public override void FlowFurther()
        {
            List<GridElement> targets = this.GetTargets(true, true);
            
            // Count successfull flows
            int countSuccessfullFlows = 0;
            foreach (FlowElement curTarget in targets)
            {
                if (null != curTarget)
                {
                    if (((FlowElement) curTarget).TryFill(this.pos, this.content))
                    {
                        countSuccessfullFlows += 1;
                    }
                }
            }

            if (countSuccessfullFlows >= 1)
            {
                this.Clear();
            }
        }
    }
}