using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace listView_speed
{
    public partial class Form1 : Form
    {

        Stopwatch stopwatch;
        int dataN = 10000;

        public Form1()
        {
            //Component init
            InitializeComponent();


            //stopwatch start
            stopwatch = new Stopwatch();
            stopwatch.Start();

            //loadData
        }


        private void dataLoadBtn_Clicked(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            dataLoadFromSVC();
        }

        private void dataLoadFromSVC()
        {
            listView.Clear();
            myLog("dataLoadFromSVC.Start");
            var reader = new StreamReader(@"C:\raw.csv");

            //coloms 추가
            var columnsLine = reader.ReadLine();
            var columnsValues = columnsLine.Split(',');
            foreach (String val in columnsValues)
            {
                //Console.WriteLine(val);
                listView.Columns.Add(val, 70);
            }

            myLog("dataLoad.Start");
            // data 추가
            int count = 0;

            //items 채우기
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                String[] values = line.Split(',');
                var item = new ListViewItem(values[0]);

                foreach (String val in values)
                {
                    item.SubItems.Add(val);
                }

                listView.Items.Add(item);

                count++;
                if (count > dataN)
                    break;
            }

            myLog("dataLoad.End");
            myLog("dataLoadFromSVC.End");


        }

        private void myLog(String title)
        {

            String formatTime = String.Format("{0:#,###}", stopwatch.ElapsedMilliseconds);

            Console.Write("###############" + title + " : ");
            Console.Write(formatTime == "" ? "0" : formatTime);
            Console.WriteLine("ms");
        }

    }
}
