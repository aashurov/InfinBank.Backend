using InfinBank.Application.Interfaces;
using Newtonsoft.Json;

namespace InfinBank.Application.Common.Behaviors;

public class CustomLoggingBehavoir : ICustomLoggingBehavoir
{
    private readonly IDateTimeService _dateTimeService;

    public CustomLoggingBehavoir(IDateTimeService dateTimeService) => _dateTimeService = dateTimeService;

    public void WriteToFileSuccess(string ClassName, object Message)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "Logs";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string filepath = path + "\\InfinBankLog_" + _dateTimeService.Now.ToShortDateString().Replace('/', '_') + ".txt";

        if (!File.Exists(filepath))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine(_dateTimeService.Now + "Success: " + JsonConvert.SerializeObject(Message, Formatting.Indented));
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.WriteLine(_dateTimeService.Now + " Success: " + ClassName + " " + JsonConvert.SerializeObject(Message, Formatting.Indented));
            }
        }
    }
}