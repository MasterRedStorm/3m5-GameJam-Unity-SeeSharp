﻿


namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class PipeElement : FlowElement
    {
        
        PipeElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft)
        {
            this(map, pos, null, openTop, openRight, openBottom, openLeft);
        }
        private Position sourcePos = null;

        public bool TryFill(Position fromPos, LiquidBlob blob)
        {
            this.content = blob;
            this.sourcePos = fromPos;
            if (null != this.content)
            {
                this.FlowFurther();
            }
        }

        
        private void FlowFurther()
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