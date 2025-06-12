// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;
using Hardware.Info;
using System.ServiceProcess;

// //system info
// Console.WriteLine("System info");
// Console.WriteLine($"OS: {RuntimeInformation.OSDescription}");
// Console.WriteLine($"Architecture: {RuntimeInformation.OSArchitecture}");
// Console.WriteLine($"Machine name:{Environment.MachineName}");
// Console.WriteLine($"OS version:{Environment.OSVersion}");
// Console.WriteLine($"User:{Environment.UserName}");
// Console.WriteLine($"processor count:{Environment.ProcessorCount}");
// TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount64);
// Console.WriteLine($"System uptime {uptime.Days} days, {uptime.Hours} hours,{uptime.Minutes} minutes");
// HardwareInfo hardwareInfo = new HardwareInfo();
// hardwareInfo.RefreshAll();
// Console.WriteLine($"Total RAM {hardwareInfo.MemoryStatus.TotalPhysical/(1024*1024)} MB");
// Console.WriteLine($"Available RAM {hardwareInfo.MemoryStatus.AvailablePhysical/(1024*1024)} MB");

// DriveInfo[] driveInfo = DriveInfo.GetDrives();
// foreach (var drive in driveInfo)
// {
//     Console.WriteLine($"Drive:{drive}");
//     Console.WriteLine($"Drive type:{drive.DriveType}");
//     if (drive.IsReady)
//     {
//         Console.WriteLine($"File System: {drive.DriveFormat}");
//         Console.WriteLine($"Total size: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
//         Console.WriteLine($"Free space: {drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB");
//         Console.WriteLine($"Available space: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");
//     }
// }

// process info
// Console.WriteLine("Process info");
// Process[] processes = Process.GetProcesses();
// foreach (Process process in processes)
// {
//     Console.WriteLine($"Process name: {process.ProcessName} | Process ID: {process.Id} | Process memeory usage: {process.PrivateMemorySize64 / 1024} KB");
// }

//services
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    ServiceController[] services = ServiceController.GetServices();
    foreach (ServiceController service in services)
    {
        Console.WriteLine($"Service: {service.DisplayName}, Status: {service.Status}");
    }
}
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    Process process = new Process();
    process.StartInfo.FileName = "bash";
    process.StartInfo.Arguments = "-c \"systemctl list-units --type=service --all\"";
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();

    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);

}