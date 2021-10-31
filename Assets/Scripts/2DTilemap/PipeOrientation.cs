using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using DefaultNamespace;

/*public static class Orientations
{
    public static Type Straight_0deg = typeof(StraightVertical);
    public static Type Straight_90deg = typeof(StraightHorizontal);
    public static Type Straight_180deg = typeof(StraightVertical);
    public static Type Straight_270deg = typeof(StraightHorizontal);
    
    public static Type Curve_0deg = typeof(CurveRightBottom);
    public static Type Curve_90deg = typeof(CurveTopRight);
    public static Type Curve_180deg = typeof(CurveTopLeft);
    public static Type Curve_270deg = typeof(CurveBottomLeft);
    
    public static Type ThreeWay_0deg = typeof(ThreeWayRightBottomLeft);
    public static Type ThreeWay_90deg = typeof(ThreeWayTopRightBottom);
    public static Type ThreeWay_180deg = typeof(ThreeWayLeftTopRight);
    public static Type ThreeWay_270deg = typeof(ThreeWayBottomLeftTop);
}

public static class PipeOrientation
{
    public static PipeElement CreateStraight(int rotation)
    {
        return CreateInstance(rotation, SelectStraight);
    }
    
    public static PipeElement CreateCurve(int rotation)
    {
        return CreateInstance(rotation, SelectCurve);
    }
    
    public static PipeElement CreateThreeWay(int rotation)
    {
        return CreateInstance(rotation, SelectThreeWay);
    }
    
    private static PipeElement CreateInstance(int rotation, Func<int, Type> select)
    {
        var type = select(rotation);
        if (type == null)
        {
            return null;
        }
        return Activator.CreateInstance(type, new object[] { }) as PipeElement;
    }
    
    private static Type SelectStraight(int rotation)
    {
        switch (rotation)
        {
            case 0: return Orientations.Straight_0deg;
            case 90: return Orientations.Straight_90deg;
            case 180: return Orientations.Straight_180deg;
            case 270: return Orientations.Straight_270deg;
            default:
                return null;
        }
    }
    
    private static Type SelectCurve(int rotation)
    {
        switch (rotation)
        {
            case 0: return Orientations.Curve_0deg;
            case 90: return Orientations.Curve_90deg;
            case 180: return Orientations.Curve_180deg;
            case 270: return Orientations.Curve_270deg;
            default:
                return null;
        }
    }
    
    private static Type SelectThreeWay(int rotation)
    {
        switch (rotation)
        {
            case 0: return Orientations.ThreeWay_0deg;
            case 90: return Orientations.ThreeWay_90deg;
            case 180: return Orientations.ThreeWay_180deg;
            case 270: return Orientations.ThreeWay_270deg;
            default:
                return null;
        }
    }
}*/