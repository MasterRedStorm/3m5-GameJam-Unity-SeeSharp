// for class 'List<T>'
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{

    public abstract class FlowElement : GridElement, Tickable
    {
        public abstract bool TryFill(Position fromPos, LiquidBlob blob);
        public abstract void FlowFurther();
		public abstract void tick();
        
        public TilemapIterator TilemapIterator { get; set; }
        
        public LiquidBlob content = null;
		public Position sourcePos = null;

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


        

        public FlowElement(MapHandler map, Position pos, LiquidBlob content, bool openTop, bool openRight, bool openBottom, bool openLeft)
		: base (map, pos)
        {
            this.OpenTop = openTop;
            this.OpenRight = openRight;
            this.OpenBottom = openBottom;
            this.OpenLeft = openLeft;

            this.content = content;
            map.SetElement(pos, this);

        }
        

         /// <summary>
         /// Return a list of potential targets
         /// </summary>
         /// <param name="considerOwnOpenings">whether to consider my own open variables</param>
         /// <param name="considerTargetOpenings">whether to consider the openings of the surrounding elements</param>
         /// <returns>a list containing 'null' wherever targets were invalid</returns>
         protected List<GridElement> GetTargets(bool considerOwnOpenings, bool considerTargetOpenings)
        {
            List<GridElement> targets = new List<GridElement>();
            int x = this.pos.x;
            int y = this.pos.y;

            targets.Add(map.GetElementAtPos(x, y - 1));
            targets.Add(map.GetElementAtPos(x + 1, y));
            targets.Add(map.GetElementAtPos(x, y + 1));
            targets.Add(map.GetElementAtPos(x - 1, y));

            // remove invalid Targets
            for (int i = 0; i < targets.Count; i++)
            {
                bool nullify = false;
                // mark as null if the GridElement implements the FlowElement interface
                if (targets[i] is FlowElement)
                {
                    nullify = true;
                }

                // mark as null if target blob is equals the source blob
                if (null != this.sourcePos && targets[i].GetPosition().Equals(this.sourcePos))
                {
                    nullify = true;
                }

                if (nullify)
                {
                    targets[i] = null;
                }
            }

            if (considerOwnOpenings)
            {
                if (!this.OpenTop)
                    targets[0] = null;
                if (!this.OpenRight)
                    targets[1] = null;
                if (!this.OpenBottom)
                    targets[2] = null;
                if (!this.OpenLeft)
                    targets[3] = null;
            }

            if (considerTargetOpenings)
            {
                // just check if it's not null
                //   then we can safely cast to FlowElement
                if (null != targets[0] && !((FlowElement) targets[0]).OpenBottom)
                    targets[0] = null;
                if (null != targets[1] && !((FlowElement) targets[1]).OpenLeft)
                    targets[1] = null;
                if (null != targets[2] && !((FlowElement) targets[2]).OpenTop)
                    targets[2] = null;
                if (null != targets[3] && !((FlowElement) targets[3]).OpenBottom)
                    targets[3] = null;
            }

            return targets;
        }

         protected void Clear()
        {
            this.content = null;
            this.sourcePos = null;
        }
    }

}