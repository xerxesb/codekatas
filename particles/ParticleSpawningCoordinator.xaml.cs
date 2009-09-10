using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Particles
{
    public class ParticleSpawningCoordinator
    {
        private readonly ParticleSystemManager _particleSystemManager;
        private readonly Random _randomNumberGenerator;

        public ParticleSpawningCoordinator(ParticleSystemManager particleSystemManager, Random randomNumberGenerator)
        {
            _particleSystemManager = particleSystemManager;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public void SpawnParticles(Point3D spawnPoint, params Color[] color)
        {
            color.ForEach(x => _particleSystemManager.SpawnParticle(spawnPoint, 10.0, x, _randomNumberGenerator.NextDouble(), 2.5 * _randomNumberGenerator.NextDouble()));
        }
    }
}