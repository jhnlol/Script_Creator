using System;
using System.IO;

class Program
{
    static void CreateFoldersAndFiles(string folderName, string location, string author)
    {
        string folderPath = Path.Combine(location, folderName);
        Directory.CreateDirectory(folderPath);
        string clientFolder = Path.Combine(folderPath, "client");
        Directory.CreateDirectory(clientFolder);
        File.WriteAllText(Path.Combine(clientFolder, "client.lua"), "ESX = exports.es_extended.getSharedObject()");
        string serverFolder = Path.Combine(folderPath, "server");
        Directory.CreateDirectory(serverFolder);
        File.WriteAllText(Path.Combine(serverFolder, "server.lua"), "ESX = exports.es_extended.getSharedObject()");
        File.WriteAllText(Path.Combine(folderPath, "config.lua"), "Config = {}");
        File.WriteAllText(Path.Combine(folderPath, "fxmanifest.lua"), $@"fx_version 'cerulean'
game 'gta5'
author '{author}'
shared_script 'config.lua'
client_script 'client/client.lua'
server_script 'server/server.lua'
        ");
    }

    static void Main()
    {
        Console.Write("Podaj nazwę folderu: ");
        string folderName = Console.ReadLine();

        Console.Write("Podaj lokalizację, w której chcesz utworzyć folder i pliki: ");
        string location = Console.ReadLine();
        Console.Write("Podaj nautora skryptu: ");
        string author = Console.ReadLine();
        CreateFoldersAndFiles(folderName, location, author);

        Console.WriteLine("Struktura folderu i plików została utworzona.");
    }
}
