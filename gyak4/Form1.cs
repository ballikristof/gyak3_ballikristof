using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace gyak4
{
    public partial class Form1 : Form
    {
        List<Flat> Flats;
        RealEstateEntities context = new RealEstateEntities();

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
            CreateTable();
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nline: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        public void CreateTable()
        {
            string[] headers = new string[]{
            "Kód",
            "Eladó",
            "Oldal",
            "Kerület",
            "Lift",
            "Szobák száma",
            "Alapterület (m2)",
            "Ár (mFt)",
            "Négyzetméter ár (Ft/m2)"};

            
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }

            object[,] values = new object[Flats.Count, headers.Length];

            int cntr = 0;
            foreach (Flat f in Flats)
            {
                values[cntr, 0] = f.Code;
                values[cntr, 1] = f.Vendor;
                values[cntr, 2] = f.Side;
                values[cntr, 3] = f.District;
                values[cntr, 4] = f.Elevator;
                values[cntr, 5] = f.NumberOfRooms;
                values[cntr, 6] = f.FloorArea;
                values[cntr, 7] = f.Price;
                values[cntr, 8] = "";
                cntr++;

                
            }

            xlSheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;

            Excel.Range headerrange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerrange.Font.Bold = true;
            headerrange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerrange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerrange.EntireColumn.AutoFit();
            headerrange.RowHeight = 40;
            headerrange.Interior.Color = Color.LightBlue;
            headerrange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            int lastrowID = xlSheet.UsedRange.Rows.Count;

            Excel.Range sheetrange = xlSheet.get_Range(GetCell(2,1), GetCell(2, lastrowID));
            sheetrange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }

        
    }
}
