using System.Reflection;
using System.Text;
using DoCoMoPlayer.Forms;
using DoCoMoPlayer.Resources;
using ImGui.Forms;
using ImGui.Forms.Models;
using Serilog;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var logConfig = new LoggerConfiguration();
logConfig.WriteTo.Console();
logConfig.WriteTo.File("docomo.log");

ILogger logger = logConfig.CreateLogger();
java.util.System.Out.Setup(logger);

var app = new Application(LocalizationResources.Instance);

Application.FontFactory.RegisterFromResource(Assembly.GetExecutingAssembly(), "roboto.ttf", 15, FontGlyphRange.Default, "“”");
Application.FontFactory.RegisterFromResource(Assembly.GetExecutingAssembly(), "notojp.ttf", 15, FontGlyphRange.ChineseJapaneseKorean | FontGlyphRange.Symbols);

var form = new MainForm();
app.Execute(form);