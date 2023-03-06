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
        
        string path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\LocalLow\Endnight\SonsOfTheForest\Saves");
        string[] saveFiles = Directory.GetFiles(path, "PlayerInventorySaveData.json", SearchOption.AllDirectories);
        if (saveFiles.Length == 0)
        {
            Console.WriteLine("Keine PlayerInventorySaveData.json-Dateien gefunden.");
            return;
        }

        WebClient webClient = new();
        string data = webClient.DownloadString("https://raw.githubusercontent.com/Cracky0001/SOTF_ItemUnlockAll/main/Content/PlayerInventorySaveData.json"); // vll hier custom files supporten statt deine forcen zu downloaden

        foreach (string saveFile in saveFiles)
        {
            File.WriteAllText(saveFile, data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bravo! Dein Inventar erfolgreich wurde überschrieben!");
            Console.ReadKey();
        }
    }
}
