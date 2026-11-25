using System;
using System.IO;
using System.Threading;

namespace XferSerum2Vst3WavetableSynthPres
{
    public sealed class XferSerum2Vst3WavetableSynthPresHost : IDisposable
    {
        public const string BuildSalt = "d0d1ff7e63170a57";
        public const string TargetModule = "xfer-serum-2-vst3-wavetable-synth-preset-suite";
        private volatile bool _active = true;
        public void Initialize(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Configuration file missing.", configPath);
            Console.WriteLine($"[{TargetModule}] Loaded profile: {configPath} ({BuildSalt})");
        }
        public void Dispose() => _active = false;
        public static int Main(string[] args)
        {
            using var host = new XferSerum2Vst3WavetableSynthPresHost();
            if (args.Length > 0 && File.Exists(args[0])) host.Initialize(args[0]);
            return 0;
        }
    }
}
