using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
namespace Cube3D
{
    public enum ShowMode
    {
        Bones,
        Faces,
        ColorFaces
    }

    public class Cube
    {
        //Cube face, has four points, 3D and 2D
        internal class Face : IComparable<Face>
        {
            public enum Side
            {
                Front,
                Back,
                Left,
                Right,
                Top,
                Bottom
            }

            public PointF[] Corners2D;
            public Vector3D[] Corners3D;
            public Vector3D Center;
            public Side CubeSide;
            public Color Color = SystemColors.Control;

            public int CompareTo(Face otherFace)
            {
                return (int)(this.Center.Z - otherFace.Center.Z); //In order of which is closest to the screen
            }
        }
        
        public int Width;
        public int Height;
        public int Depth;

        private float xRotation;
        private float yRotation;
        private float zRotation;

        private readonly Vector3D origin;

        private Face[] faces;

        public float RotateX
        {
            get => xRotation;
            set
            {
                //rotate the difference between this rotation and last rotation
                //RotateCubeX(value - xRotation);
                var delta = value - xRotation;
                Rotate(delta,MathHelper.RotateX);

                xRotation = value;
            }
        }

        public float RotateY
        {
            get => yRotation;
            set
            {
                var delta = value - yRotation;
                Rotate(delta, MathHelper.RotateY);
                yRotation = value;
            }
        }

        public float RotateZ
        {
            get => zRotation;
            set
            {
                var delta = value - zRotation;
                Rotate(delta, MathHelper.RotateZ);
                zRotation = value;
            }
        }

        public ShowMode ShowMode { get; set; }

        public Cube(int side)
        {
            Width = side;
            Height = side;
            Depth = side;
            origin = new Vector3D(Width / 2, Height / 2, Depth / 2);
            ShowMode = ShowMode.Faces;
            InitializeCube();
        }
        

        private void InitializeCube()
        {
            //Fill in the cube
            faces = new Face[6];

            //Front Face --------------------------------------------
            faces[0] = new Face
            {
                CubeSide = Face.Side.Front,
                Corners3D = new Vector3D[4],
                Color = Color.Red
            };
            faces[0].Corners3D[0] = new Vector3D(0, 0, 0);
            faces[0].Corners3D[1] = new Vector3D(0, Height, 0);
            faces[0].Corners3D[2] = new Vector3D(Width, Height, 0);
            faces[0].Corners3D[3] = new Vector3D(Width, 0, 0);
            faces[0].Center = new Vector3D(Width / 2, Height / 2, 0);
            // -------------------------------------------------------

            //Back Face --------------------------------------------
            faces[1] = new Face
            {
                CubeSide = Face.Side.Back,
                Corners3D = new Vector3D[4],
                Color = Color.Yellow
            };
            faces[1].Corners3D[0] = new Vector3D(0, 0, Depth);
            faces[1].Corners3D[1] = new Vector3D(0, Height, Depth);
            faces[1].Corners3D[2] = new Vector3D(Width, Height, Depth);
            faces[1].Corners3D[3] = new Vector3D(Width, 0, Depth);
            faces[1].Center = new Vector3D(Width / 2, Height / 2, Depth);
            // -------------------------------------------------------

            //Left Face --------------------------------------------
            faces[2] = new Face
            {
                CubeSide = Face.Side.Left,
                Corners3D = new Vector3D[4],
                Color = Color.Blue
            };
            faces[2].Corners3D[0] = new Vector3D(0, 0, 0);
            faces[2].Corners3D[1] = new Vector3D(0, 0, Depth);
            faces[2].Corners3D[2] = new Vector3D(0, Height, Depth);
            faces[2].Corners3D[3] = new Vector3D(0, Height, 0);
            faces[2].Center = new Vector3D(0, Height / 2, Depth / 2);
            // -------------------------------------------------------

            //Right Face --------------------------------------------
            faces[3] = new Face
            {
                CubeSide = Face.Side.Right,
                Corners3D = new Vector3D[4],
                Color = Color.Green
            };
            faces[3].Corners3D[0] = new Vector3D(Width, 0, 0);
            faces[3].Corners3D[1] = new Vector3D(Width, 0, Depth);
            faces[3].Corners3D[2] = new Vector3D(Width, Height, Depth);
            faces[3].Corners3D[3] = new Vector3D(Width, Height, 0);
            faces[3].Center = new Vector3D(Width, Height / 2, Depth / 2);
            // -------------------------------------------------------

            //Top Face --------------------------------------------
            faces[4] = new Face
            {
                CubeSide = Face.Side.Top,
                Corners3D = new Vector3D[4],
                Color = Color.Violet
            };
            faces[4].Corners3D[0] = new Vector3D(0, 0, 0);
            faces[4].Corners3D[1] = new Vector3D(0, 0, Depth);
            faces[4].Corners3D[2] = new Vector3D(Width, 0, Depth);
            faces[4].Corners3D[3] = new Vector3D(Width, 0, 0);
            faces[4].Center = new Vector3D(Width / 2, 0, Depth / 2);
            // -------------------------------------------------------

            //Bottom Face --------------------------------------------
            faces[5] = new Face
            {
                CubeSide = Face.Side.Bottom,
                Corners3D = new Vector3D[4],
                Color = Color.SandyBrown
            };
            faces[5].Corners3D[0] = new Vector3D(0, Height, 0);
            faces[5].Corners3D[1] = new Vector3D(0, Height, Depth);
            faces[5].Corners3D[2] = new Vector3D(Width, Height, Depth);
            faces[5].Corners3D[3] = new Vector3D(Width, Height, 0);
            faces[5].Center = new Vector3D(Width / 2, Height, Depth / 2);
            // -------------------------------------------------------
        }

        //Calculates the 2D points of each face
        private void Update2DPoints(Point drawOrigin)
        {
            //Update the 2D points of all the faces
            foreach (Face face in faces)
            {
                var point2D = new PointF[4];

                //Convert 3D Points to 2D
                for (var i = 0; i < point2D.Length; i++)
                {
                    var vec = face.Corners3D[i];
                    point2D[i] = MathHelper.Get2D(vec, drawOrigin, origin);
                }

                //Update face
                face.Corners2D = point2D;
            }
        }
        
        private void Rotate(float delta, Func<Vector3D, float, Vector3D> rotatingFunc)
        {
            foreach (Face face in faces)
            {
                //------Rotate points
                var point0 = new Vector3D(0, 0, 0);
                face.Corners3D = MathHelper.Translate(face.Corners3D, origin, point0); //Move corner to origin
                face.Corners3D = face.Corners3D.Select(p => rotatingFunc(p, delta)).ToArray();
                face.Corners3D = MathHelper.Translate(face.Corners3D, point0, origin); //Move back

                //-------Rotate center
                face.Center = MathHelper.Translate(face.Center, origin, point0);
                face.Center = rotatingFunc(face.Center, delta);
                face.Center = MathHelper.Translate(face.Center, point0, origin);
            }
        }

        public Bitmap DrawCube(Point drawOrigin)
        {
            //Get the corresponding 2D
            Update2DPoints(drawOrigin);

            //Get the bounds of the final bitmap
            var bounds = GetDrawingBounds();
            bounds.Width += drawOrigin.X;
            bounds.Height += drawOrigin.Y;

            var finalBmp = new Bitmap(bounds.Width, bounds.Height);
            var g = Graphics.FromImage(finalBmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Array.Sort(faces); //sort faces from closets to farthest

            for (var i = faces.Length - 1; i >= 0; i--) //draw faces from back to front
            {
                if (ShowMode==ShowMode.Faces || ShowMode==ShowMode.ColorFaces)
                {
                    var face = faces.FirstOrDefault(f => f.CubeSide == faces[i].CubeSide);
                    if (face != null)
                    {
                        var fillBrush = ShowMode == ShowMode.Faces 
                            ? SystemBrushes.Control 
                            : new SolidBrush(face.Color);

                        g.FillPolygon(fillBrush, face.Corners2D);
                    }
                }

                g.DrawLine(Pens.Black, faces[i].Corners2D[0], faces[i].Corners2D[1]);
                g.DrawLine(Pens.Black, faces[i].Corners2D[1], faces[i].Corners2D[2]);
                g.DrawLine(Pens.Black, faces[i].Corners2D[2], faces[i].Corners2D[3]);
                g.DrawLine(Pens.Black, faces[i].Corners2D[3], faces[i].Corners2D[0]);
            }

            g.Dispose();

            return finalBmp;
        }


        private Rectangle GetDrawingBounds()
        {
            var allPoints = faces.SelectMany(f => f.Corners2D).ToArray();
            var left = allPoints.Min(p => p.X);
            var right = allPoints.Max(p => p.X);
            var top = allPoints.Min(p => p.Y);
            var bottom = allPoints.Max(p => p.Y);

            return new Rectangle(0, 0, (int)Math.Round(right - left), (int)Math.Round(bottom - top));
        }
    }
}
