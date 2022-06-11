using HeartBeatService;
using Topshelf;

var exitCode = HostFactory.Run(x =>
{
    x.Service<HeartBeat>(s =>
    {
        s.ConstructUsing(heartbeat => new HeartBeat());
        s.WhenStarted(heartbeat => heartbeat.Start());
        s.WhenStopped(heartbeat => heartbeat.Stop());
    });
    x.RunAsLocalSystem();

    x.SetServiceName("HeartbeatService");
    x.SetDisplayName("Heartbeat Service");
    x.SetDescription("Some test Service for lab");

});

int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
Environment.Exit(exitCodeValue);