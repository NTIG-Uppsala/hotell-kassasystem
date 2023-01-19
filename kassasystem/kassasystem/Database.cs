using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kassasystem
{
    public class Room
    {
        public Int64 Id { get; set; }
        public decimal Rate { get; set; }
        public Int64 Number { get; set; }
        public Int64 Floor { get; set; }
        public string? Type { get; set; }
        public Int64 RecommendedPeople { get; set; }
    }

    public class Data
    {
        public Int64 Id { get; set;}
        public Int64 BookingId { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public Int64 OrderNumber { get; set; }
        public decimal TotalNoTax { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }

    public class Booking
    {
        public Int64 Id { get; set; }

        public Int64 RoomNumber { get; set; }

        public string? GuestFirstName { get; set; }
        public string? GuestLastName { get; set; }


        public Int64 PaymentId { get; set; }
        public Int64 PaymentDate { get; set; }
        public decimal AmountDue { get; set; }
    }

    class BookingItem
    {
        public string? DisplayName { get; set; }
        public Booking? BookingObject { get; set; }
    }

    public class Database
    {
        private static readonly string[] tables = {
            "CREATE TABLE \"bookings\" (\r\n\t\"bookingID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"paymentID\"\tINTEGER,\r\n\t\"dateFrom\"\tNUMERIC,\r\n\t\"dateTo\"\tNUMERIC,\r\n\t\"roomCount\"\tINTEGER,\r\n\t\"isBreakfastIncluded\"\tNUMERIC,\r\n\tPRIMARY KEY(\"bookingID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tFOREIGN KEY(\"paymentID\") REFERENCES \"payment\"(\"paymentID\")\r\n);",
            "CREATE TABLE \"externalCosts\" (\r\n\t\"externalCostsID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"paymentID\"\tINTEGER,\r\n\t\"externalCost\"\tTEXT,\r\n\t\"costDescription\"\tTEXT,\r\n\tFOREIGN KEY(\"paymentID\") REFERENCES \"payment\"(\"paymentID\"),\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tPRIMARY KEY(\"externalCostsID\" AUTOINCREMENT)\r\n);",
            "CREATE TABLE \"guestContact\" (\r\n\t\"guestContactID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"mail\"\tTEXT,\r\n\t\"phoneNumber\"\tINTEGER,\r\n\tPRIMARY KEY(\"guestContactID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\")\r\n);",
            "CREATE TABLE \"guests\" (\r\n\t\"guestID\"\tINTEGER NOT NULL,\r\n\t\"firstName\"\tTEXT,\r\n\t\"lastName\"\tTEXT,\r\n\tPRIMARY KEY(\"guestID\" AUTOINCREMENT)\r\n);",
            "CREATE TABLE \"payment\" (\r\n\t\"paymentID\"\tINTEGER NOT NULL,\r\n\t\"paymentTypeID\"\tINTEGER,\r\n\t\"date\"\tINTEGER,\r\n\t\"amount\"\tINTEGER,\r\n\t\"isPaid\"\tNUMERIC,\r\n\tPRIMARY KEY(\"paymentID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"paymentTypeID\") REFERENCES \"paymentType\"(\"paymentTypeID\")\r\n);",
            "CREATE TABLE \"paymentType\" (\r\n\t\"paymentTypeID\"\tINTEGER NOT NULL,\r\n\t\"type\"\tNUMERIC,\r\n\tPRIMARY KEY(\"paymentTypeID\" AUTOINCREMENT)\r\n);",
            "CREATE TABLE \"roomTypes\" (\r\n\t\"roomTypesID\"\tINTEGER NOT NULL,\r\n\t\"type\"\tTEXT,\r\n\t\"totalPeople\"\tINTEGER,\r\n\tPRIMARY KEY(\"roomTypesID\" AUTOINCREMENT)\r\n);",
            "CREATE TABLE \"rooms\" (\r\n\t\"roomID\"\tINTEGER NOT NULL,\r\n\t\"roomTypesID\"\tINTEGER,\r\n\t\"floor\"\tINTEGER,\r\n\t\"roomNumber\"\tINTEGER,\r\n\t\"rate\"\tINTEGER,\r\n\tPRIMARY KEY(\"roomID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"roomTypesID\") REFERENCES \"roomTypes\"(\"roomTypesID\")\r\n);",
            "CREATE TABLE \"roomsBooked\" (\r\n\t\"roomsBookedID\"\tINTEGER NOT NULL,\r\n\t\"bookingID\"\tINTEGER,\r\n\t\"roomID\"\tINTEGER,\r\n\tFOREIGN KEY(\"roomID\") REFERENCES \"rooms\"(\"roomID\"),\r\n\tFOREIGN KEY(\"bookingID\") REFERENCES \"bookings\"(\"bookingID\"),\r\n\tPRIMARY KEY(\"roomsBookedID\" AUTOINCREMENT)\r\n);",
            "CREATE TABLE \"receipt\" (\r\n\t\"receiptID\"\tINTEGER NOT NULL,\r\n\t\"bookingID\"\tINTEGER,\r\n\t\"date\"\tTEXT,\r\n\t\"time\"\tTEXT,\r\n\t\"orderNumber\"\tINTEGER,\r\n\t\"total\"\tINTEGER,\r\n\tFOREIGN KEY(\"bookingID\") REFERENCES \"bookings\"(\"bookingID\"),\r\n\tPRIMARY KEY(\"receiptID\" AUTOINCREMENT)\r\n);"
        };

        public SQLiteConnection Connection { get; set; }

        // directoryPath must end with "\"
        public Database(string directoryPath, string fileName)
        {
            string filePath = string.Format(@"{0}{1}", directoryPath, fileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
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

            this.Connection = new SQLiteConnection($"Data Source={filePath};");
        }

        public List<Dictionary<string, object>> QueryExecutor(string query)
        {
            /* 
             * Returns a list of dictonaroies with result from db
             * REF: https://www.daniweb.com/programming/software-development/threads/234938/get-the-column-values-from-the-sqlite-database
             * 
            */

            List<Dictionary<string, object>> output = new List<Dictionary<string, object>>();

            SQLiteCommand cmd = new SQLiteCommand(query, this.Connection);
            this.Connection.Open();
            try
            {
                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    using (DataTable dataTable = new DataTable())
                    {
                        dataTable.Load(dataReader);

                        // loop over each row
                        for (int i1 = 0; i1 < dataTable.Rows.Count; i1++)
                        {

                            // scrum benefits: more pain, no results.

                            DataRow currentRow = dataTable.Rows[i1];
                            Dictionary<string, object> temporaryDictionary = new Dictionary<string, object>();

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

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            this.Connection.Close();

            return output;

        }

        public Int64 QueryInsertExecutor(string query)
        {
            /* 
             * Insert the the index the item was inserted in
             * REF: https://stackoverflow.com/questions/4341178/getting-the-last-insert-id-with-sqlite-net-in-c-sharp
            */

            Int64 output_row_id = -1;

            SQLiteCommand cmd = new SQLiteCommand(query, this.Connection);
            this.Connection.Open();
            try
            {
                SQLiteTransaction transaction;
                transaction = this.Connection.BeginTransaction();

                cmd.ExecuteNonQuery();

                output_row_id = this.Connection.LastInsertRowId;

                transaction.Commit();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            this.Connection.Close();

            return output_row_id;

        }
        public List<Room> GetAvailableRooms(int epochStartDate, int epochEndDate)
        {
            var rooms = QueryExecutor("SELECT * FROM rooms");
            var roomTypes = QueryExecutor("SELECT * FROM roomTypes");

            for (int x = 0; x < rooms.Count; x++)
            {
                var typeID = rooms[x]["roomTypesID"];

                for (int y = 0; y < roomTypes.Count; y++)
                {
                   
                    if (typeID.ToString() == roomTypes[y]["roomTypesID"].ToString())
                    {
                        roomTypes[y].ToList().ForEach(z => rooms[x][z.Key] = z.Value);
                    } 
                    
                }
            }

            var output = new List<Room>();
            for (int i = 0; i < rooms.Count; i++)
            {
                Room newRoom = new Room();
                newRoom.Id = (Int64)rooms[i]["roomID"];
                newRoom.Rate = Convert.ToDecimal((Int64) rooms[i]["rate"]) / 100m;
                newRoom.Number = (Int64)rooms[i]["roomNumber"];
                newRoom.Floor = (Int64)rooms[i]["floor"];
                newRoom.Type = (string)rooms[i]["type"];
                if (newRoom.Type == null)
                {
                    MessageBox.Show("type null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
                newRoom.RecommendedPeople = (Int64)rooms[i]["totalPeople"];

                output.Add(newRoom);
            }
            return output;
        }

        public void CreateNewBooking(Int64 roomID, string GuestFirstName, string GuestLastName, int checkinDate, int checkoutDate, decimal totalPrice)
        {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1); // Time in seconds since january 1 1970
            int currentDateNow = ((int)t.TotalSeconds);

            var insertTotalPrice = decimal.ToInt64(totalPrice * 100m);

            var newPaymentID = QueryInsertExecutor($"INSERT INTO payment (paymentTypeId, date, amount, isPaid) VALUES ('1', '{currentDateNow}', '{insertTotalPrice}', '0')");
            var newGuestID = QueryInsertExecutor($"INSERT INTO guests (firstName, lastName) VALUES ('{GuestFirstName}', '{GuestLastName}')");
            System.Diagnostics.Debug.WriteLine(newGuestID);

            var newBookingID = QueryInsertExecutor($"INSERT INTO bookings (guestID, paymentID, dateFrom, dateTo, roomCount, isBreakfastIncluded) VALUES ('{newGuestID}', '{newPaymentID}', '{checkinDate}', '{checkoutDate}', '1', '1') ");

            QueryInsertExecutor($"INSERT INTO roomsBooked (bookingID, roomID) VALUES ('{newBookingID}', '{roomID}')");

        }

        public List<Booking> GetBookings()
        {
            /*
             * For each booking save it to a list of Booking objects to be used later (when creating PDF and updating cart view)
             */
            var rows = QueryExecutor("SELECT b.guestID, b.dateFrom, b.dateTo, b.roomCount, b.isBreakfastIncluded, r.roomsBookedID, r.bookingID, r.roomID, r1.roomID, r1.roomTypesID, r1.floor, r1.roomNumber, r1.rate, r2.totalPeople, g.firstName, g.lastName, p.paymentID, p.date, p.amount, p.isPaid, p1.\"type\"\r\nFROM bookings b \r\n\tLEFT JOIN roomsBooked r ON ( r.bookingID = b.bookingID  )  \r\n\tLEFT JOIN rooms r1 ON ( r1.roomID = r.roomID  )  \r\n\tLEFT JOIN roomTypes r2 ON ( r2.roomTypesID = r1.roomTypesID  )  \r\n\tLEFT JOIN guests g ON ( g.guestID = b.guestID  )  \r\n\tLEFT JOIN guestContact g1 ON ( g1.guestID = g.guestID  )  \r\n\tLEFT JOIN payment p ON ( p.paymentID = b.paymentID  )  \r\n\tLEFT JOIN paymentType p1 ON ( p1.paymentTypeID = p.paymentTypeID  )");



            var output = new List<Booking>();
            for (int i = 0; i < rows.Count; i++)
            {
                Booking newBooking = new Booking();
                newBooking.Id = (Int64)rows[i]["bookingID"];
                newBooking.PaymentId = (Int64)rows[i]["paymentID"];
                newBooking.PaymentDate = (Int64)rows[i]["date"];
                newBooking.AmountDue = Convert.ToDecimal((Int64) rows[i]["amount"]) / 100m;
                newBooking.RoomNumber = (Int64)rows[i]["roomNumber"];
                newBooking.GuestFirstName = (string)rows[i]["firstName"];
                newBooking.GuestLastName = (string)rows[i]["lastName"];


                output.Add(newBooking);
            }

            return output;

        }

        public List<Booking> GetPaidBookings()
        {
            /*
             * For each booking save it to a list of Booking objects to be used later (when creating PDF and updating cart view)
             */
            var rows = QueryExecutor("SELECT b.guestID, b.dateFrom, b.dateTo, b.roomCount, b.isBreakfastIncluded, r.roomsBookedID, r.bookingID, r.roomID, r1.roomID, r1.roomTypesID, r1.floor, r1.roomNumber, r1.rate, r2.totalPeople, g.firstName, g.lastName, p.paymentID, p.date, p.amount, p.isPaid, p1.\"type\"\r\nFROM bookings b \r\n\tLEFT JOIN roomsBooked r ON ( r.bookingID = b.bookingID  )  \r\n\tLEFT JOIN rooms r1 ON ( r1.roomID = r.roomID  )  \r\n\tLEFT JOIN roomTypes r2 ON ( r2.roomTypesID = r1.roomTypesID  )  \r\n\tLEFT JOIN guests g ON ( g.guestID = b.guestID  )  \r\n\tLEFT JOIN guestContact g1 ON ( g1.guestID = g.guestID  )  \r\n\tLEFT JOIN payment p ON ( p.paymentID = b.paymentID  )  \r\n\tLEFT JOIN paymentType p1 ON ( p1.paymentTypeID = p.paymentTypeID  )  \r\nWHERE p.isPaid = 1");



            var output = new List<Booking>();
            for (int i = 0; i < rows.Count; i++)
            {
                Booking newBooking = new Booking();
                newBooking.Id = (Int64)rows[i]["bookingID"];
                newBooking.PaymentId = (Int64)rows[i]["paymentID"];
                newBooking.AmountDue = Convert.ToDecimal((Int64)rows[i]["amount"]) / 100m;
                newBooking.RoomNumber = (Int64)rows[i]["roomNumber"];
                newBooking.GuestFirstName = (string)rows[i]["firstName"];
                newBooking.GuestLastName = (string)rows[i]["lastName"];


                output.Add(newBooking);
            }

            return output;

        }

        public List<Booking> GetUnpaidBookings()
        {
            /*
             * For each booking save it to a list of Booking objects to be used later (when creating PDF and updating cart view)
             */
            var rows = QueryExecutor("SELECT b.guestID, b.dateFrom, b.dateTo, b.roomCount, b.isBreakfastIncluded, r.roomsBookedID, r.bookingID, r.roomID, r1.roomID, r1.roomTypesID, r1.floor, r1.roomNumber, r1.rate, r2.totalPeople, g.firstName, g.lastName, p.paymentID, p.date, p.amount, p.isPaid, p1.\"type\"\r\nFROM bookings b \r\n\tLEFT JOIN roomsBooked r ON ( r.bookingID = b.bookingID  )  \r\n\tLEFT JOIN rooms r1 ON ( r1.roomID = r.roomID  )  \r\n\tLEFT JOIN roomTypes r2 ON ( r2.roomTypesID = r1.roomTypesID  )  \r\n\tLEFT JOIN guests g ON ( g.guestID = b.guestID  )  \r\n\tLEFT JOIN guestContact g1 ON ( g1.guestID = g.guestID  )  \r\n\tLEFT JOIN payment p ON ( p.paymentID = b.paymentID  )  \r\n\tLEFT JOIN paymentType p1 ON ( p1.paymentTypeID = p.paymentTypeID  )  \r\nWHERE p.isPaid = 0");

           

            var output = new List<Booking>();
            for (int i = 0; i < rows.Count; i++)
            {
                Booking newBooking = new Booking();
                newBooking.Id = (Int64)rows[i]["bookingID"];
                newBooking.PaymentId = (Int64)rows[i]["paymentID"];
                newBooking.AmountDue = Convert.ToDecimal((Int64) rows[i]["amount"]) / 100m;
                newBooking.RoomNumber = (Int64)rows[i]["roomNumber"];
                newBooking.GuestFirstName = (string)rows[i]["firstName"];
                newBooking.GuestLastName = (string)rows[i]["lastName"];


                output.Add(newBooking);
            }

            return output;

        }

        public void SetBookingPaid(Int64 paymentID)
        {
            QueryInsertExecutor($"UPDATE payment SET isPaid=1 WHERE paymentID={paymentID}");
        }

        public void SaveReceiptData(Int64 bookingID, decimal totalPrice)
        {
            string currentDate = DateTime.Now.ToString().Split(" ")[0];
            string currentTime = DateTime.Now.ToString().Split(" ")[1];

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1); // Time in seconds since january 1 1970
            string currentTimePeriod = ((int)t.TotalSeconds).ToString();

            decimal total = decimal.ToInt64(Math.Round(totalPrice * 1.00M, 2) * 100m);

            QueryInsertExecutor($"INSERT INTO receipt (bookingID, date, time, orderNumber, total) " +
                $"VALUES ('{bookingID}', '{currentDate}', '{currentTime}', '{currentTimePeriod}', '{total}')");
        }
         
        public Data GetReceiptData(Int64 bookingID)
        {
            var data = QueryExecutor($"SELECT * FROM receipt WHERE bookingID = {bookingID}"); // TODO check if query can return multiple receipts.
            Data newdata = new Data();
            decimal taxAmount = 0.12m;
            for (int i = 0; i < data.Count; i++)
            {   
                newdata.Id = (Int64)data[i]["receiptID"];
                newdata.BookingId = (Int64)data[i]["bookingID"];
                newdata.Date = (string)data[i]["date"];
                newdata.Time = (string)data[i]["time"];
                newdata.OrderNumber = (Int64)data[i]["orderNumber"];
                newdata.Total = Convert.ToDecimal((Int64)data[i]["total"]) / 100m;
                newdata.TotalNoTax = Math.Round(newdata.Total / (taxAmount + 1), 2);
                newdata.Tax = Math.Round(newdata.Total - newdata.Total / (taxAmount + 1), 2);
                
            }
            return newdata;
        }

        public void RemoveBooking(Int64 bookingID)
        {
            QueryExecutor($"DELETE FROM bookings WHERE bookingID = {bookingID}; DELETE FROM roomsBooked WHERE bookingID = {bookingID};");
        }

        public string[]? GetBookingDate(Int64 bookingID)
        {
            var data = QueryExecutor($"SELECT dateFrom, dateTo FROM bookings WHERE bookingID = {bookingID}");

            var dateFrom = data[0]["dateFrom"];
            var dateTo = data[0]["dateTo"];

            if (dateFrom == null || dateTo == null)
                return null;

            string? dateFromStr = dateFrom.ToString();
            string? dateToStr = dateTo.ToString();
            if (dateFromStr == null || dateToStr == null)
                return null;

            long dateFrom2 = long.Parse(dateFromStr);
            long dateTo2 = long.Parse(dateToStr);

            DateTimeOffset checkInDate = DateTimeOffset.FromUnixTimeSeconds(dateFrom2);
            DateTimeOffset checkOutDate = DateTimeOffset.FromUnixTimeSeconds(dateTo2);

            string? checkInDateStr = checkInDate.ToString();
            string? checkOutDateStr = checkOutDate.ToString();
            if (checkInDateStr == null || checkOutDateStr == null)
                return null;

            string[] dataArray =
            {
                checkInDateStr.Split(" ")[0],
                checkOutDateStr.Split(" ")[0]
            };

            return dataArray;
        }

    }
}
