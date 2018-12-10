using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  defines the grid position, world space position,size, neighbours, etc. of a hex tile
///  ref: https://www.redblobgames.com/grids/hexagons/
/// </summary>
public class Hex
{
    // Q+R+S = 0
    public int Q; // col
    public int R; // row
    public int S; //S = -(Q+R)

    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(2) / 2;

    public Hex (int q,int r)
    {
        Q = q;
        R = r;
        S = -(q + r);
    }
    /// <summary>
    /// return the world space position of the hex
    /// 
    /// width
    ///   /\ 
    ///  |  |  height
    ///   \/
    /// </summary>
    /// <returns></returns>
    public Vector3 Position()
    {
        float radius = 1f;//distance from center to pointy end of hex
        float height = radius * 2;
        float width = WIDTH_MULTIPLIER * height;

        float horiz = width;
        float vert = height * 0.75f;

        return new Vector3(
            horiz * (Q+R/2f), //each even row, we need to have another half movement horizontally
            0,
            vert * R);
    }
}
