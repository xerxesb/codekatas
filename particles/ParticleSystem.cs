using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Particles
{
    public class ParticleSystem
    {        
        private List<Particle> particleList;
        private GeometryModel3D particleModel;
        private int maxParticleCount;
        private Random rand;

        public ParticleSystem(int maxCount, System.Windows.Media.Color color)
        {
            this.maxParticleCount = maxCount;

            this.particleList = new List<Particle>();

            this.particleModel = new GeometryModel3D();
            this.particleModel.Geometry = new MeshGeometry3D();

            Ellipse e = new Ellipse();
            e.Width = 32.0;
            e.Height = 32.0;
            RadialGradientBrush b = new RadialGradientBrush();
            b.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(0xFF, color.R, color.G, color.B), 0.25));
            b.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(0x00, color.R, color.G, color.B), 1.0));
            e.Fill = b;
            e.Measure(new System.Windows.Size(32, 32));
            e.Arrange(new Rect(0, 0, 32, 32));

            var brush = new VisualBrush(e);

            DiffuseMaterial material = new DiffuseMaterial(brush);

            this.particleModel.Material = material;

            this.rand = new Random(brush.GetHashCode());
        }

        public void Update(double elapsed)
        {
            List<Particle> deadList = new List<Particle>();

            // Update all particles
            foreach (Particle p in this.particleList)
            {
                p.Position += p.Velocity * elapsed;
                p.Life -= p.Decay * elapsed;
                p.Size = p.StartSize * (p.Life / p.StartLife);
                if (p.Life <= 0.0)
                    deadList.Add(p);
            }

            foreach (Particle p in deadList)
                this.particleList.Remove(p);

            UpdateGeometry();
        }

        private void UpdateGeometry()
        {
            Point3DCollection positions = new Point3DCollection();
            Int32Collection indices = new Int32Collection();
            PointCollection texcoords = new PointCollection();

            for (int i = 0; i < this.particleList.Count; ++i)
            {
                int positionIndex = i * 4;
                int indexIndex = i * 6;
                Particle p = this.particleList[i];

                Point3D p1 = new Point3D(p.Position.X, p.Position.Y, p.Position.Z);
                Point3D p2 = new Point3D(p.Position.X, p.Position.Y + p.Size, p.Position.Z);
                Point3D p3 = new Point3D(p.Position.X + p.Size, p.Position.Y + p.Size, p.Position.Z);
                Point3D p4 = new Point3D(p.Position.X + p.Size, p.Position.Y, p.Position.Z);

                positions.Add(p1);
                positions.Add(p2);
                positions.Add(p3);
                positions.Add(p4);

                System.Windows.Point t1 = new System.Windows.Point(0.0, 0.0);
                System.Windows.Point t2 = new System.Windows.Point(0.0, 1.0);
                System.Windows.Point t3 = new System.Windows.Point(1.0, 1.0);
                System.Windows.Point t4 = new System.Windows.Point(1.0, 0.0);

                texcoords.Add(t1);
                texcoords.Add(t2);
                texcoords.Add(t3);
                texcoords.Add(t4);

                indices.Add(positionIndex);
                indices.Add(positionIndex+2);
                indices.Add(positionIndex+1);
                indices.Add(positionIndex);
                indices.Add(positionIndex+3);
                indices.Add(positionIndex+2);
            }

            ((MeshGeometry3D)this.particleModel.Geometry).Positions = positions;
            ((MeshGeometry3D)this.particleModel.Geometry).TriangleIndices = indices;
            ((MeshGeometry3D)this.particleModel.Geometry).TextureCoordinates = texcoords;

        }

        public void SpawnParticle(Point3D position, double speed, double size, double life)
        {
            if (this.particleList.Count > this.maxParticleCount)
                return;
            Particle p = new Particle();
            p.Position = position;
            p.StartLife = life;
            p.Life = life;
            p.StartSize = size;
            p.Size = size;

            float x = 1.0f - (float)rand.NextDouble() * 2.0f;
            float z = 1.0f - (float)rand.NextDouble() * 2.0f;

            Vector3D v = new Vector3D(x, z, 0.0);
            v.Normalize();
            v *= ((float)rand.NextDouble() + 0.25f) * (float)speed;

            p.Velocity = new Vector3D(v.X, v.Y, v.Z);

            p.Decay = 1.0f;

            this.particleList.Add(p);
        }

        public int MaxParticleCount
        {
            get
            {
                return this.maxParticleCount;
            }
            set
            {
                this.maxParticleCount = value;
            }
        }

        public int Count
        {
            get
            {
                return this.particleList.Count;
            }
        }

        public Model3D ParticleModel
        {
            get
            {
                return this.particleModel;
            }
        }
    }
}