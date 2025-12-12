using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;

public sealed class MonitorZasobow : IDisposable
{
    private readonly Timer timer;
    private readonly Stopwatch sw;
    private readonly int logicalCores;
    private PerformanceCounter cpuProc;                 // Process\% Processor Time
    private PerformanceCounter wsPrivate;               // Process\Working Set - Private (B)
    private readonly string instanceName;

    private readonly List<double> cpuSamples = new();   // % jednego rdzenia
    private readonly List<double> ramSamples = new();   // MB (Working Set - Private)

    private double maxCpu = 0;
    private long maxRam = 0;

    public double MaxCpu => maxCpu;                     // [% 1 rdzeń]
    public long MaxRam => maxRam;                       // [B]
    public TimeSpan CzasPomiaru => sw.Elapsed;

    public MonitorZasobow()
    {
        logicalCores = Environment.ProcessorCount;
        instanceName = ResolveProcessInstanceName(Process.GetCurrentProcess().Id);

        cpuProc = new PerformanceCounter("Process", "% Processor Time", instanceName, true);
        wsPrivate = new PerformanceCounter("Process", "Working Set - Private", instanceName, true);

        // „rozgrzewka” liczników
        _ = cpuProc.NextValue();
        _ = wsPrivate.NextValue();

        timer = new Timer(1000) { AutoReset = true };
        timer.Elapsed += OnTick;

        sw = new Stopwatch();
    }

    // Upewnij się, że trafiasz w instancję odpowiadającą PID
    private static string ResolveProcessInstanceName(int pid)
    {
        var cat = new PerformanceCounterCategory("Process");
        foreach (var name in cat.GetInstanceNames())
        {
            using var c = new PerformanceCounter("Process", "ID Process", name, true);
            if ((int)c.RawValue == pid) return name;
        }
        throw new InvalidOperationException("Nie znaleziono instancji procesu dla PID=" + pid);
    }

    private void OnTick(object? s, ElapsedEventArgs e)
    {
        // Uwaga: Process\% Processor Time może przekraczać 100 na wielordzeniowych CPU
        double cpuOneCore = Math.Max(0, cpuProc.NextValue() / logicalCores);
        double ramMb = wsPrivate.NextValue() / (1024.0 * 1024.0);

        if (cpuOneCore > maxCpu) maxCpu = cpuOneCore;
        long ramBytes = (long)(ramMb * 1024 * 1024);
        if (ramBytes > maxRam) maxRam = ramBytes;

        cpuSamples.Add(cpuOneCore);
        ramSamples.Add(ramMb);
    }

    public void Start()
    {
        cpuSamples.Clear();
        ramSamples.Clear();
        maxCpu = 0;
        maxRam = 0;
        sw.Restart();
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
        sw.Stop();
    }

    public void ZapiszCsvIZestawienie(string folderDocelowy)
    {
        Directory.CreateDirectory(folderDocelowy);

        // 1) Pełny log próbek (CSV)
        string csvPath = Path.Combine(folderDocelowy, $"monitor_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
        using (var w = new StreamWriter(csvPath))
        {
            w.WriteLine("sekunda;cpu_1core_pct;ram_ws_private_mb");
            for (int i = 0; i < cpuSamples.Count; i++)
                w.WriteLine($"{i + 1};{cpuSamples[i]:F2};{ramSamples.ElementAtOrDefault(i):F2}");
        }

        // 2) Zestawienie z percentylami
        string sumPath = Path.Combine(folderDocelowy, $"monitor_summary_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
        var p50cpu = Percentyl(cpuSamples, 0.50);
        var p95cpu = Percentyl(cpuSamples, 0.95);
        var p50ram = Percentyl(ramSamples, 0.50);
        var p95ram = Percentyl(ramSamples, 0.95);

        File.WriteAllText(sumPath,
$@"Czas pomiaru: {CzasPomiaru.TotalSeconds:F0} s
CPU (1 rdzeń): P50={p50cpu:F2}%  P95={p95cpu:F2}%  MAX={MaxCpu:F2}%
RAM (WS-Private): P50={p50ram:F2} MB  P95={p95ram:F2} MB  MAX={MaxRam / (1024.0 * 1024.0):F2} MB
Próbek: {cpuSamples.Count}");

        // (opcjonalnie) komunikat
        Console.WriteLine($"Zapisano: {csvPath}");
        Console.WriteLine($"Zapisano: {sumPath}");
    }
    public void LogujWyniki()
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        ZapiszCsvIZestawienie(desktop);
    }


    private static double Percentyl(List<double> data, double p)
    {
        if (data == null || data.Count == 0) return 0;
        var s = data.OrderBy(x => x).ToArray();
        if (p <= 0) return s[0];
        if (p >= 1) return s[s.Length - 1];
        double n = (s.Length - 1) * p;
        int k = (int)Math.Floor(n);
        double frac = n - k;
        return s[k] + frac * (s[Math.Min(k + 1, s.Length - 1)] - s[k]);
    }

    public void Dispose()
    {
        timer?.Dispose();
        cpuProc?.Dispose();
        wsPrivate?.Dispose();
        sw?.Stop();
    }
}
