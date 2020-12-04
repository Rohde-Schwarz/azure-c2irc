using DeviceGatewayService.Utils;
using System.IO;
using System.Text.Json;

namespace DeviceGatewayService.Models
{
    /// <summary>
    /// A static factory for the gateway settings.
    /// </summary>
    public static class SettingsFactory
    {
        private static string StorageFolder
        {
            get
            {
                var directory = Constants.ApplicationDataPath;
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                return directory;
            }
        }

        private static string SettingsFile =>
            Path.Combine(StorageFolder, "appsettings.json");

        /// <summary>
        /// Creates new setting with default values.
        /// </summary>
        /// <returns>New settings.</returns>
        public static Settings NewFromDefault() => new Settings();

        /// <summary>
        /// Loads the settings.
        /// </summary>
        /// <returns>The current settings.</returns>
        public static Settings Load() => Load(SettingsFile);

        /// <summary>
        /// Loads the settings from a specific path.
        /// </summary>
        /// <param name="path">The path where the settings are stored.</param>
        /// <returns>The leaded settings.</returns>
        public static Settings Load(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    return JsonSerializer.Deserialize<Settings>(File.ReadAllText(path));
                }
                catch (JsonException)
                {
                    return NewFromDefault();
                }
            }
            else
            {
                return NewFromDefault();
            }
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="data">The current settings.</param>
        public static void Save(Settings data) => Save(data, SettingsFile);

        /// <summary>
        /// Saves the settings to a specific location.
        /// </summary>
        /// <param name="data">The settings to be stored.</param>
        /// <param name="path">The path where the settings should be stored.</param>
        public static void Save(Settings data, string path) =>
            File.WriteAllText(path, JsonSerializer.Serialize(data));
    }
}
