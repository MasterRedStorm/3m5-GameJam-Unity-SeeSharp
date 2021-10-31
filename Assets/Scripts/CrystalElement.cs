namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class CrystalElement : FlowElement
    {
		CrystalElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
        }
		
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            //TODO: implement me
            
            // the real magic happens here
			return false;
        }

        //non-sensical for this class
        public override void FlowFurther()
        {
            return;
        }
    }
}