using Serilog;

Environment.SetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "NetPro.Startup");//;NetPro.ConsulClient");

var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                     .ReadFrom.Configuration(config.Build())
                     .CreateLogger(); //������Ҫ��װSerilog������ע�ͣ����serilog nuget�����ڳ����������cspro�����ļ���
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSerilog();
                    webBuilder.ConfigureKestrel(options =>
                    {
                        //options.Limits.MaxRequestBodySize = null;// �����쳣 Unexpected end of request content.
                    });
                });

host.Build().Run();
