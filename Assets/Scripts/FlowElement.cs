

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public abstract class FlowElement : GridElement
    {
        public abstract bool TryFill(Position fromPos, LiquidBlob blob);
        public abstract void FlowFurther();
        
        private LiquidBlob content = null;

        bool OpenTop
        {
            get;
        } = false;

        bool OpenRight
        {
            get;
        } = false;

        bool OpenBottom
        {
            get;
        } = false;

        bool OpenLeft
        {
            get;
        } = false;

        private MapHandler map;
        
        private Position pos;
        public Position GetPosition()
        {
            return this.pos;
        }

        FlowElement(MapHandler map, Position pos, LiquidBlob content, bool openTop, bool openRight, bool openBottom, bool openLeft)
        {
            this.map = map;
            this.pos = pos;
            this.OpenTop = openTop;
            this.OpenRight = openRight;
            this.OpenBottom = openBottom;
            this.OpenLeft = openLeft;
            
        }
        

         /// <summary>
         /// Return a list of potential targets
         /// </summary>
         /// <param name="considerOwnOpenings">whether to consider my own open variables</param>
         /// <param name="considerTargetOpenings">whether to consider the openings of the surrounding elements</param>
         /// <returns>a list containing 'null' wherever targets were invalid</returns>
         private List<GridElement> GetTargets(bool considerOwnOpenings, bool considerTargetOpenings)
        {
            List<GridElement> targets = new List<GridElement>();
            int x = this.pos.GetX();
            int y = this.pos.GetY();

            targets.add(map.GetElementAtPos(x, y - 1));
            targets.add(map.GetElementAtPos(x + 1, y));
            targets.add(map.GetElementAtPos(x, y + 1));
            targets.add(map.GetElementAtPos(x - 1, y));

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
                    this.NullifyThatListElement(targets, i);
                }
            }

            if (considerOwnOpenings)
            {
                if (!this.OpenTop)
                    this.NullifyThatListElement(targets, 0);
                if (!this.OpenRight)
                    this.NullifyThatListElement(targets, 1);
                if (!this.OpenBottom)
                    this.NullifyThatListElement(targets, 2);
                if (!this.OpenLeft)
                    this.NullifyThatListElement(targets, 3);
            }

            if (considerTargetOpenings)
            {
                // just check if it's not null
                //   then we can safely cast to FlowElement
                if (null != targets.get(0) && !((FlowElement) targets.get(0)).getOpenBottom())
                    this.NullifyThatListElement(targets, 0);
                if (null != targets.get(1) && !((FlowElement) targets.get(1)).getOpenLeft())
                    this.NullifyThatListElement(targets, 1);
                if (null != targets.get(2) && !((FlowElement) targets.get(2)).getOpenTop())
					this.NullifyThatListElement(targets, 2);
                if (null != targets.get(3) && !((FlowElement) targets.get(3)).getOpenBottom())
					this.NullifyThatListElement(targets, 3);
            }

            return targets;
        }
        // utility function for GetTargets()
        private void NullifyThatListElement(List<GridElement> list, int index)
        {
            list.RemoveAt(index);
            list.Insert(index, null);
        }

        public void Clear()
        {
            this.content = null;
            this.sourcePos = null;
        }
    }

}