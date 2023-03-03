using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PiposBefLoaderCore
{
    public class CBefMasterStrukture
    {
        //public int id { get; set; }
        public string composite_id { get; set; }
        public long ruta_250 { get; set; }
        public int kn { get; set; }
        public int ln { get; set; }
        public int age { get; set; }
        public int male { get; set; }
        public int female { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public string WKT_tile { get; set; }

        public static void fillMasterDic(Dictionary<long, CBefTextRowItem> befRowDic, ref List<Dictionary<string, CBefMasterStrukture>> MasterDicList)
        {

            Int64 rowId = 0;
            foreach (var befItem in befRowDic)
            {
                if (rowId != 0 && rowId % 10000 == 0)
                {
                    Console.WriteLine(rowId + " of total 28571546");
                }
                rowId++;

                if (befItem.Value.Totalt_2000 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2000;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 0);
                }
                if (befItem.Value.Totalt_2001 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2001;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 1);
                }
                if (befItem.Value.Totalt_2002 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2002;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 2);
                }
                if (befItem.Value.Totalt_2003 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2003;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 3);
                }
                if (befItem.Value.Totalt_2004 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2004;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 4);
                }
                if (befItem.Value.Totalt_2005 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2005;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 5);
                }
                if (befItem.Value.Totalt_2006 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2006;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 6);
                }
                if (befItem.Value.Totalt_2007 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2007;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 7);
                }
                if (befItem.Value.Totalt_2008 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2008;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 8);
                }
                if (befItem.Value.Totalt_2009 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2009;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 9);
                }
                if (befItem.Value.Totalt_2010 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2010;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 10);
                }
                if (befItem.Value.Totalt_2011 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2011;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 11);
                }
                if (befItem.Value.Totalt_2012 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2012;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 12);
                }
                if (befItem.Value.Totalt_2013 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2013;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 13);
                }
                if (befItem.Value.Totalt_2014 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2014;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 14);
                }
                //
                if (befItem.Value.Totalt_2015 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2015;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 15);
                }
                if (befItem.Value.Totalt_2016 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2016;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 16);
                }
                if (befItem.Value.Totalt_2017 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2017;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 17);
                }
                if (befItem.Value.Totalt_2018 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2018;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 18);
                }
                if (befItem.Value.Totalt_2019 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2019;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 19);
                }
                if (befItem.Value.Totalt_2020 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2020;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 20);
                }
                if (befItem.Value.Totalt_2021 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2021;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 21);
                }
                if (befItem.Value.Totalt_2022 != 0)
                {
                    int AntalPersoner = befItem.Value.Totalt_2022;
                    CBefMasterStrukture.updateBefStructure(ref MasterDicList, befItem.Value, AntalPersoner, 22);
                }
            }
        }
        //Build new 
        public static string getCompositeID (long ruta_id,int kn, int age)
        {
            return ruta_id.ToString() + "_" + kn.ToString() + "_" + age.ToString();
        }

       
        private static long returnXKoord(string aXstring)
        {
            Int64 X_koord = Convert.ToInt64(aXstring.Substring(6, 7));

            return X_koord;
        }

        private static long returnYKoord(string aYstring)
        {
            Int64 Y_koord = Convert.ToInt64(aYstring.Substring(0, 6));

            return Y_koord;
        }

        private static String returnWKT(Int64 x, Int64 y)
        {
            //POLYGON((x1 y1, x2 y2, x3 y3, ...)
            String WKT = "Polygon((" + x + " " + y + ", " + (x + 250) + " " + y + ", " + (x + 250) + " " + (y + 250) + ", " + x + " " + (y + 250) + ", " + x + " " + y + "))";

            return WKT;
        }
        public static void printToFile(string filenameWithPath, List<Dictionary<string, CBefMasterStrukture>> MasterDicList)
        {
            int year = 0;
            for (int i = 0; i < 23; i++)
            {
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    year = 2000+i;
                    StreamWriter sw = new StreamWriter(filenameWithPath+year.ToString());
                    sw.WriteLine("CompositeID;RutaID;Kn;Ln;Age;Male;Female;X_sweref99;Y_sweref99;WKT_object");
                    foreach (CBefMasterStrukture obj in MasterDicList[i].Values)
                    {
                        string printLine =
                            obj.composite_id + ";" +
                            obj.ruta_250.ToString() + ";" +
                            obj.kn.ToString() + ";" +
                            obj.ln.ToString() + ";" +
                            obj.age.ToString() + ";" +
                            obj.male.ToString() + ";" +
                            obj.female.ToString() + ";" +
                            obj.X.ToString() + ";" +
                            obj.Y.ToString() + ";" +
                            obj.WKT_tile.ToString();
                        sw.WriteLine(printLine);
                    }
                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Written yearfile: " + year.ToString());
                }
            }
        }
        public static void updateBefStructure(ref List<Dictionary<string, CBefMasterStrukture>> aMasterDicList, CBefTextRowItem aBefTextItem, int AntalPersoner, int year )
        {
            if (inExisting(aBefTextItem, aMasterDicList[year]))
            {
                string compositeID = getCompositeID(aBefTextItem.RutID, aBefTextItem.Kommun, aBefTextItem.Alder);
                if (aBefTextItem.Kon == 1) //Male
                {
                    aMasterDicList[year][compositeID].male = aMasterDicList[year][compositeID].male + AntalPersoner;
                }
                else if (aBefTextItem.Kon == 2) //Female
                {
                    aMasterDicList[year][compositeID].female = aMasterDicList[year][compositeID].female + AntalPersoner;
                }
                else
                {
                    Console.WriteLine(string.Format("Error in creating a Befmasterstructure"));
                    Console.Read();
                }
            }
            else
            {
                CBefMasterStrukture aBefMaster = new CBefMasterStrukture();
                aBefMaster.composite_id = getCompositeID(aBefTextItem.RutID, aBefTextItem.Kommun, aBefTextItem.Alder);
                aBefMaster.ruta_250 = aBefTextItem.RutID;
                aBefMaster.kn = aBefTextItem.Kommun;
                aBefMaster.ln = aBefTextItem.Lan;
                aBefMaster.age = aBefTextItem.Alder;
                aBefMaster.X = returnXKoord(aBefTextItem.RutID.ToString());
                aBefMaster.Y = returnYKoord(aBefTextItem.RutID.ToString());
                aBefMaster.WKT_tile = returnWKT(aBefMaster.Y, aBefMaster.X);
                if (aBefTextItem.Kon == 1) //Male
                {
                    aBefMaster.male = AntalPersoner;
                }
                else if (aBefTextItem.Kon == 2) //Female
                {
                    aBefMaster.female = AntalPersoner;
                }
                else
                {
                    Console.WriteLine(string.Format("Error in creating a Befmasterstructure"));
                    Console.Read();
                }
                aMasterDicList[year].Add(aBefMaster.composite_id, aBefMaster);
            }
        }
        private static bool inExisting(CBefTextRowItem aBefTextRowItem, Dictionary<string, CBefMasterStrukture> aBefMasterDic)
        {
            string compositeID = getCompositeID(aBefTextRowItem.RutID, aBefTextRowItem.Kommun, aBefTextRowItem.Alder);
            if (aBefMasterDic.ContainsKey(compositeID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void createDatabasestucture()
        {

        }
    }

}
