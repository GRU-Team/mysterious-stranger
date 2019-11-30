using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    internal class Config
    {
        static internal AppSettingsSection appSettings;
        static private string fileName = "config.xml";
        static internal void LoadConfigFile()
        {
            ExeConfigurationFileMap customConfigFileMap = new ExeConfigurationFileMap();
            customConfigFileMap.ExeConfigFilename = fileName;
            

            Configuration customConfig = ConfigurationManager.OpenMappedExeConfiguration(
                customConfigFileMap, ConfigurationUserLevel.None);

            appSettings = (customConfig.GetSection("appSettings") as AppSettingsSection);
        }

        static private bool IsConfigFileExists()
        {
            if(File.Exists(fileName))
            {
                return true;
            }

            throw new FileNotFoundException($"File {fileName} not found!");
        }
    }
}
