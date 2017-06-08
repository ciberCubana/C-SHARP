using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            File.Delete("/Users/npgamboa/Documents/Csharp-class/mvc/bin/Debug/netcoreapp1.1/guest.db");
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            
            host.Run();
        }
    }
}
