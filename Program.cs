using System;
using System.Diagnostics;
using System.IO;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "SOTF Item Unlocker";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
____ ____ _  _ . ____    ____ ____    ___ _  _ ____    ____ ____ ____ ____ ____ ____ ___ 
[__  |  | |\ | ' [__     |  | |___     |  |__| |___    |___ |  | |__/ |__/ |___ [__   |  
___] |__| | \|   ___]    |__| |        |  |  | |___    |    |__| |  \ |  \ |___ ___]  |  
                                                                                         
_ ___ ____ _  _    _  _ _  _ _    ____ ____ _  _ ____ ____                               
|  |  |___ |\/|    |  | |\ | |    |  | |    |_/  |___ |__/                               
|  |  |___ |  |    |__| | \| |___ |__| |___ | \_ |___ |  \   made by Cracky0001
                                                                                         
");
        

        var username = Environment.UserName;
        Console.WriteLine("Gib den Pfad zum Speicherordner ein:");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Beispiel: C:\\Users\\" + username + "\\AppData\\LocalLow\\SonsOfTheForest\\Saves\\YourSteamUserID\\1234567890");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Hinweis: Du kannst den Ordner auch einfach per Drag & Drop in die Konsole ziehen.");
        string path = System.Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\LocalLow\Endnight\SonsOfTheForest\Saves");
        Process.Start("explorer.exe", path);
        var savesPath = Console.ReadLine();

        var saveFiles = Directory.GetFiles(savesPath, "PlayerInventorySaveData.json", SearchOption.AllDirectories);
        if (saveFiles.Length == 0)
        {
            Console.WriteLine("Keine PlayerInventorySaveData.json-Dateien gefunden.");
            return;
        }

        var url = "https://raw.githubusercontent.com/Cracky0001/SOTF_ItemUnlockAll/main/Content/PlayerInventorySaveData.json";
        var webClient = new WebClient();
        var data = webClient.DownloadString(url);

        foreach (var saveFile in saveFiles)
        {
            File.WriteAllText(saveFile, data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bravo! Dein Inventar erfolgreich wurde überschrieben!");
            Console.ReadKey();
        }
    }
}
