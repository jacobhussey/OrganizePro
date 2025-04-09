using OrganizePro.Models;
using System.Diagnostics;

namespace OrganizePro.Shared;

public static class Logger
{
    private static readonly string LogFilePath = 
        Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Login_History.txt"));

    public static void WriteLog(UserLog log)
    {
        Debug.WriteLine(Path.GetFullPath(LogFilePath));
        string logEntry = $"{log.Username} logged in on {log.Date}";

        using StreamWriter writer = new(LogFilePath, true);

        writer.WriteLine(logEntry);
    }
}