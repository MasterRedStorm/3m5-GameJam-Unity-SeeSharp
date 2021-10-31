using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class CrystalElement : FlowElement
    {
        public static CrystalElement CreateElement(Vector3Int intPos, Tilemap tilemap, MapHandler map)
        {
            var topPos = new Vector3Int(intPos.x, intPos.y + 1, intPos.z);
            var rightPos = new Vector3Int(intPos.x + 1, intPos.y, intPos.z);
            var bottomPos = new Vector3Int(intPos.x, intPos.y - 1, intPos.z);
            var leftPos = new Vector3Int(intPos.x - 1, intPos.y, intPos.z);

            var topOpen = tilemap.GetTile(topPos);
            var rightOpen = tilemap.GetTile(rightPos);
            var bottomOpen = tilemap.GetTile(bottomPos);
            var leftOpen = tilemap.GetTile(leftPos);

            return new CrystalElement(
                map,
                new Position(intPos),
                topOpen,
                rightOpen,
                bottomOpen,
                leftOpen);
        }
        
        protected CrystalElement(MapHandler map, Position pos, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
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