using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XXX30.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "NetPro.Startup");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //ApolloClientHelper.ApolloConfig(hostingContext, config, args);
                    //Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                    // .ReadFrom.Configuration(config.Build())
                    // .CreateLogger(); //������Ҫ��װSerilog������ע�ͣ����serilog nuget�����ڳ����������cspro�����ļ���
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSerilog();
                    webBuilder.ConfigureKestrel(options =>
                    {
                        //options.Limits.MaxRequestBodySize = null;// �����쳣 Unexpected end of request content.
                    });
                });
    }
}
