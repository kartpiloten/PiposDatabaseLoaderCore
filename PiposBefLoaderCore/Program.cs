using PiposBefLoaderCore;
using System.Xml.Serialization;

namespace MyProject;
class Program
{
    static void Main(string[] args)
    {
        Dictionary<long, CBefTextRowItem> aBefDic = new Dictionary<long, CBefTextRowItem>();
        CBefTextRowItem.readBefFile2000_2014("Z:\\Projekt 2022\\SCB_2022\\LeveransSept28\\Statistik till plattformen Pipos 2022\\Lev2\\rev_Tab1_TotBefMGeo.txt",ref  aBefDic);
        //CBefTextRowItem.read5RowsWrite5Rows("Z:\\Projekt 2022\\SCB_2022\\LeveransSept28\\Statistik till plattformen Pipos 2022\\Lev2\\rev_Tab1_TotBefMGeo.txt", "Z:\\Projekt 2022\\SCB_2022\\tabortGeo.txt");
        CBefTextRowItem.readBefFile2000_2014("Z:\\Projekt 2022\\SCB_2022\\LeveransSept28\\Statistik till plattformen Pipos 2022\\Lev2\\rev_Tab2_TotBefUtanGeo.txt", ref aBefDic);
        //CBefTextRowItem.read5RowsWrite5Rows("Z:\\Projekt 2022\\SCB_2022\\LeveransSept28\\Statistik till plattformen Pipos 2022\\Lev2\\rev_Tab2_TotBefUtanGeo.txt", "Z:\\Projekt 2022\\SCB_2022\\tabortutanGeo.txt");

        Console.WriteLine("Done!");
    }
}


