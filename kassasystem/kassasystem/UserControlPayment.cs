﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace kassasystem
{



    public partial class UserControlPayment : UserControl
    {   
        // Dictionaries for prices and products
        public Dictionary<string, int> priceList = new Dictionary<string, int>();
        public Dictionary<string, decimal> cartDictionary = new Dictionary<string, decimal>();
        PDFGenerator pdfGenerator = new PDFGenerator();
        Database db = new Database();

        Booking SelectedBooking;

        public Decimal totalPrice = 0;
        public UserControlPayment()
        {
            InitializeComponent();
            bookingsList.DisplayMember = "displayName";
            bookingsList.ValueMember = "bookingObject";

            // Plays motivating music
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.fish1);
            // player.PlayLooping();
            // Gets current date
            // CheckOutDayPicker.Value = DateTime.Now; 
            var data = db.GetUnpaidBookings();

            foreach (Booking booking in data)
            {
                bookingsList.Items.Add(new BookingItem
                {
                    displayName = Convert.ToString(booking.guestFirstName) + ' ' + Convert.ToString(booking.guestLastName),
                    bookingObject = booking
                });
            }
        }

        private void Form1Load(object sender, EventArgs e)
        {

        }

        // Calculates price of room
        private Decimal CalculateRoomPrice(Decimal roomPrice, int nights)
        {
            Decimal formula = roomPrice * nights;
            return formula;
        }

        private void UpdateCartView()
        {
            //int bookingDays = GetDateDifference(CheckOutDayPicker.Value);

            listBox1.Items.Clear();
            string dayFormat;
            foreach (KeyValuePair<string, decimal> product in cartDictionary)
            {
                //if (bookingDays == 1)
                //{
                //    dayFormat = "day";
                //} else
                //{
                //    dayFormat = "days";
                //}
                // Adds products in formated order to list box
                listBox1.Items.Add($"{product.Key} {SelectedBooking.amountDue} SEK");
            }
            UpdateTotal();
        }

        // Keeps the total price up to date
        private void UpdateTotal()
        {
            this.totalPrice = 0.00M;

            if (cartDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, decimal> product in cartDictionary)
                {

                    this.totalPrice += SelectedBooking.amountDue;
                }
            }
            this.lblTotal.Text = $"Total: {this.totalPrice} SEK";
        }

        // Adds to the of amount of products in list box when product is already present
        private void AddToCart(string productName)
        {
            if (cartDictionary.ContainsKey(productName))
            {
                cartDictionary[productName]++;
            }
            else
            {
                cartDictionary.Add(productName, 1);
            }
            UpdateCartView();
        }

        // Checks differnce between current date and checkout date
        private int GetDateDifference(DateTime dateCheck)
        {
            DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            DateTime theDate = Convert.ToDateTime(dateCheck.ToString().Split()[0]);
            int difference = (int)(theDate - today).TotalDays;
            return difference;
        }

        // Adds correct product to listbox according to the pressed button
        private void BtnClick(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            AddToCart(buttonText);

        }

        // Removes one instance of selected product amount
        private void BtnRemove1xClick(object sender, EventArgs e)
        {
            // Button only functions if one product is selected
            //if (listBox1.SelectedItems.Count == 1)
            //{
            //    string input = listBox1.SelectedItem.ToString();
            //    foreach (KeyValuePair<string, decimal> product in cartDictionary)
            //    {
            //        // Removes one instance, and clears the product if the amount reults as zero
            //        if (input.Contains(product.Key))
            //        {
            //            System.Diagnostics.Debug.WriteLine("the key " + product.Key + " exists in input " + input);
            //            int currentValue = product.Value;
            //            cartDictionary[product.Key] = currentValue - 1;

            //            if (cartDictionary[product.Key] == 0)
            //            {
            //                cartDictionary.Remove(product.Key);
            //            }
            //        }
            //    }
            //    UpdateCartView();
            //}

        }

        // Removes every instance of selected product
        private void BtnRemoveClick(object sender, EventArgs e)
        {
            // Button only functions if one product is selected
            //if (listBox1.SelectedItems.Count == 1)
            //{
            //    string input = listBox1.SelectedItem.ToString();
            //    foreach (KeyValuePair<string, decimal> product in cartDictionary)
            //    {
            //        if (input.Contains(product.Key))
            //        {
            //            System.Diagnostics.Debug.WriteLine("the key" + product.Key + "exists in input");
            //            cartDictionary.Remove(product.Key);
            //        }
            //    }
            //    UpdateCartView();
            //}
        }

        // Resets the entire list box
        private void ResetValues()
        {
            cartDictionary.Clear();
            listBox1.Items.Clear();
            //CheckOutDayPicker.Value = Convert.ToDateTime(DateTime.Now.Date.ToString().Split()[0]);
            UpdateTotal();
        }

        // Calls reset function
        private void BtnClearClick(object sender, EventArgs e)
        {
            ResetValues();
        }

        // Makes PDF reciept when button is pressed, then calls reset function
        private void BtnPayClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                pdfGenerator.savePDF(listBox1, totalPrice);
                ResetValues();
            }
            else
            {
                // TODO: show message cart empty

            }
        }

        // Keeps amount of days up to date
        private void CheckOutDayPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateCartView();
        }

        private void btnSendToPaymentList_Click(object sender, EventArgs e)
        {
            if (bookingsList.SelectedItems.Count == 1) 
            {
                System.Diagnostics.Debug.WriteLine($"INDEX SELECTED FROM BOOKING LIST {bookingsList.SelectedIndex.ToString()}");
                cartDictionary.Clear();
                Booking selectedBooking = ((BookingItem)bookingsList.SelectedItem).bookingObject;
                System.Diagnostics.Debug.WriteLine($"ITEM SELECTED {selectedBooking.ToString()}");


                if (selectedBooking != null)
                {
                    System.Diagnostics.Debug.Write($"{Convert.ToString(selectedBooking.id)}, {selectedBooking.amountDue}");
                    cartDictionary.Add(Convert.ToString(selectedBooking.id), selectedBooking.amountDue);
                    this.SelectedBooking = selectedBooking;
                    UpdateCartView();
                }
                else
                {
                    //
                }
            };

        }

        private void bookingsList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


    }
    class BookingItem
    {
        public string displayName { get; set; }
        public Booking bookingObject { get; set; }
    }
}
