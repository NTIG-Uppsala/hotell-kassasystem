using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace kassasystem
{


    internal class SToff
    {
        
        public SToff() 
        { 

        }
    }

    internal class Bookings
    {
        public int bookingId { get; set; }
        

        public Bookings() 
        { 
        }

    }

    internal class Database
    {
        public SQLiteConnection con { get; set; }

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
                var db = new SQLiteConnection($"Data Source={filePath};");
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

            this.con = new SQLiteConnection($"Data Source={filePath};");

        }

        public List<Dictionary<String, Object>> QueryExecuter(string query)
        {
            /* Returns a dict with result from db*/
            List<Dictionary<String, Object>> output = new List<Dictionary<String, Object>>();

            SQLiteCommand cmd = new SQLiteCommand(query, this.con);
            this.con.Open();
            using (SQLiteDataReader dataReader = cmd.ExecuteReader())
            {
                using (DataTable dataTable = new DataTable())
                {
                    dataTable.Load(dataReader);

                    // loop over each row
                    for (int i1 = 0; i1 < dataTable.Rows.Count; i1++)
                    {

                        DataRow currentRow = dataTable.Rows[i1];
                        Dictionary<String, Object> temporaryDictionary = new Dictionary<String, Object>();

                        // For each row loop over each column in row
                        for (int i2 = 0; i2 < dataTable.Columns.Count; i2++)
                        {
                            var currentColumnName = dataTable.Columns[i2].ToString();
                            var currentColumnValue = currentRow[currentColumnName];

                            System.Diagnostics.Debug.Write($" {currentColumnName}: ");
                            System.Diagnostics.Debug.Write($" {currentColumnValue} ");

                            // Add row columns to dictionary with column name as key and column value as dictionary value
                            temporaryDictionary.Add(currentColumnName, currentColumnValue);

                        }

                        System.Diagnostics.Debug.WriteLine("");

                        // add row dictionary to output list
                        output.Add(temporaryDictionary);
                    }
                }


            }
            this.con.Close();

            return output;

        }
        public void testGetSomething()
        {
            var data = QueryExecuter("SELECT * FROM roomTypes");

            for (int i = 0; i < data.Count;i++)
            {
                foreach(KeyValuePair<String, Object> nogot in data[i])
                {
                    System.Diagnostics.Debug.WriteLine("Dict rad ");
                    System.Diagnostics.Debug.WriteLine(nogot.Key, nogot.Value.ToString());
                }
            }
        }

        //public List<SToff> getRoomTypes()
        //{
        //    return QueryExecuter("SELECT * FROM roomTypes");

        //}

        //public List<SToff> getRooms()
        //{
        //    return QueryExecuter("SELECT * FROM rooms");

        //}

    }
}
