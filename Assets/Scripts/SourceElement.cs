namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collection.Generic;
    public class SourceElement : FlowElement
    {
        // A water tank or 'SourceElement' is never 'open'
        SourceElement(MapHandler map, Position pos, LiquidBlob content)
        {
            this(map, pos, content, false, false, false, false);
        }

        // Nothing can flow into our water tank!
        public bool TryFill()
        {
            return false;
        }
        public void FlowFurther()
        {
            List<GridElement> targets = this.getTargets(false, true);

            foreach (GridElement curTarget in targets)
            {
                if(null != curTarget)
                {
                    ((FlowElement) curTarget).TryFill();
                }
            }
        }
}