using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PipeElement : FlowElement
    {
        private MapHadler map;
        private Position pos = null;
        private bool openTop = false;
        private bool openRight = false;
        private bool openBottom = false;
        private bool openLeft = false;
        PipeElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft)
        {
            this.pos = pos;
            this.openTop = openTop;
            this.openRight = openRight;
            this.openBottom = openBottom;
            this.openLeft = openLeft;
        }
        private bool[] openings = [false, false, false, false];
        private LiquidBlob content = null;
        private Position sourcePos = null;

        public bool TryFill(Position fromPos, LiquidBlob blob)
        {
            this.content = blob;
            this.sourcePos = fromPos;
            if (null != this.content)
            {
                this.flowFurther();
            }
        }

        private void FlowFurther()
        {
            List<GridElement> targets = new List<GridElement>();
            int x = this.pos.GetX();
            int y = this.pos.GetY();

            if(this.openTop) targets.add(map.GetElementAtPos(x, y - 1);
            if(this.openRight) targets.add(map.GetElementAtPos(x + 1, y));
            if(this.openBottom) targets.add(map.GetElementAtPos(x, y + 1));
            if(this.openLeft) targets.add(map.GetElementAtPos(x - 1, y)));

            // remove invalid Targets
            for (int i = 0; i < targets.length; i++)
            {
                bool nullify = false;
                // mark as null if the GridElement implements the FlowElement interface
                if (!typeof(FlowElement).IsAssignableFrom(targets.get(i)))
                {
                    nullify = true;
                }

                // mark as null if target blob is equals the source blob
                if (null != this.sourcePos && targets.get(i).getPosition.Equals(this.sourcePos.getPosition()))
                {
                    nullify = true;
                }

                if (nullify)
                {
                    nullify = true;
                    targets.RemoveAt(i);
                    // not needed
                    //    targets.Insert(i, null);
                }
            }
            
            
            //TODO: foreach TryFlow, if at least one TryFlow was successfull, then nullifiy our content
            
        }
    }
}