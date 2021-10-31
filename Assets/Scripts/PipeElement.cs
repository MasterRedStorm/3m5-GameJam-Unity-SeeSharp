


namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class PipeElement : FlowElement
    {
        protected PipeElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
        }

		// Pipe can always be filled
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            this.content = blob;
            this.sourcePos = fromPos;
            if (null != this.content)
            {
                this.FlowFurther();
            }
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

    public class StraightVertical : PipeElement
    {
        protected StraightVertical(MapHandler map, Position pos) : base(map, pos, true, false, false, true)
        {
        }
    }
    
    public class StraightHorizontal : PipeElement
    {
        protected StraightHorizontal(MapHandler map, Position pos) : base(map, pos, false, true, true, false)
        {
        }
    }

    public class CurveTopRight : PipeElement
    {
        protected CurveTopRight(MapHandler map, Position pos) : base(map, pos, true, true, false, false)
        {
        }
    }
    
    public class CurveRightBottom : PipeElement
    {
        protected CurveRightBottom(MapHandler map, Position pos) : base(map, pos, false, true, true, false)
        {
        }
    }
    
    public class CurveBottomLeft : PipeElement
    {
        protected CurveBottomLeft(MapHandler map, Position pos) : base(map, pos, false, false, true, true)
        {
        }
    }
    
    public class CurveTopLeft : PipeElement
    {
        protected CurveTopLeft(MapHandler map, Position pos) : base(map, pos, true, false, false, true)
        {
        }
    }
    
    public class ThreeWayTopRightBottom : PipeElement
    {
        protected ThreeWayTopRightBottom(MapHandler map, Position pos) : base(map, pos, true, true, true, false)
        {
        }
    }
    
    public class ThreeWayRightBottomLeft : PipeElement
    {
        protected ThreeWayRightBottomLeft(MapHandler map, Position pos) : base(map, pos, false, true, true, true)
        {
        }
    }
    
    public class ThreeWayBottomLeftTop : PipeElement
    {
        protected ThreeWayBottomLeftTop(MapHandler map, Position pos) : base(map, pos, true, false, true, true)
        {
        }
    }
    
    public class ThreeWayLeftTopRigth : PipeElement
    {
        protected ThreeWayLeftTopRigth(MapHandler map, Position pos) : base(map, pos, true, true, false, true)
        {
        }
    }
}