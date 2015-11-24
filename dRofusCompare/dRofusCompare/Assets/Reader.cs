using dRofusCompare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRofusCompare.Assets
{
    public static class Reader
    {
        public static List<DrawingData> DrawingReader(string path)
        {
            var DrawingDataList = new List<DrawingData>();
            var fileContent = ReadData(path);

            for (int i = 2; i < fileContent.Count - 1; i++)
            {
                var lineArray = fileContent[i].Split('\t');
                DrawingDataList.Add(new DrawingData
                {
                    TFM = lineArray[0],
                    UserCode = lineArray[1],
                    Room = lineArray[2],
                    Count = Convert.ToInt32(lineArray[3])
                });
            }


            return DrawingDataList;
        }

        public static List<dRofusData> dRofusReader(string path)
        {
            var dRofusDataList = new List<dRofusData>();
            var fileContent = ReadData(path);

            for (int i = 0; i < fileContent.Count - 1; i++)
            {
                var lineArray = fileContent[i].Split('\t');

                for (int j = 0; j < lineArray.Length - 1; j++)
                {
                    if (lineArray[j] == "")
                    {
                        lineArray[j] = "0";
                    }
                }

                dRofusDataList.Add(new dRofusData
                {
                    Room = lineArray[0],
                    UPRI = Convert.ToInt32(lineArray[1]),
                    PRI = Convert.ToInt32(lineArray[2]),
                    UPS = Convert.ToInt32(lineArray[3]),
                    Data = Convert.ToInt32(lineArray[4])
                });
            }


            return dRofusDataList;
        }


        private static List<string> ReadData(string path)
        {
            var reader = new StreamReader(path);
            string line;
            List<string> lineList = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                lineList.Add(line);
            }

            return lineList;
        }
    }
}
