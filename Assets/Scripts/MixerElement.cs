namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class MixerElement : FlowElement
    {
        
        
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            // TODO: implement me
            // make it dependent on button press
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