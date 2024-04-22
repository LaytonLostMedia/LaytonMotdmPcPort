using System.Text;
using LaytonMotdm.Forms;
using ImGui.Forms;
using LaytonMotdm.Resources;
using Serilog;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var logConfig = new LoggerConfiguration();
logConfig.WriteTo.Console();
logConfig.WriteTo.File("docomo.log");

ILogger logger = logConfig.CreateLogger();
DocomoCsJavaBridge.System.Out.Setup(logger);

var app = new Application(LocalizationResources.Instance);
var form = new MainForm();

app.Execute(form);