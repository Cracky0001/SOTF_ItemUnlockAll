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

        WebClient webClient = new();
        string data = webClient.DownloadString("https://raw.githubusercontent.com/Cracky0001/SOTF_ItemUnlockAll/main/Content/PlayerInventorySaveData.json"); // vll hier custom files supporten statt deine forcen zu downloaden

        string path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\LocalLow\Endnight\SonsOfTheForest\Saves");
        string[] directories = Directory.GetDirectories(path);

        Console.WriteLine("Wie lautet deine SaveGame ID? Du findest sie unter C:\\Users\\(Dein Name)\\AppData\\LocalLow\\Endnight\\SonsOfTheForest\\Saves\\(Deine ID)\\(Dein Speicherstand)");
        string SaveGameId = Console.ReadLine();

        int overrides = 0;
        foreach (string dir in directories) 
        {
            string fullPath = Path.Combine(dir, path);
            string[] saveFiles = Directory.GetFiles(fullPath, "PlayerInventorySaveData.json", SearchOption.AllDirectories);
            if (saveFiles == null || saveFiles.Length == 0) continue;

            foreach (string saveFile in saveFiles)
            {
                File.WriteAllText(saveFile, data);
                overrides++;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Bravo! Es wurden {overrides} Savefiles überschrieben!");
        Console.ReadLine();
    }
}
