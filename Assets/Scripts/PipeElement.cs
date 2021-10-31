


using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class PipeElement : FlowElement
    {
        public static PipeElement CreateElement(Vector3Int intPos, Tilemap tilemap, MapHandler map)
        {
            var topPos = new Vector3Int(intPos.x, intPos.y + 1, intPos.z);
            var rightPos = new Vector3Int(intPos.x + 1, intPos.y, intPos.z);
            var bottomPos = new Vector3Int(intPos.x, intPos.y - 1, intPos.z);
            var leftPos = new Vector3Int(intPos.x - 1, intPos.y, intPos.z);

            var topOpen = tilemap.GetTile(topPos);
            var rightOpen = tilemap.GetTile(rightPos);
            var bottomOpen = tilemap.GetTile(bottomPos);
            var leftOpen = tilemap.GetTile(leftPos);

            return new PipeElement(
                map,
                new Position(intPos),
                topOpen,
                rightOpen,
                bottomOpen,
                leftOpen);
        }
        
        protected PipeElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
        }
		
        /// <summary>
        /// Pipes don't care about ticking.
		/// when TryFill() is called upon them, they immediatly call FlowFurther()
        /// </summary>
        /// <returns>nothing</returns>
		public override void tick() {}

		// Pipe can always be filled
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            this.content = blob;
            this.sourcePos = fromPos;
			// flow further immediately.
			//   if this is supposed to delay flowing slightly,
			//   then this should be moved to method 'tick()' above
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
}