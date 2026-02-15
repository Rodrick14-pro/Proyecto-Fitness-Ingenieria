using System;
using System.IO;
namespace ProfessionalPayments.Services;

public class BmiHistoryService
{
    private const string FileName = "bmi_record.txt";

    public void SaveRecord(double bmi, string classification)
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        string logEntry = $"[{date}] BMI: {bmi:F2} - Classification: {classification}{Environment.NewLine}";
        
        File.AppendAllText(FileName, logEntry);
    }
    
    public string GetHistory()
    {
        if (File.Exists(FileName))
        {
            return File.ReadAllText(FileName);
        }

        // 2. Si no existe, devolvemos un mensaje amigable
        return "No history found yet. Start by calculating your BMI! 🚀";
    }

    public string ClearHistory()
    {
        if (File.Exists(FileName))
        {
            File.Delete(FileName);
            return "🗑️  History cleared successfully!";
        }
        return "⚠️  No history file found to delete.";
    }
}
