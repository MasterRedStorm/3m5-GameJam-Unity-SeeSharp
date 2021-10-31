


using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class PipeElement : FlowElement
    {
        public static PipeElement CreateElement(Vector3Int intPos, Tilemap tilemap)
        {
            var topPos = new Vector3Int(intPos.x, intPos.y + 1, intPos.z);
            var rightPos = new Vector3Int(intPos.x + 1, intPos.y, intPos.z);
            var bottomPos = new Vector3Int(intPos.x, intPos.y - 1, intPos.z);
            var leftPos = new Vector3Int(intPos.x - 1, intPos.y, intPos.z);

            var topOpen = tilemap.GetTile(topPos);
            var rightOpen = tilemap.GetTile(rightPos);
            var bottomOpen = tilemap.GetTile(bottomPos);
            var leftOpen = tilemap.GetTile(leftPos);

            return new PipeElement(null, null, topOpen, rightOpen, bottomOpen, leftOpen);
        }
        
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

    /*public class StraightVertical : PipeElement
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
    
    public class ThreeWayLeftTopRight : PipeElement
    {
        protected ThreeWayLeftTopRight(MapHandler map, Position pos) : base(map, pos, true, true, false, true)
        {
        }
    }*/
}