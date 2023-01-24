using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
            //Build the skeleton for Masterstructure
            for (int i = 0; i <= 14; i++)
            {
                Dictionary<string, CBefMasterStrukture> aBefMasterStructureDic = new Dictionary<string, CBefMasterStrukture>(); //index Ruta_250,tile_id,age

                MasterDicList.Add(aBefMasterStructureDic);
            }
            foreach (var befItem in befRowDic)
            {
                if (befItem.Value.Totalt_2000 != 0)
                {
                    if (inExisting(befItem.Value, MasterDicList[0]))
                    {
                        string compositeID = getCompositeID(befItem.Value.RutID, befItem.Value.Kommun, befItem.Value.Alder);
                        if (befItem.Value.Kon == 1) //Male
                        {
                            MasterDicList[0][compositeID].male = MasterDicList[0][compositeID].male + befItem.Value.Totalt_2000;
                        }
                        else if (befItem.Value.Kon == 2) //Female
                        {
                            MasterDicList[0][compositeID].female = MasterDicList[0][compositeID].female + befItem.Value.Totalt_2000;
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
                        aBefMaster.composite_id = getCompositeID(befItem.Value.RutID, befItem.Value.Kommun, befItem.Value.Alder);
                        aBefMaster.ruta_250 = befItem.Value.RutID;
                        aBefMaster.kn = befItem.Value.Kommun;
                        aBefMaster.ln = befItem.Value.Lan;
                        aBefMaster.X = returnXKoord(befItem.Value.RutID.ToString());
                        aBefMaster.Y = returnYKoord(befItem.Value.RutID.ToString());
                        aBefMaster.WKT_tile = returnWKT(aBefMaster.Y, aBefMaster.X);
                        if (befItem.Value.Kon == 1) //Male
                        {
                            aBefMaster.male = befItem.Value.Totalt_2000;
                        }
                        else if (befItem.Value.Kon == 2) //Female
                        {
                            aBefMaster.female = befItem.Value.Totalt_2000;
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Error in creating a Befmasterstructure"));
                            Console.Read();
                        }
                        MasterDicList[0].Add(aBefMaster.composite_id, aBefMaster);
                    }
                }
                if (befItem.Value.Totalt_2001 != 1)
                {

                }
                if (befItem.Value.Totalt_2002 != 0)
                {

                }
                if (befItem.Value.Totalt_2003 != 0)
                {

                }
                if (befItem.Value.Totalt_2004 != 0)
                {

                }
                if (befItem.Value.Totalt_2005 != 0)
                {

                }
                if (befItem.Value.Totalt_2006 != 0)
                {

                }
                if (befItem.Value.Totalt_2007 != 0)
                {

                }
                if (befItem.Value.Totalt_2008 != 0)
                {

                }
                if (befItem.Value.Totalt_2009 != 0)
                {

                }
                if (befItem.Value.Totalt_2010 != 0)
                {

                }
                if (befItem.Value.Totalt_2011 != 0)
                {

                }
                if (befItem.Value.Totalt_2012 != 0)
                {

                }
                if (befItem.Value.Totalt_2013 != 0)
                {

                }
                if (befItem.Value.Totalt_2014 != 0)
                {

                }
            }

        }
        //Build new 
        public static string getCompositeID (long ruta_id,int kn, int age)
        {
            return ruta_id.ToString() + "_" + kn.ToString() + "_" + age.ToString();
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
            for (int i = 0; i < 14; i++)
            {
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    int year = 2000+i;
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
                    Console.WriteLine("Executing finally block.");
                }
            }
        }
    }
}
