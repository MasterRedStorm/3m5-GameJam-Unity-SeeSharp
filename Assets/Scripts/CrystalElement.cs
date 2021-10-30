namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class CrystalElement : FlowElement
    {
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