using dRofusCompare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRofusCompare.Assets
{
    public static class Comparer
    {
        public static List<DataComparison> TotalsList(List<DrawingData> DrawingDataList, List<dRofusData> dRofusDataList)
        {
            var DataComparisonList = new List<DataComparison>();

            foreach (var dRofusRoom in dRofusDataList)
            {
                var DrawingRoom = DrawingDataList.FindAll(x => x.Room == dRofusRoom.Room);

                var PowerValue = 0;
                var TeleValue = 0;

                foreach (var DrawingItem in DrawingRoom)
                {
                    switch (DrawingItem.UserCode)
                    {
                        case ("102T"):
                            PowerValue = 2;
                            break;
                        case ("103T"):
                            PowerValue = 3;
                            break;
                        case ("000003T"):
                            TeleValue = 2;
                            break;
                    }


                }

                DataComparisonList.Add(new DataComparison
                {
                    Room = dRofusRoom.Room,
                    dRofusPower = dRofusRoom.Power,
                    dRofusTele = dRofusRoom.Tele,
                    DrawingPower = PowerValue,
                    DrawingTele = TeleValue,
                    DifferencePower = dRofusRoom.Power - PowerValue,
                    DifferenceTele = dRofusRoom.Tele - TeleValue
                });
                
            }

            return DataComparisonList;
        }

        public static List<DataComparison> RemoveOkRooms(List<DataComparison> TotalRoomList)
        {
            return TotalRoomList.FindAll(x => x.DifferencePower > 0 || x.DifferenceTele > 0);
        }
    }
}
