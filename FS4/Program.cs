using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FS4
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            
            foreach (DriveInfo d in di)
            {
                Console.WriteLine(d.Name);
                string t = d.Name.ToString().Substring(0, 1);
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(@"C:\Users\плотниковс\Desktop\" + t);
                    dir.Create();
                    FileInfo file = new FileInfo(dir.FullName);
                    Console.WriteLine(dir.FullName);
                    //FileStream fs = file.Create();
                    //fs.Close();

                    using (StreamWriter sw = new StreamWriter(@"C:\Users\плотниковс\Desktop\" + t+@"\123.txt"))
                    {
                        var txtText = "";
                        DriveInfo diSelected = new DriveInfo(t);
                        txtText = "Свободное пространство: " + diSelected.AvailableFreeSpace / 1024 / 1024 + "MB\n"
                            + "Общий размер: " + diSelected.TotalSize + "\n"
                            + "Формат устройства: " + diSelected.DriveFormat + "\n"
                            + "Тип устройства: " + diSelected.DriveType + "\n"
                            + "Готовность: " + diSelected.IsReady + "\n"
                            + "Имя: " + diSelected.Name + "\n"
                            + "Корневой каталог: " + diSelected.RootDirectory + "\n"
                            + "Метка тома: " + diSelected.VolumeLabel;

                        sw.Write(txtText);
                        //Console.WriteLine(txtText);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
               
                
            }

            
            
        }
    }
}
