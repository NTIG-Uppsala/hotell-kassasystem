//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using Microsoft.Data.Sqlite;
//using System.Drawing.Imaging;

//namespace kassasystem
//{
//    internal class Database
//    {
//        public Database()
//        {
//            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
//            string path = String.Format(@"C:\Users\{0}\Documents\hotel-database\", userName);
//            string filePath = String.Format(@"C:\Users\{0}\Documents\hotel-database\hotel.db3", userName);

//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//            }
                
//            var db = new SqliteConnection($"Data Source={filePath};");
//            db.Open();
//            db.Close();
//        }

//    }
//}
