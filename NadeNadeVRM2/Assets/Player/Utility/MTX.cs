using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 行列ライブラリ Created by Tomohito Suzuki 
/// </summary>
public class MTX
{
    public int h;
    public int w;
    public float[,] element;
    public MTX(int h,int w)
    {
        this.h = h;
        this.w = w;
        element = new float[h,w];
    }
    public static MTX MultiplyMTX(MTX mtx1,MTX mtx2)
    {
        MTX ret = new MTX(mtx1.h, mtx2.w);
        if (mtx1.w != mtx2.h)
        {
            Debug.Log("mtx1.w="+mtx1.w);
            Debug.Log("mtx2.h=" + mtx2.h);
            Debug.Log("演算不可能");
            
        }
        int i, j, k;
        for (i = 0; i < ret.h; i++)
        {
            for (j = 0; j < ret.w; j++)
            {
                for (k = 0; k < mtx1.w; k++)
                {//mtx2.hでも良い
                    ret.element[i,j] += mtx1.element[i,k] * mtx2.element[k,j];
                }
            }
        }
        return ret;
    }
    public static MTX GenerateAffineRotationMTX(float rad)
    {
        MTX ret = new MTX(3,3);
        ret.element[0,0] = Mathf.Cos(rad);
        ret.element[0,1] = -Mathf.Sin(rad);
        ret.element[0,2] = 0;
        ret.element[1,0] = Mathf.Sin(rad);
        ret.element[1,1] = Mathf.Cos(rad);
        ret.element[1,2] = 0;
        ret.element[2,0] = 0;
        ret.element[2,1] = 0;
        ret.element[2,2] = 1;
        return ret;
    }
    public static MTX GenerateAffineTranslationMTX(float x,float y)
    {
        MTX ret = new MTX(3, 3);
        ret.element[0, 0] = 1;
        ret.element[0, 1] = 0;
        ret.element[0, 2] = x;
        ret.element[1, 0] = 0;
        ret.element[1, 1] = 1;
        ret.element[1, 2] = y;
        ret.element[2, 0] = 0;
        ret.element[2, 1] = 0;
        ret.element[2, 2] = 1;
        return ret;
    }
    /// <summary>
    /// 回転軸を指定したAffine行列を生成する
    /// </summary>
    /// <param name="axisX"></param>
    /// <param name="axisY"></param>
    /// <param name="rad"></param>
    /// <returns></returns>
    public static MTX GenerateAffineRotationWithAxisMTX(float axisX,float axisY,float rad)
    {
        MTX mtx1 = GenerateAffineTranslationMTX(axisX, axisY);
        MTX mtxRot = GenerateAffineRotationMTX(rad);
        MTX mtx2 = GenerateAffineTranslationMTX(-axisX, -axisY);
        MTX ret = MultiplyMTX(MultiplyMTX(mtx1, mtxRot),mtx2);
        return ret;
    }
    public void ShowMTX()
    {
        int i, j;
        for (i = 0; i < h; i++)
        {
            string temp = "";
            for (j = 0; j < w; j++)
            {
                temp += element[i, j]+" ";
            }
            Debug.Log(temp);
        }
        
    }
}
