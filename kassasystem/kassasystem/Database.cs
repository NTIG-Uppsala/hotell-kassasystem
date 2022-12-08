using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Drawing.Imaging;
using System.Data.Common;
using System.Data;

namespace kassasystem
{


    internal class Database
    {
        public Database()
        {

            string[] tables = {
                "CREATE TABLE \"bookings\" (\r\n\t\"bookingID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"paymentID\"\tINTEGER,\r\n\t\"dateFrom\"\tNUMERIC,\r\n\t\"dateTo\"\tNUMERIC,\r\n\t\"roomCount\"\tINTEGER,\r\n\t\"isBreakfastIncluded\"\tNUMERIC,\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tPRIMARY KEY(\"bookingID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"paymentID\") REFERENCES \"payment\"(\"paymentID\")\r\n);",
                "CREATE TABLE \"externalCosts\" (\r\n\t\"externalCostsID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"paymentID\"\tINTEGER,\r\n\t\"externalCost\"\tTEXT,\r\n\t\"costDescription\"\tTEXT,\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tPRIMARY KEY(\"externalCostsID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"guestContact\" (\r\n\t\"guestContactID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"mail\"\tTEXT,\r\n\t\"phoneNumber\"\tINTEGER,\r\n\tFOREIGN KEY(\"guestContactID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tPRIMARY KEY(\"guestContactID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"guests\" (\r\n\t\"guestID\"\tINTEGER NOT NULL,\r\n\t\"firstName\"\tTEXT,\r\n\t\"lastName\"\tTEXT,\r\n\tPRIMARY KEY(\"guestID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"payment\" (\r\n\t\"paymentID\"\tINTEGER NOT NULL,\r\n\t\"paymentTypeID\"\tINTEGER,\r\n\t\"date\"\tINTEGER,\r\n\t\"amount\"\tNUMERIC,\r\n\t\"isPaid\"\tNUMERIC,\r\n\tPRIMARY KEY(\"paymentID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"paymentTypeID\") REFERENCES \"paymentType\"(\"paymentTypeID\")\r\n);",
                "CREATE TABLE \"paymentType\" (\r\n\t\"paymentTypeID\"\tINTEGER NOT NULL,\r\n\t\"type\"\tNUMERIC,\r\n\tPRIMARY KEY(\"paymentTypeID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"roomTypes\" (\r\n\t\"roomTypesID\"\tINTEGER NOT NULL,\r\n\t\"type\"\tTEXT,\r\n\tPRIMARY KEY(\"roomTypesID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"rooms\" (\r\n\t\"roomID\"\tINTEGER NOT NULL,\r\n\t\"roomTypesID\"\tINTEGER,\r\n\t\"floor\"\tINTEGER,\r\n\t\"roomNumber\"\tINTEGER,\r\n\t\"rate\"\tNUMERIC,\r\n\tFOREIGN KEY(\"roomTypesID\") REFERENCES \"rooms\"(\"roomTypesID\"),\r\n\tPRIMARY KEY(\"roomID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"roomsBooked\" (\r\n\t\"roomsBookedID\"\tINTEGER NOT NULL,\r\n\t\"bookingID\"\tINTEGER,\r\n\t\"roomID\"\tINTEGER,\r\n\tFOREIGN KEY(\"roomID\") REFERENCES \"rooms\"(\"roomID\"),\r\n\tFOREIGN KEY(\"bookingID\") REFERENCES \"bookings\"(\"bookingID\"),\r\n\tPRIMARY KEY(\"roomsBookedID\" AUTOINCREMENT)\r\n);"
            };

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            string path = String.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
            string filePath = String.Format(@"C:\Users\{0}\Documents\hotel_database\database.db", userName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(filePath))
            {
                var db = new SqliteConnection($"Data Source={filePath};");
                db.Open();
                using (DbCommand cmd = db.CreateCommand())
                {   
                    foreach (string query in tables)
                    {
                        cmd.CommandText += query;
                    }
                    cmd.ExecuteReader();
                }

                db.Close();
            }

        }

    }
}
