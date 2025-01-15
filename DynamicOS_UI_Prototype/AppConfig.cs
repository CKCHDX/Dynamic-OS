using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Dynamic_Os
{
    public static class AppConfig
    {
        private static readonly string StorageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage");
        private static readonly string ConfigFilePath = Path.Combine(StorageDirectory, "config.json");

        public static void Initialize()
        {
            EnsureStorage();
        }

        public static void EnsureStorage()
        {
            if (!Directory.Exists(StorageDirectory))
            {
                Directory.CreateDirectory(StorageDirectory);
            }

            if (!File.Exists(ConfigFilePath))
            {
                // Create an empty config file (default to Splash screen mode)
                SaveMode("Splash");
            }
        }

        public static void SaveMode(string mode)
        {
            EnsureStorage();

            var config = new Dictionary<string, string>
            {
                { "Mode", mode }
            };

            File.WriteAllText(ConfigFilePath, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static string LoadMode()
        {
            EnsureStorage();

            try
            {
                string json = File.ReadAllText(ConfigFilePath);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return "Splash"; // Default to Splash if the file is empty
                }

                var config = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                return config != null && config.ContainsKey("Mode") ? config["Mode"] : "Splash";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading mode: {ex.Message}");
                return "Splash"; // Default to Splash in case of an error
            }
        }
    }
}
