using System;
using System.Collections.Generic;
using System.Text;

namespace BarCodePrinter 
{
    
    public class Discription
    {
        private string itemCode;
        private string itemDiscription;
        private string barcode;
        private string searchCode;
        private bool addToPrintList;
        public int numberOfPrint = -1;
        public delegate void ItemChanged(Discription item);
        public event ItemChanged itemChanged;
        public delegate void AddToPrintListDelegate(EventArgument e);
        public event AddToPrintListDelegate addItemToPrintList;
        public delegate bool ValidForPrint(String e);
        public event ValidForPrint validForPrint;
        public delegate bool ItemClearedDelegate(EventArgument e);
        public event ItemClearedDelegate itemCleared;
        public bool f;
        public Discription(string itemcode, string itemDiscription, string barcode)
        {
            f = false;
            this.itemCode = itemcode;
            this.itemDiscription = itemDiscription;
            this.barcode = barcode;
        }

        public String NumberOfPrint
        {
            get
            {
                return numberOfPrint.ToString(); 
            }
            set
            {
                Int32.TryParse(value, out this.numberOfPrint);
                validForPrint.Invoke(NumberOfPrint);
            }
        }
        public string ItemCode
        {
            set
            {
                itemCode = value;
            }
            get
            {
                return itemCode;
            }
        }
        public string ItemDiscription
        {
            get
            {
                return itemDiscription;
            }
            set
            {
                itemDiscription = value;
            }
        }
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;;

            }
        }
        public string SearchCode
        {
            get
            {
                return searchCode;
            }
            set
            {
                searchCode = value;
                try
                {
                    itemChanged.Invoke(this);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }
        public bool AddToPrintList
        {
            get
            {
                return addToPrintList;
            }
            set
            {
                addToPrintList=value;
                if (this.numberOfPrint>0)
                {
                    try
                    {
                        addItemToPrintList.Invoke(new EventArgument(this));
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    f = true;
                }

            }
        }
        public override string ToString()
        {
            return (this.ItemCode + "  @  " +this.barcode +", " + this.ItemDiscription);
        }

        internal void clear()
        {
            this.addToPrintList = false;
            this.ItemCode = "";
            this.Barcode = "";
            this.itemDiscription = "";
            this.NumberOfPrint = "-1";
            this.SearchCode = "";
            try
            {
                itemCleared.Invoke(new EventArgument(this));
            }
            catch (Exception)
            {
            }

        }

        internal void copy(Discription discription)
        {
            this.itemCode = discription.ItemCode;
            this.itemDiscription = discription.ItemDiscription;
            this.barcode = discription.Barcode;
            this.addToPrintList = discription.AddToPrintList;
            this.numberOfPrint = discription.numberOfPrint;
            this.searchCode = discription.barcode;

        }
    }
    public class EventArgument : EventArgs
    {
        private Discription module;
        public Discription Module
        {
            get
            {
                return module;
            }
        }
        public EventArgument(Discription obj)
        {
            module = obj;
        }
    }
}

