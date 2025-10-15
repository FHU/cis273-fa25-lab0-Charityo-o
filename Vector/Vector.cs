using System.Runtime.Intrinsics;

namespace Vector;

public struct Vector(double x, double y)
{
    public double X { get; set; } = x;

    public double Y { get; set; } = y;

    public double Magnitude
    {
        get
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    public double Direction => Math.Atan2(Y, X)*180/Math.PI;

    // Instance methods 
    public Vector Add(Vector v)
    {
        Vector result = new Vector();
        result.X = this.X + v.X;
        result.Y = this.Y + v.Y;
        return result;
    }
    public Vector Subtract(Vector v)
    {
        Vector result = new Vector();
        result.X = this.X - v.X;
        result.Y = this.Y - v.Y;
        return result;
    }
    public double Dot(Vector v)
    {
        return this.X * v.X + this.Y * v.Y;
    }
    public double AngleBetween(Vector v)
    {
        double dot = this.Dot(v);
        double magProduct = this.Magnitude * v.Magnitude;
        double cosTheta = dot / magProduct;
        double angleRad = Math.Acos(cosTheta);
        return angleRad * 180.0 / Math.PI;
    }

    public Vector Multiply(double scalar)
    {
        return new Vector(this.X * scalar, this.Y * scalar);
    }

    public Vector Divide(double scalar)
    {
        return new Vector(this.X / scalar, this.Y / scalar);
    }

    public Vector Normalize()
    {
        return Divide(Magnitude);
    }

    public override string ToString()
    {
        return $"<{(int)X}, {(int)Y}>";
    }



    // Class (static) methods 
    public static Vector Add(Vector v1, Vector v2)
    { 
        return v1.Add(v2);
    }

    public static Vector Subtract(Vector v1, Vector v2)
    {
        return v1.Subtract(v2);
    }

    public static double Dot(Vector v1, Vector v2)
    {
        return v1.Dot(v2);
    }

    public static double AngleBetween(Vector v1, Vector v2)
    {
        return v1.AngleBetween(v2);
    }

     public static Vector Multiply(Vector v, double scalar)
    {
        return v.Multiply(scalar);
    }

    public static Vector Divide(Vector v, double scalar)
    {
        return v.Divide(scalar);
    }

    public static Vector Normalize(Vector v)
    {
        return default;
    }

    // Overloaded operators 
    public static Vector operator +(Vector v1, Vector v2) => Vector.Add(v1, v2);

    public static Vector operator -(Vector v1, Vector v2) => Vector.Subtract(v1, v2);

    public static double operator *(Vector v1, Vector v2) => Vector.Dot(v1, v2);

    public static Vector operator *(Vector v1, double scalar) => Vector.Multiply(v1, scalar);

    public static Vector operator /(Vector v1, double scalar) => Vector.Divide(v1, scalar);


}