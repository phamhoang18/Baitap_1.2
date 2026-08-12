//Phạm Huy Hoàng - 24810340415
using System;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NetInfoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "NetInfoApp - System & Runtime Info";

            Console.WriteLine("    THÔNG TIN MÔI TRƯỜNG THỰC THI (.NET RUNTIME)   ");

            Version clrVersion = Environment.Version;
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string frameworkName = executingAssembly.GetCustomAttribute<System.Runtime.Versioning.TargetFrameworkAttribute>()?.FrameworkName
                                   ?? RuntimeInformation.FrameworkDescription;

            Console.WriteLine("1. PHIÊN BẢN NET & CLR");
            Console.WriteLine($" • Phiên bản CLR:             {clrVersion}");
            Console.WriteLine($" • Framework Runtime:         {RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($" • Target Framework:          {frameworkName}");
            Console.WriteLine();

            string machineName = Environment.MachineName;
            string userName = Environment.UserName;
            string userDomain = Environment.UserDomainName;

            Console.WriteLine("2. HỆ THỐNG & NGƯỜI DÙNG");
            Console.WriteLine($" • Tên máy tính (Computer):   {machineName}");
            Console.WriteLine($" • Tên người dùng (User):     {userName}");
            Console.WriteLine($" • Domain / Workgroup:        {userDomain}");
            Console.WriteLine();

            OperatingSystem os = Environment.OSVersion;
            bool is64BitOS = Environment.Is64BitOperatingSystem;
            bool is64BitProcess = Environment.Is64BitProcess;
            Architecture processArch = RuntimeInformation.ProcessArchitecture;

            Console.WriteLine("3. HỆ ĐIỀU HÀNH & KIẾN TRÚC CPU");
            Console.WriteLine($" • Hệ điều hành (OS):         {os}");
            Console.WriteLine($" • OS 64-bit:                 {(is64BitOS ? "Có" : "Không")}");
            Console.WriteLine($" • Tiến trình ứng dụng:       {(is64BitProcess ? "64-bit" : "32-bit")} ({processArch})");
            Console.WriteLine($" • Số nhân CPU (Processors):  {Environment.ProcessorCount}");
            Console.WriteLine();

            long gcMemoryBytes = GC.GetTotalMemory(forceFullCollection: false);
            double gcMemoryMB = gcMemoryBytes / (1024.0 * 1024.0);

            Console.WriteLine("4. BỘ NHỚ QUẢN LÝ (GARBAGE COLLECTOR)");
            Console.WriteLine($" • Bộ nhớ GC đang dùng:       {gcMemoryBytes:N0} Bytes (~{gcMemoryMB:F2} MB)");
            Console.WriteLine($" • Số lần thu gom Gen 0:      {GC.CollectionCount(0)}");
            Console.WriteLine($" • Số lần thu gom Gen 1:      {GC.CollectionCount(1)}");
            Console.WriteLine($" • Số lần thu gom Gen 2:      {GC.CollectionCount(2)}");

            Console.ReadKey();
        }
    }
}
