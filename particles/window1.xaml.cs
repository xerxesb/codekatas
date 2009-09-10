using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Particles
{
    public partial class Window1 : Window
    {
        System.Windows.Threading.DispatcherTimer frameTimer;

        private Point3D spawnPoint;
        private double elapsed;
        private double totalElapsed;
        private int lastTick;
        private int currentTick;

        private int frameCount;
        private double frameCountTime;
        private int frameRate;

        private ParticleSystemManager pm;

        private Random rand;

        public Window1()
        {
            InitializeComponent();

            frameTimer = new System.Windows.Threading.DispatcherTimer();
            frameTimer.Tick += OnFrame;
            frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            frameTimer.Start();

            spawnPoint = new Point3D(0.0, 0.0, 0.0);
            lastTick = Environment.TickCount;

            pm = new ParticleSystemManager();

            var systems = pm.CreateParticleSystems(1000, Colors.Gray, Colors.Red, Colors.Silver, Colors.Orange, Colors.Yellow);
            systems.ForEach(x => WorldModels.Children.Add(x));
            
            rand = new Random(this.GetHashCode());

            KeyDown += Window1_KeyDown;
            Cursor = System.Windows.Input.Cursors.None;
        }

        void Window1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
                this.Close();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            // Calculate frame time;
            this.currentTick = Environment.TickCount;
            this.elapsed = (double)(this.currentTick - this.lastTick) / 1000.0;
            this.totalElapsed += this.elapsed;
            this.lastTick = this.currentTick;

            frameCount++;
            frameCountTime += elapsed;
            if (frameCountTime >= 1.0)
            {
                frameCountTime -= 1.0;
                frameRate = frameCount;
                frameCount = 0;
                this.FrameRateLabel.Content = "FPS: " + frameRate.ToString() + "  Particles: " + pm.ActiveParticleCount.ToString();
            }

            pm.Update((float)elapsed);
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Red, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Orange, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Silver, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Gray, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Red, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Orange, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Silver, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Gray, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Red, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Yellow, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Silver, rand.NextDouble(), 2.5 * rand.NextDouble());
            pm.SpawnParticle(this.spawnPoint, 10.0, Colors.Yellow, rand.NextDouble(), 2.5 * rand.NextDouble());

            double c = Math.Cos(this.totalElapsed);
            double s = Math.Sin(this.totalElapsed);

            this.spawnPoint = new Point3D(s * 32.0, c * 32.0, 0.0);
        }

    }
}