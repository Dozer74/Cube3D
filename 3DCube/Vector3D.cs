namespace Cube3D
{
    public class Vector3D
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D(double x, double y, double z)
        {
            X = (float)x;
            Y = (float)y;
            Z = (float)z;
        }

        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D()
        {
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
