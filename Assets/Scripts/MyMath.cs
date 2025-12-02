using UnityEngine;

public class MyMath
{
    public static int Sum(int a,int b)
    {
        //throw new System.NotImplementedException();
        return a + b;
    }
    public static float Divide(float a,float b)
    {
        if(b==0)
        {
            throw new System.DivideByZeroException();
        }
        return a / b;
    }
    public float SolveEquation(float a,float b)
    {
        if(a==0)
        {
            if(b==0)
            {
                return 1; 
            }
            else
            {
                throw new System.Exception("No solution");
            }
        }
        else
        {
            return -b / a;
        }
    }
}
