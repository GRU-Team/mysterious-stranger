using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    public class SymbolMap
    {
        static public string FilledCell { get; set; }
        static public string EmptyCell { get; set; }
        static public string PlayerCell { get; set; }
        static public string UnknowCell { get; set; }

        static public void LoadSymbols()
        {
            FilledCell = Config.appSettings.Settings["FilledCell"].Value;
            EmptyCell = Config.appSettings.Settings["EmptyCell"].Value;
            PlayerCell = Config.appSettings.Settings["PlayerCell"].Value;
            UnknowCell = Config.appSettings.Settings["UnknowCell"].Value;
        }
    }
}
