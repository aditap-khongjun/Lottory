using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Lottory
{
    public static class Database
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
    class BaseType
    {
        // Number 1 digit
        public const string up1 = "บน";             
        public const string low1 = "ล่าง";           
        public const string upfront1 = "หน้า";
        public const string upcenter1 = "กลาง";
        public const string upback1 = "หลัง";
        public const string lowfront1 = "หน้าล่าง";
        public const string lowback1 = "หลังล่าง";
        public const string uplow1 = "บน/ล่าง";

        // Number 2 digit
        public const string up2 = "บน";
        public const string low2 = "ล่าง";
        public const string tod2 = "โต๊ด";
        public const string uplow2 = "บน/ล่าง";
        public const string door62 = "6 ประตู";
        public const string ht2 = "ร้อยสิบ";
        public const string hu2 = "ร้อยหน่วย";
        public const string door19up2 = "19 ประตูบน";
        public const string door19low2 = "19 ประตูล่าง";
        public const string door19uplow2 = "19 ประตูบนล่าง";

        // Number 3 digit
        public const string up3 = "บน";
        public const string uptod3 = "บน/โต๊ด";
        public const string group3 = "ชุด";
        public const string tgroup3 = "ตรงชุด";
        public const string group53 = "ตรง5";
        public const string tod3 = "โต๊ด";
        public const string low3 = "ล่าง";
        public const string lowgroup3 = "ล่างชุด";
        public const string uplowtod3 = "บน/โต๊ด/ล่าง";
        public const string door543 = "54 ประตู";

        // Number 4 digit
        public const string group4 = "ชุด";

        // Number 5 digit
        public const string group5 = "ชุด";
        public const string tod5 = "โต๊ด";
    }
    class BaseTypeID
    {
        public const int up1 = 1;
        public const int low1 = 2;
        public const int upfront1 = 3;
        public const int upcenter1 = 4;
        public const int upback1 = 5;
        public const int lowfront1 = 6;
        public const int lowback1 = 7;
        public const int uplow1 = 8;

        // Number 2 digit
        public const int up2 = 9;
        public const int low2 = 10;
        public const int tod2 = 11;
        public const int uplow2 = 12;
        public const int door62 = 13;
        public const int ht2 = 14;
        public const int hu2 = 15;
        public const int door19up2 = 16;
        public const int door19low2 = 17;
        public const int door19uplow2 = 18;

        // Number 3 digit
        public const int up3 = 19;
        public const int uptod3 = 20;
        public const int group3 = 21;
        public const int tgroup3 = 22;
        public const int group53 = 23;
        public const int tod3 = 24;
        public const int low3 = 25;
        public const int lowgroup3 = 26;
        public const int uplowtod3 = 27;
        public const int door543 = 28;

        // Number 4 digit
        public const int group4 = 29;

        // Number 5 digit
        public const int group5 = 30;
        public const int tod5 = 31;
    }
    class WinNumberType
    {
        public const string up3 = "3 บน";
        public const string low3 = "3 ล่าง";
        public const string up2 = "2 บน";
        public const string low2 = "2 ล่าง";
        public const string hu2 = "2 ร้อยหน่วย";
        public const string ht2 = "2 ร้อยสิบ";
        public const string up1 = "1 บน";
        public const string low1 = "1 ล่าง";
        public const string upfront1 = "1 หน้า";
        public const string upcenter1 = "1 กลาง";
        public const string upback1 = "1 หลัง";
        public const string lowfront1 = "1 ล่างหน้า";
        public const string lowback1 = "1 ล่างหลัง";
    }

    class DBNumber
    {
        public const string up3 = "Number_3up";
        public const string low3 = "Number_3low";
        public const string up2 = "Number_2up";
        public const string low2 = "Number_2low";
        public const string up1 = "Number_1up";
        public const string low1 = "Number_1low";
    }
    class DBWinRate
    {
        public const string up3 = "winRate_3up";
        public const string low3 = "winRate_3low";
        public const string up2 = "winRate_2up";
        public const string low2 = "winRate_2low";
        public const string up1 = "winRate_1freeup";
        public const string low1 = "winRate_1freelow";
        public const string upfront1 = "winRate_1front";
        public const string upcenter1 = "winRate_1center";
        public const string upback1 = "winRate_1back";
    }

}
