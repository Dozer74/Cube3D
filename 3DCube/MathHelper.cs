using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cube3D
{
    public static class MathHelper
    {
        public static Vector3D RotateX(Vector3D point3D, float degrees)
        {
            //[ a  b  c ] [ x ]   [ x*a + y*b + z*c ]
            //[ d  e  f ] [ y ] = [ x*d + y*e + z*f ]
            //[ g  h  i ] [ z ]   [ x*g + y*h + z*i ]

            //[ 1    0        0   ]
            //[ 0   cos(x)  sin(x)]
            //[ 0   -sin(x) cos(x)]

            double cDegrees = degrees *  Math.PI / 180.0;
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double y = (point3D.Y * cosDegrees) + (point3D.Z * sinDegrees);
            double z = (point3D.Y * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Vector3D(point3D.X, y, z);
        }

        public static Vector3D RotateY(Vector3D point3D, float degrees)
        {
            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = degrees *  Math.PI / 180.0;
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (point3D.X * cosDegrees) + (point3D.Z * sinDegrees);
            double z = (point3D.X * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Vector3D(x, point3D.Y, z);
        }

        public static Vector3D RotateZ(Vector3D point3D, float degrees)
        {
            //[ cos(x)  sin(x) 0]
            //[ -sin(x) cos(x) 0]
            //[    0     0     1]

            double cDegrees = degrees *  Math.PI / 180.0;
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (point3D.X * cosDegrees) + (point3D.Y * sinDegrees);
            double y = (point3D.X * -sinDegrees) + (point3D.Y * cosDegrees);

            return new Vector3D(x, y, point3D.Z);
        }

        public static Vector3D[] RotateX(Vector3D[] points3D, float degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateX(points3D[i], degrees);
            }
            return points3D;
        }

        public static Vector3D[] RotateY(Vector3D[] points3D, float degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateY(points3D[i], degrees);
            }
            return points3D;
        }

        public static Vector3D[] RotateZ(Vector3D[] points3D, float degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateZ(points3D[i], degrees);
            }
            return points3D;
        }

        public static Vector3D Translate(Vector3D points3D, Vector3D oldOrigin, Vector3D newOrigin)
        {
            Vector3D difference = new Vector3D(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y,
                newOrigin.Z - oldOrigin.Z);
            points3D.X += difference.X;
            points3D.Y += difference.Y;
            points3D.Z += difference.Z;
            return points3D;
        }

        public static Vector3D[] Translate(Vector3D[] points3D, Vector3D oldOrigin, Vector3D newOrigin)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
            }
            return points3D;
        }

        //Converts 3D points to 2D points
        public static PointF Get2D(Vector3D vec, Point drawOrigin, Vector3D cubeOrigin)
        {
            PointF point = new PointF();

            float zoom = (float)Screen.PrimaryScreen.Bounds.Width / 1.5f;
            var tempCam = new Vector3D
            {
                X = cubeOrigin.X,
                Y = cubeOrigin.Y,
                Z = (cubeOrigin.X * zoom) / cubeOrigin.X
            };

            float zValue = -vec.Z - tempCam.Z;

            point.X = (tempCam.X - vec.X) / zValue * zoom;
            point.Y = (tempCam.Y - vec.Y) / zValue * zoom;
            return new PointF(point.X + drawOrigin.X, point.Y + drawOrigin.Y);
        }
    }


}
