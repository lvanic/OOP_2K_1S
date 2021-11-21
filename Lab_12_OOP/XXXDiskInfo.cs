﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public static class XXXDiskInfo
    {
        private static DriveInfo[] di;

        static XXXDiskInfo() => di = DriveInfo.GetDrives();
        

        public static string GetFreeSpace()
        {
            long space = 0;
            foreach (var d in di)
                space += d.AvailableFreeSpace;

            return "Free space\t" + space.ToString();
        }

        public static string GetFileSystem() => di[0].DriveFormat;
   
        public static string GetDiskInfo()
        {
            string res = "";
            foreach (var d in di)
            {
                res += "Disk Name " + d.Name + '\n';
                res += "Disk space " + d.TotalSize.ToString() + '\n';
                res += "Disk free space " + d.TotalFreeSpace.ToString() + '\n';
                res += "Volume label " + d.RootDirectory.ToString() + "\n\n";
            }
            return res;
        }
    }
}