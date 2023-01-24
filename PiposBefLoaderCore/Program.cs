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
        List < Dictionary<string, CBefMasterStrukture> > MasterDicList = new List<Dictionary<string, CBefMasterStrukture>>();
        CBefMasterStrukture.fillMasterDic(aBefDic,ref MasterDicList);

        CBefMasterStrukture.printToFile("D:\\Source\\PiposDatabaseLoaderCore\\DATA\\Befolkning", MasterDicList);


        Console.WriteLine("Done!");
    }
}


/*Kontrollsiffror från SCB
 * Män	 
2000	4 392 753
2001	4 408 445
2002	4 427 107
2003	4 446 656
2004	4 466 311
2005	4 486 550
2006	4 523 523
2007	4 563 921
2008	4 603 710
2009	4 649 014
2010	4 690 244
2011	4 726 834
2012	4 765 905
2013	4 814 357
2014	4 872 240
2015	4 930 966
2016	5 013 347
2017	5 082 662
2018	5 142 438
2019	5 195 814
2020	5 222 847
2021	5 260 707
Kvinnor	 
2000	4 490 039
2001	4 500 683
2002	4 513 681
2003	4 529 014
2004	4 545 081
2005	4 561 202
2006	4 589 734
2007	4 619 006
2008	4 652 637
2009	4 691 668
2010	4 725 326
2011	4 756 021
2012	4 789 988
2013	4 830 507
2014	4 875 115
2015	4 920 051
2016	4 981 806
2017	5 037 580
2018	5 087 747
2019	5 131 775
2020	5 156 448
2021	5 191 619
 */