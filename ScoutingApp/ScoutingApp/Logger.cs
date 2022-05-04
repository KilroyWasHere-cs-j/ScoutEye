using System;
using System.IO;

namespace ScoutingApp
{
    public class Logger
    {
        public Logger()
        {

        }

        //<summary>
        //Log data file log file, also include in the current date and time
        //<summary>
        public async void Log(string message)
        {
            string content = File.ReadAllText("Log.txt");
            message = content + "\n" + DateTime.Now.ToLongDateString() + "->" + message;
            await File.WriteAllTextAsync("Log.txt", message);
        }
    }
}
