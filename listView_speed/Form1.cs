using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

// 출처 
// https://docs.microsoft.com/ko-kr/dotnet/api/system.windows.forms.listview.virtualmode?view=netcore-3.1

namespace listView_speed
{

    public partial class Form1 : Form
    {
        private ListViewItem[] myDatum;
        int dataN = 0;
        //int index = 0;
        Random r = new Random();

        //array to cache items for the virtual list
        //private int firstItem; //stores the index of the first item in the cache



        public Form1()
        {
            //Create a simple ListView.
            //ListView listView1 = new ListView();
            //listView1.View = View.SmallIcon;

            InitializeComponent();

            listView1.VirtualMode = true;
            listView1.VirtualListSize = dataN;
            //listView1.MinimumSize = new System.Drawing.Size(500, 250);
            //listView1.Clear();


            //Hook up handlers for VirtualMode events.
            listView1.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView1_RetrieveVirtualItem);

            var reader = new StreamReader(@"C:\raw.csv");

            //coloms 추가
            var columnsLine = reader.ReadLine();
            var columnsValues = columnsLine.Split(',');
            foreach (String val in columnsValues)
            {
                Console.WriteLine(val);
                listView1.Columns.Add(val, 70);
            }

            //Add ListView to the form.
            //this.Controls.Add(listView1);

            //Search for a particular virtual item.
            //Notice that we never manually populate the collection!
            //If you leave out the SearchForVirtualItem handler, this will return null.
            //ListViewItem lvi = listView1.FindItemWithText("111111");

            
            
        }

        //The basic VirtualMode function.  Dynamically returns a ListViewItem
        //with the required properties; in this case, the square of the index.
        void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            
            e.Item = myDatum[e.ItemIndex];

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                dataN = Int32.Parse(textBox1.Text);
            }
            catch (System.FormatException s)
            {
                dataN = 0;
                Console.WriteLine(s.Message);
            }

            dataLoad(dataN);
            listView1.VirtualListSize = dataN;
            //Console.WriteLine(tmpNumber);
        }

        private void dataLoad(int n)
        {
            if (n == 0) return;
            myDatum = new ListViewItem[n];
            //
            //{
            //    myDatum[i] = new ListViewItem(i + "ktm");
            //}

            var reader = new StreamReader(@"C:\raw.csv");
            reader.ReadLine();

            int index = 0;
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                String[] values = line.Split(',');
                var item = new ListViewItem(values[0]);

                foreach (String val in values)
                {
                    item.SubItems.Add(val);
                }

                //listView1.Items.Add(item);
                myDatum[index] = item;

                index++;
                if (index >= n)
                    break;
            }


        }
    }
}