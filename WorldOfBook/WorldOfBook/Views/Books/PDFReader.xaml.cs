using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для PDFReader.xaml
    /// </summary>
    
    public partial class PDFReader : UserControl
    {
        public PDFReader(string path)
        {
            InitializeComponent();
            Show(path);
        }

        public void Show(string str)
        {
            PdfReader pdf_Reader = new PdfReader(str);
            String sText = "";

            for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
            {
                sText = sText + PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
            }

            Reader.Text = sText;
        }

    }
}
