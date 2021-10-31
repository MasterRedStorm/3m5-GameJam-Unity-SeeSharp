namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class SourceElement : FlowElement
    {
        // A water tank or 'SourceElement' is never 'open'
        public SourceElement(MapHandler map, Position pos, LiquidBlob content) : base(map, pos, content, false, false, false, false)
        {
        }

		public override void tick()
		{
			this.FlowFurther();
		}

        // Nothing can flow into our water tank!
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            return false;
        }
        public override void FlowFurther()
        {
            List<GridElement> targets = base.GetTargets(false, true);

            foreach (GridElement curTarget in targets)
            {
                if(null != curTarget)
                {
                    ((FlowElement) curTarget).TryFill(this.pos, this.content);
                }
            }
        }
	}
}