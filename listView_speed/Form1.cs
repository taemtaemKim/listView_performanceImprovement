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
        Random r = new Random();
        
        public Form1()
        {
            InitializeComponent();

            listView1.VirtualMode = true;
            listView1.VirtualListSize = dataN;
            //listView1.MinimumSize = new System.Drawing.Size(500, 250);
            //listView1.Clear();


            //Hook up handlers for VirtualMode events.
            listView1.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView1_RetrieveVirtualItem);

            var reader = new StreamReader(@"C:\raw.csv");

            //coloms 추가
            listView1.View = View.Details;
            var columnsLine = reader.ReadLine();
            var columnsValues = columnsLine.Split(',');
            foreach (String val in columnsValues)
            {
                Console.WriteLine(val);
                listView1.Columns.Add(val, 70);
            }
            
            
        }
        
        void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //Console.WriteLine(e.ItemIndex);
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
        }

        private void dataLoad(int n)
        {
            if (n == 0) return;
            myDatum = new ListViewItem[n];

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
                
                myDatum[index] = item;

                index++;
                if (index >= n)
                    break;
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}