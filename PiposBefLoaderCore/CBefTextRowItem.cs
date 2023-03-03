using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PiposBefLoaderCore
{
    public class CBefTextRowItem
    {
        public long RowID { get; set; }
        public long RutID { get; set; }
        public int Kommun { get; set; }
        public int Lan { get; set; }
        public int Alder { get; set; }   
        public int Kon { get; set; }
        public int Totalt_2000 { get; set; }
        public int Totalt_2001 { get; set; }
        public int Totalt_2002 { get; set; }
        public int Totalt_2003 { get; set; }
        public int Totalt_2004 { get; set; }
        public int Totalt_2005 { get; set; }
        public int Totalt_2006 { get; set; }
        public int Totalt_2007 { get; set; }
        public int Totalt_2008 { get; set; }
        public int Totalt_2009 { get; set; }
        public int Totalt_2010 { get; set; }
        public int Totalt_2011 { get; set; }
        public int Totalt_2012 { get; set; }
        public int Totalt_2013 { get; set; }
        public int Totalt_2014 { get; set; }
        //
        public int Totalt_2015 { get; set; }
        public int Totalt_2016 { get; set; }
        public int Totalt_2017 { get; set; }
        public int Totalt_2018 { get; set; }
        public int Totalt_2019 { get; set; }
        public int Totalt_2020 { get; set; }
        public int Totalt_2021 { get; set; }
        //
        public int Totalt_2022 { get; set; }

        public static void read5RowsWrite5Rows(string inDataFileFullPath,string outDataFileFullPath)
        {
            // The infile is large and hard to handle in editors. 
            // Use this function to get a grip of format of the textfile
            if (File.Exists(outDataFileFullPath))
            {
                File.Delete(outDataFileFullPath);
            }
            FileStream inFileBefStream = new FileStream(inDataFileFullPath, FileMode.Open);
            FileStream outFileBefStream = new FileStream(outDataFileFullPath, FileMode.Create);
            StreamReader inFileReader = new StreamReader(inFileBefStream, System.Text.Encoding.Default);
            StreamWriter outFileWriter = new StreamWriter(outFileBefStream, System.Text.Encoding.Default);
            String ATextFileRow = "";
            for (int i = 0; i < 5; i++)
            {
                    ATextFileRow = inFileReader.ReadLine();
                    outFileWriter.WriteLine(ATextFileRow);
            }
            outFileWriter.Flush();
            outFileWriter.Close();

        }
        public static void readBefFile2000_2014(string inDataFileFullPath, ref Dictionary<long, CBefTextRowItem> befRowDic)
        {
            // Load into dictionary
            //

            FileStream inFileBefStream = new FileStream(inDataFileFullPath, FileMode.Open);

            StreamReader inFileReader = new StreamReader(inFileBefStream, System.Text.Encoding.Default);
            String ATextFileRow = "";
            long rowId = befRowDic.Count;
            string header = inFileReader.ReadLine();
            while (!inFileReader.EndOfStream)
            //for (int i = 0; i < 50000; i++)
            {
                CBefTextRowItem aBefTextRowItem = new CBefTextRowItem();
                ATextFileRow = inFileReader.ReadLine();
                string[] split = null;
                string delimStr = ";";
                char[] delimiter = delimStr.ToCharArray();
                split = ATextFileRow.Split(delimiter);
                //Fill object
                aBefTextRowItem.RowID = rowId;
                aBefTextRowItem.RutID = Convert.ToInt64(split[0]);
                aBefTextRowItem.Lan = Convert.ToInt32(split[2]);
                aBefTextRowItem.Kommun = Convert.ToInt32(split[3]);
                aBefTextRowItem.Alder = Convert.ToInt32(split[4]);
                aBefTextRowItem.Kon = Convert.ToInt32(split[5]); //Kön (1 = M, 2 = Kv)
                aBefTextRowItem.Totalt_2000 = Convert.ToInt32(split[6]);
                aBefTextRowItem.Totalt_2001 = Convert.ToInt32(split[7]);
                aBefTextRowItem.Totalt_2002 = Convert.ToInt32(split[8]);
                aBefTextRowItem.Totalt_2003 = Convert.ToInt32(split[9]);
                aBefTextRowItem.Totalt_2004 = Convert.ToInt32(split[10]);
                aBefTextRowItem.Totalt_2005 = Convert.ToInt32(split[11]);
                aBefTextRowItem.Totalt_2006 = Convert.ToInt32(split[12]);
                aBefTextRowItem.Totalt_2007 = Convert.ToInt32(split[13]);
                aBefTextRowItem.Totalt_2008 = Convert.ToInt32(split[14]);
                aBefTextRowItem.Totalt_2009 = Convert.ToInt32(split[15]);
                aBefTextRowItem.Totalt_2010 = Convert.ToInt32(split[16]);
                aBefTextRowItem.Totalt_2011 = Convert.ToInt32(split[17]);
                aBefTextRowItem.Totalt_2012 = Convert.ToInt32(split[18]);
                aBefTextRowItem.Totalt_2013 = Convert.ToInt32(split[19]);
                aBefTextRowItem.Totalt_2014 = Convert.ToInt32(split[20]);
                befRowDic.Add(rowId, aBefTextRowItem);
                if (rowId != 0 && rowId % 10000 == 0)
                {
                    Console.WriteLine(rowId + " of total 28571546");
                }
                rowId++;
            }
        }
        /*public static void AddNewMifBefFile(string popFileMif, List<CBefTile> aBeftileList, BackgroundWorker aBackgroundWorker)
        {
            FileStream inFileMif = new FileStream(popFileMif, FileMode.Open);
            StreamReader sRInFileMif = new StreamReader(inFileMif, System.Text.Encoding.Default);
            String ARowMIF = sRInFileMif.ReadLine();

            string popFileMid = popFileMif.TrimEnd('F') + 'D';
            FileStream inFileMid = new FileStream(popFileMid, FileMode.Open);
            StreamReader sRInFileMid = new StreamReader(inFileMid, System.Text.Encoding.Default);
            String ARowMID = sRInFileMid.ReadLine();
            int loadCount = 0;

            while (ARowMIF != null) // lägg till rutor med centrumkoordinaten
            {
                if (ARowMIF.Contains("Center"))
                {
                    GetTileFromBefTileMifFile(ARowMIF, ARowMID, ref aBeftileList, ref sRInFileMif, ref loadCount);
                    ARowMID = sRInFileMid.ReadLine();
                }
                else
                if (ARowMIF.Contains("Point"))
                {
                    // Trots det är punkter skapar man en tile
                    GetTileFromBefPointFile(ARowMIF, ARowMID, ref aBeftileList, ref sRInFileMif, ref loadCount);
                    ARowMID = sRInFileMid.ReadLine();
                }
                // Use this when the MID-file does not include "Center"-clause
                //               if (ARowMIF.Contains("Region"))
                //               {
                //                   GetTileFromBefRegionMifFile(ARowMIF, ARowMID, ref aBeftileList, ref sRInFileMif, ref loadCount);
                //                   ARowMID = sRInFileMid.ReadLine();
                //               }
                ARowMIF = sRInFileMif.ReadLine();
            }
            //metaTextbox.AppendText(" \n " + loadCount + " rutor inlästa från MID/MIF-filen \n"); metaTextbox.Update();
            aBackgroundWorker.ReportProgress(0, " \n " + loadCount + " rutor inlästa från MID/MIF-filen \n");
            inFileMif.Close();
            inFileMid.Close();
        }
        public static void GetTileFromBefTileMifFile(string ARowMIF, string ARowMID, ref List<CBefTile> aBeftileList, ref StreamReader sRInFileMif, ref int loadCount)
        {
            if (ARowMIF.Contains("Center"))
            {
                CBefTile aBeftile = new CBefTile();
                Int32 startPositionX_coord = ARowMIF.IndexOf("Center") + 7;
                Int32 endPositionX_coord = ARowMIF.IndexOf(" ", startPositionX_coord + 3);
                Int32 startPositionY_coord = endPositionX_coord + 1;
                Int32 endPositionY_coord = ARowMIF.Length;
                try
                {
                    //Fyll på attributdata
                    if (ARowMID != null)
                    {
                        aBeftile = aBeftile.fillAttributeDataBeftile(ARowMID);
                    }
                    else
                    {
                        MessageBox.Show("The mid file line is emty!");
                    }
                    string strX_coord = ARowMIF.Substring(startPositionX_coord, endPositionX_coord - startPositionX_coord);
                    string strY_coord = ARowMIF.Substring(startPositionY_coord, endPositionY_coord - startPositionY_coord);
                    aBeftile.X = (Int32)Math.Round(Convert.ToDecimal(strX_coord, CultureInfo.InvariantCulture));
                    aBeftile.Y = (Int32)Math.Round(Convert.ToDecimal(strY_coord, CultureInfo.InvariantCulture));
                    aBeftile.tile_250_Knkod = Convert.ToString(aBeftile.X - 125) + Convert.ToString(aBeftile.Y - 125) + aBeftile.Kn;
                    aBeftile.tile_250 = Convert.ToInt64(Convert.ToString(aBeftile.X - 125) + Convert.ToString(aBeftile.Y - 125));
                    if (aBeftile != null)
                    {
                        loadCount++;
                        aBeftile.ID = loadCount;
                        aBeftileList.Add(aBeftile);
                    }
                }
                catch
                {
                    MessageBox.Show("Please check the format of the mid/mif file.");
                }

            }

        }*/

        public static void readBefFile2022(string inDataFileFullPathPlaced, string inDataFileFullPathUnPlaced, ref Dictionary<long, CBefTextRowItem> befRowDic)
        {
            // Load placed population dictionary
            //

            FileStream inFileBefStream = new FileStream(inDataFileFullPathPlaced, FileMode.Open);

            StreamReader inFileReader = new StreamReader(inFileBefStream, System.Text.Encoding.Default);
            String ATextFileRow = "";
            long rowId = befRowDic.Count;
            while (!inFileReader.EndOfStream)
            //for (int i = 0; i < 50000; i++)
            {
                // Kolla om det finns både män och kvinnor?
                
                ATextFileRow = inFileReader.ReadLine();
                string[] split = null;
                string delimStr = ",";
                char[] delimiter = delimStr.ToCharArray();
                split = ATextFileRow.Split(delimiter);
                if (Convert.ToInt32(split[5]) > 0) //Finns det män?
                {
                    //Fill object
                    CBefTextRowItem aBefTextRowItem = new CBefTextRowItem();
                    aBefTextRowItem.RowID = rowId;
                    aBefTextRowItem.RutID = Convert.ToInt64(split[1]);
                    aBefTextRowItem.Lan = Convert.ToInt32(split[2]);
                    aBefTextRowItem.Kommun = Convert.ToInt32(split[3]);
                    aBefTextRowItem.Alder = Convert.ToInt32(split[4]);
                    aBefTextRowItem.Kon = 1; //Kön (1 = M, 2 = Kv)
                    aBefTextRowItem.Totalt_2022 = Convert.ToInt32(split[5]);//Antal män
                    befRowDic.Add(rowId, aBefTextRowItem);
                    rowId++;
                }
                if (Convert.ToInt32(split[6]) > 0) //Finns det kvinnor?
                {
                    //Fill object
                    CBefTextRowItem aBefTextRowItem = new CBefTextRowItem();
                    aBefTextRowItem.RowID = rowId;
                    aBefTextRowItem.RutID = Convert.ToInt64(split[1]);
                    aBefTextRowItem.Lan = Convert.ToInt32(split[2]);
                    aBefTextRowItem.Kommun = Convert.ToInt32(split[3]);
                    aBefTextRowItem.Alder = Convert.ToInt32(split[4]);
                    aBefTextRowItem.Kon = 2; //Kön (1 = M, 2 = Kv)
                    aBefTextRowItem.Totalt_2022 = Convert.ToInt32(split[6]);//Antal kvinnor
                    befRowDic.Add(rowId, aBefTextRowItem);
                    rowId++;
                }
                if (rowId != 0 && rowId % 10000 == 0)
                {
                    Console.WriteLine(rowId + " of total 4 811 865");
                }
            }
            // Load placed population dictionary
            //

            FileStream inFileUnplacedBefStream = new FileStream(inDataFileFullPathUnPlaced, FileMode.Open);

            StreamReader inFileUnplacedReader = new StreamReader(inFileUnplacedBefStream, System.Text.Encoding.Default);
           
            while (!inFileUnplacedReader.EndOfStream)
            //for (int i = 0; i < 50000; i++)
            {
                CBefTextRowItem aBefTextRowItem = new CBefTextRowItem();
                ATextFileRow = inFileUnplacedReader.ReadLine();
                string[] split = null;
                string delimStr = ",";
                char[] delimiter = delimStr.ToCharArray();
                split = ATextFileRow.Split(delimiter);
                //Fill object
                aBefTextRowItem.RowID = rowId;
                aBefTextRowItem.RutID = Convert.ToInt64(split[2]);
                aBefTextRowItem.Lan = Convert.ToInt32(split[3]);
                aBefTextRowItem.Kommun = Convert.ToInt32(split[4]);
                aBefTextRowItem.Alder = Convert.ToInt32(split[6]);
                aBefTextRowItem.Kon = Convert.ToInt32(split[5]); //Kön (1 = M, 2 = Kv)
                aBefTextRowItem.Totalt_2022 = Convert.ToInt32(split[7]);
                befRowDic.Add(rowId, aBefTextRowItem);
                if (rowId != 0 && rowId % 10000 == 0)
                {
                    Console.WriteLine(rowId + " of total xxxx");
                }
                rowId++;
            }

        }

    }
}
