using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
