using System.Windows.Media.Media3D;

namespace Particles
{
    public class Particle
    {
        public Point3D Position;
        public Vector3D Velocity;
        public double StartLife;
        public double Life;
        public double Decay;
        public double StartSize;
        public double Size;
    }
}