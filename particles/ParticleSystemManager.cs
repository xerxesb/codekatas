using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Particles
{
    public class ParticleSystemManager
    {
        private Dictionary<System.Windows.Media.Color, ParticleSystem> particleSystems;

        public ParticleSystemManager()
        {
            this.particleSystems = new Dictionary<System.Windows.Media.Color, ParticleSystem>();
        }

        public void Update(float elapsed)
        {
            foreach (ParticleSystem ps in this.particleSystems.Values)
            {
                ps.Update(elapsed);
            }
        }

        public void SpawnParticle(Point3D position, double speed, System.Windows.Media.Color color, double size, double life)
        {
            try
            {
                ParticleSystem ps = this.particleSystems[color];
                ps.SpawnParticle(position, speed, size, life);
            }
            catch { }
        }

        public Model3D CreateParticleSystem(int maxCount, System.Windows.Media.Color color)
        {
            ParticleSystem ps = new ParticleSystem(maxCount, color);
            this.particleSystems.Add(color, ps);
            return ps.ParticleModel;
        }

        public int ActiveParticleCount
        {
            get
            {
                int count = 0;
                foreach (ParticleSystem ps in this.particleSystems.Values)
                    count += ps.Count;
                return count;
            }
        }

        public IEnumerable<Model3D> CreateParticleSystems(int maxParticles, params Color[] colors)
        {
            foreach (var color in colors)
            {
                yield return CreateParticleSystem(maxParticles, color);
            }
        }
    }
}