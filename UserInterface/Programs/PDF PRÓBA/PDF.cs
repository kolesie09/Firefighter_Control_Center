using FirefighterControlCenter.DataAccessLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface
{
    class PDF
    {
        private static int Howmanypeople;
        private static int Howmanyvehicle;

        #region Create PDF
        public string CreateEquivalentPDF(int Month, int Year)
        {
            string pathintake = "";

            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.CP1250, BaseFont.EMBEDDED);
            iTextSharp.text.Font nameFont = new iTextSharp.text.Font(bf, 8);
            iTextSharp.text.Font nameFontT = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
            var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            try
            {
                try
                {
                    pathintake = $"C:\\OSP\\Ekwiwalent\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\Ekwiwalent.pdf";

                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }
                catch
                {
                    string path = @"C:\\OSP\\Ekwiwalent\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc";
                    System.IO.Directory.CreateDirectory(path);
                    pathintake = $"C:\\OSP\\Ekwiwalent\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\Ekwiwalent.pdf";


                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }

                pdfDoc.Open();
                var imagepath = @"C:\OSP\logo.png";
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                    png.ScalePercent(3f);

                    png.SetAbsolutePosition(pdfDoc.Left, 710);
                    png.PaddingTop = 100;
                    pdfDoc.Add(png);
                }


                var Confirmation = new Paragraph("Ekwiwalent za wyjazdy (" + Mount(Month) + " / " + Year + ")", nameFontT);
                Confirmation.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(Confirmation);
                var spacer10 = new Paragraph("")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };
                pdfDoc.Add(spacer10);

                PdfPTable table = new PdfPTable(new[] { .15f, .4f, .55f, .25f, .25f, .25f });

                PdfPCell cell = new PdfPCell(new Phrase("LP", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Imie", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Nazwisko", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Liczba godzin", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Stawka", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell); ;
                cell = new PdfPCell(new Phrase("Suma", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                List<List<string>> tab = SqlConnectorv2.DataEquivalent(Month, Year, 1);


                for (int i = 0; i < tab[0].Count; i++)
                {
                    cell = new PdfPCell(new Paragraph((i + 1).ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[0][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[1][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[2][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[3][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    int suma = int.Parse(tab[2][i]) * int.Parse(tab[3][i]);
                    cell = new PdfPCell(new Paragraph(suma.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                }
                pdfDoc.Add(table);
                pdfDoc.Add(spacer10);
                Confirmation = new Paragraph("Ekwiwalent za ćwiczenia", nameFontT);
                Confirmation.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(Confirmation);

                pdfDoc.Add(spacer10);

                PdfPTable tablee = new PdfPTable(new[] { .15f, .4f, .55f, .25f, .25f, .25f });

                PdfPCell celle = new PdfPCell(new Phrase("LP", nameFont));
                celle.HorizontalAlignment = Element.ALIGN_CENTER;
                tablee.AddCell(celle);
                celle = new PdfPCell(new Phrase("Imie", nameFont));
                celle.HorizontalAlignment = Element.ALIGN_CENTER;
                tablee.AddCell(celle);
                celle = new PdfPCell(new Phrase("Nazwisko", nameFont));
                celle.HorizontalAlignment = Element.ALIGN_CENTER;
                tablee.AddCell(celle);
                celle = new PdfPCell(new Phrase("Liczba godzin", nameFont));
                celle.HorizontalAlignment = Element.ALIGN_CENTER;
                tablee.AddCell(celle);
                celle = new PdfPCell(new Phrase("Stawka", nameFont));
                celle.HorizontalAlignment = Element.ALIGN_CENTER;
                tablee.AddCell(celle);
                celle = new PdfPCell(new Phrase("Suma", nameFont));
                celle.HorizontalAlignment = Element.ALIGN_CENTER;
                tablee.AddCell(celle);

                List<List<string>> tabb = SqlConnectorv2.DataEquivalent(Month, Year, 2);

                if (tabb[0].Count > 0)
                {
                    for (int i = 0; i < tabb[0].Count; i++)
                    {
                        celle = new PdfPCell(new Paragraph((i + 1).ToString(), nameFont));
                        celle.HorizontalAlignment = Element.ALIGN_CENTER;
                        celle.PaddingBottom = 4;
                        tablee.AddCell(celle);
                        celle = new PdfPCell(new Phrase(tabb[0][i], nameFont));
                        celle.HorizontalAlignment = Element.ALIGN_CENTER;
                        celle.PaddingBottom = 4;
                        tablee.AddCell(celle);
                        celle = new PdfPCell(new Phrase(tabb[1][i], nameFont));
                        celle.HorizontalAlignment = Element.ALIGN_CENTER;
                        celle.PaddingBottom = 4;
                        tablee.AddCell(celle);
                        celle = new PdfPCell(new Phrase(tabb[2][i], nameFont));
                        celle.HorizontalAlignment = Element.ALIGN_CENTER;
                        celle.PaddingBottom = 4;
                        tablee.AddCell(celle);
                        celle = new PdfPCell(new Phrase(tabb[3][i], nameFont));
                        celle.HorizontalAlignment = Element.ALIGN_CENTER;
                        celle.PaddingBottom = 4;
                        tablee.AddCell(celle);
                        int suma = int.Parse(tabb[2][i]) * int.Parse(tabb[3][i]);
                        celle = new PdfPCell(new Paragraph(suma.ToString(), nameFont));
                        celle.HorizontalAlignment = Element.ALIGN_CENTER;
                        celle.PaddingBottom = 4;
                        tablee.AddCell(celle);
                    }
                }


                pdfDoc.Add(tablee);
                pdfDoc.Add(spacer10);
                Confirmation = new Paragraph("Ekwiwalent za szkolenia", nameFontT);
                Confirmation.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(Confirmation);

                pdfDoc.Add(spacer10);

                PdfPTable tableee = new PdfPTable(new[] { .15f, .4f, .55f, .25f, .25f, .25f });

                PdfPCell cellee = new PdfPCell(new Phrase("LP", nameFont));
                cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                tableee.AddCell(cellee);
                cellee = new PdfPCell(new Phrase("Imie", nameFont));
                cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                tableee.AddCell(cellee);
                cellee = new PdfPCell(new Phrase("Nazwisko", nameFont));
                cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                tableee.AddCell(cellee);
                cellee = new PdfPCell(new Phrase("Liczba godzin", nameFont));
                cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                tableee.AddCell(cellee);
                cellee = new PdfPCell(new Phrase("Stawka", nameFont));
                cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                tableee.AddCell(cellee);
                cellee = new PdfPCell(new Phrase("Suma", nameFont));
                cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                tableee.AddCell(cellee);

                List<List<string>> tabbb = SqlConnectorv2.DataEquivalent(Month, Year, 3);

                if (tabbb[0].Count > 0)
                {

                    for (int i = 0; i < tabbb[0].Count; i++)
                    {
                        cellee = new PdfPCell(new Paragraph((i + 1).ToString(), nameFont));
                        cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellee.PaddingBottom = 4;
                        tableee.AddCell(cellee);
                        cellee = new PdfPCell(new Phrase(tabbb[0][i], nameFont));
                        cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellee.PaddingBottom = 4;
                        tableee.AddCell(cellee);
                        cellee = new PdfPCell(new Phrase(tabbb[1][i], nameFont));
                        cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellee.PaddingBottom = 4;
                        tableee.AddCell(cellee);
                        cellee = new PdfPCell(new Phrase(tabbb[2][i], nameFont));
                        cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellee.PaddingBottom = 4;
                        tableee.AddCell(cellee);
                        cellee = new PdfPCell(new Phrase(tabbb[3][i], nameFont));
                        cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellee.PaddingBottom = 4;
                        tableee.AddCell(cellee);
                        int suma = int.Parse(tabbb[2][i]) * int.Parse(tabbb[3][i]);
                        cellee = new PdfPCell(new Paragraph(suma.ToString(), nameFont));
                        cellee.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellee.PaddingBottom = 4;
                        tableee.AddCell(cellee);
                    }
                }
                pdfDoc.Add(tableee);
                


                pdfDoc.Close();
                MessageBox.Show("Wszystko git");
            }
            catch
            {

                pdfDoc.Close();
            }



            return pathintake;
        }


        public string CreateGminnyEquivalentPDF(int Month, int Year)
        {
            string pathintake = "";

            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.CP1250, BaseFont.EMBEDDED);
            iTextSharp.text.Font nameFont = new iTextSharp.text.Font(bf, 8);
            iTextSharp.text.Font nameFontT = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
            var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            try
            {
                try
                {
                    pathintake = $"C:\\OSP\\Ekwiwalent\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\Gminny-Ekwiwalent.pdf";

                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }
                catch
                {
                    string path = @"C:\\OSP\\Ekwiwalent\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc";
                    System.IO.Directory.CreateDirectory(path);
                    pathintake = $"C:\\OSP\\Ekwiwalent\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\Gminny-Ekwiwalent.pdf";


                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }

                pdfDoc.Open();
                var imagepath = @"C:\OSP\logo.png";
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                    png.ScalePercent(3f);

                    png.SetAbsolutePosition(pdfDoc.Left, 710);
                    png.PaddingTop = 100;
                    pdfDoc.Add(png);
                }


                var Confirmation = new Paragraph("Ekwiwalent ( " + Mount(Month) + " / " + Year + " )", nameFontT);
                Confirmation.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(Confirmation);
                var spacer10 = new Paragraph("")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };
                pdfDoc.Add(spacer10);

                PdfPTable table = new PdfPTable(new[] { .15f, .4f, .55f, .25f, .25f, .25f });

                PdfPCell cell = new PdfPCell(new Phrase("LP", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Imie", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Nazwisko", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Działania", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Ćwiczenia", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell); ;
                cell = new PdfPCell(new Phrase("Szkolenia", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                List<List<string>> tab = SqlConnectorv2.DataGminnyEquivalent(Month, Year, 1);


                for (int i = 0; i < tab[0].Count; i++)
                {
                    cell = new PdfPCell(new Paragraph((i + 1).ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[0][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[1][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[2][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[3][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(tab[4][i], nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                }
                pdfDoc.Add(table);



               


                pdfDoc.Close();
                MessageBox.Show("Wszystko git");
            }
            catch
            {

                pdfDoc.Close();
            }



            return pathintake;
        }


        public static string CreatePDFv2(List<string> BasicInformation, List<string> PlaceInformation, List<string> ReasonInformation, List<int> Vehicle, int Year, int Month, int Time, string Head)
        {
            string pathintake = "";

            iTextSharp.text.Font nameFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 7);
            iTextSharp.text.Font nameFontT = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 7, iTextSharp.text.Font.BOLD);
            var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            try
            {


                try
                {

                    if (PlaceInformation[1] == "")
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\" + BasicInformation[0] + "-" + Year + " - " + PlaceInformation[0] + " - " + ReasonInformation[1] + ".pdf";
                    }
                    else
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\" + BasicInformation[0] + "-" + Year + " - " + PlaceInformation[0] + ", ul. " + PlaceInformation[1] + " - " + ReasonInformation[1] + ".pdf";
                    }
                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }
                catch
                {
                    string path = @"C:\\OSP\\Wyjazdy\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc";
                    System.IO.Directory.CreateDirectory(path);

                    if (PlaceInformation[1] == "")
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\" + BasicInformation[0] + "-" + Year + " - " + PlaceInformation[0] + " - " + ReasonInformation[1] + ".pdf";
                    }
                    else
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + Year + " Rok\\" + Mount(Month) + " Miesiąc\\" + BasicInformation[0] + "-" + Year + " - " + PlaceInformation[0] + ", ul. " + PlaceInformation[1] + " - " + ReasonInformation[1] + ".pdf";
                    }

                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }

                pdfDoc.Open();

                var imagepath = @"C:\OSP\logo.png";
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                    png.ScalePercent(3f);

                    png.SetAbsolutePosition(pdfDoc.Left, 710);
                    png.PaddingTop = 100;
                    pdfDoc.Add(png);
                }

                var spacer10 = new Paragraph("")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };
                var spacer5 = new Paragraph("")
                {
                    SpacingBefore = 5f,
                    SpacingAfter = 5f,
                };



                var PdfNumberDepartureCard = new Paragraph(BasicInformation[0] + "/" + Year + "              ", nameFontT);
                PdfNumberDepartureCard.Alignment = Element.ALIGN_RIGHT;
                PdfNumberDepartureCard.SpacingBefore = -20;
                PdfNumberDepartureCard.Font.Size = 15;
                pdfDoc.Add(PdfNumberDepartureCard);

                var InfoAboutNumber = new Paragraph("(Nr ewidencyjny zdarzenie)          ", nameFont);
                InfoAboutNumber.Alignment = Element.ALIGN_RIGHT;
                InfoAboutNumber.Font.Size = 10;
                pdfDoc.Add(InfoAboutNumber);
                pdfDoc.Add(spacer5);

                var Confirmation = new Paragraph("Potwierdzenie", nameFontT);
                Confirmation.Alignment = Element.ALIGN_CENTER;
                Confirmation.Font.Size = 20;
                pdfDoc.Add(Confirmation);

                var Basicinformation = new Paragraph("Udział w działaniach ratowniczych w dniu " + BasicInformation[5] + " w godzinach " + BasicInformation[1] + ":" + BasicInformation[2] + " - " + BasicInformation[3] + ":" + BasicInformation[4], nameFont);
                Basicinformation.Alignment = Element.ALIGN_CENTER;
                Basicinformation.Font.Size = 12;
                Basicinformation.SpacingBefore = 10;
                pdfDoc.Add(Basicinformation);

                var PlaceandReasonInformation = new Paragraph(PlaceInformation[0] + ", ul. " + PlaceInformation[1] + " - " + ReasonInformation[1], nameFontT);
                if (PlaceInformation[1] == "")
                {
                    PlaceandReasonInformation = new Paragraph(PlaceInformation[0] + " - " + ReasonInformation[1], nameFontT);
                }
                else
                {
                    PlaceandReasonInformation = new Paragraph(PlaceInformation[0] + ", ul. " + PlaceInformation[1] + " - " + ReasonInformation[1], nameFontT);
                }

                PlaceandReasonInformation.Alignment = Element.ALIGN_CENTER;
                PlaceandReasonInformation.Font.Size = 12;
                pdfDoc.Add(PlaceandReasonInformation);

                

                pdfDoc.Add(spacer10);




                PdfPTable table = new PdfPTable(new[] { .25f, .75f, .15f, 2f, 1f });

                PdfPCell cell = new PdfPCell(new Phrase("LP", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Podmiot", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Osoby uczestniczące", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Czas udziału w działaniach", nameFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 7;
                table.AddCell(cell);


               




                int i = 0;
                while (i < Vehicle.Count)
                {
                    List<string> list = new List<string>(SqlConnectorv2.SelectFireFightersToPDF(Vehicle[i]));

                    for (int j = 1; j <= int.Parse(list[list.Count - 1]); j++)
                    {
                        if (j == 1)
                        {
                            Howmanyvehicle++;
                            cell = new PdfPCell(new Phrase(j.ToString(), nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(list[0], nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Rowspan = int.Parse(list[list.Count - 1]);
                            cell.PaddingTop = (float)(int.Parse(list[list.Count - 1]) * 8);
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase("K", nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(EmptyFirefighter(list[j]), nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            if (i == 0)
                            {
                                int paddingtop = HowManyPlaces(Vehicle);
                                cell = new PdfPCell(new Phrase(Time + " h", nameFont));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingTop = (float)(paddingtop * 8.3);
                                cell.Rowspan = 24;
                                table.AddCell(cell);
                            }

                        }
                        else if (j == 2)
                        {
                            cell = new PdfPCell(new Phrase(j.ToString(), nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase("D", nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(EmptyFirefighter(list[j]), nameFont));
                            cell.PaddingBottom = 4;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell);
                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(j.ToString(), nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase("R", nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(EmptyFirefighter(list[j]), nameFont));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 4;
                            table.AddCell(cell);
                        }

                    }






                    i++;
                }









                pdfDoc.Add(table);

                var SummaryInformation = new Paragraph("Liczba pojazdów ratowniczych : " + Howmanyvehicle + "         Liczba ratoników : " + Howmanypeople, nameFont);
                SummaryInformation.Alignment = Element.ALIGN_CENTER;
                SummaryInformation.Font.Size = 12;
                SummaryInformation.SpacingBefore = 10;

                pdfDoc.Add(SummaryInformation);
                pdfDoc.Add(spacer10);
                var Commander = new Paragraph(Head + "                                            ", nameFont);
                Commander.Alignment = Element.ALIGN_RIGHT;
                Commander.Font.Size = 12;
                Commander.Font.Color = BaseColor.GRAY;


                pdfDoc.Add(Commander);

                var CommanderInfo = new Paragraph("(Podpis kierującego działaniami ratowniczymi)                   ", nameFont);
                CommanderInfo.Alignment = Element.ALIGN_RIGHT;
                CommanderInfo.Font.Size = 12;
                CommanderInfo.Font.Color = BaseColor.BLACK;

                pdfDoc.Add(CommanderInfo);






                pdfDoc.Close();

                Howmanypeople = 0;
                Howmanyvehicle = 0;
            }
            catch
            {

                MessageBox.Show("Problem z utworzeniem nowej karty wyjazdu ( Wersja PDF ).\n Zalezany jest restart aplikacji.");
                
            }
            finally
            {
                if (pdfDoc != null)
                {
                    pdfDoc.Close();

                }
            }

            return pathintake;
        }

        #endregion




        private static string EmptyFirefighter(string firefighter)
        {
            string a = "";
            if (firefighter == "0")
            {
                return a;
            }
            else
            {
                Howmanypeople++;
                return firefighter;
            }
        }


        private static int HowManyPlaces(List<int> Vehicle)
        {
            int Howmany = 0;
            for (int i = 0; i < Vehicle.Count; i++)
            {
                Howmany += SqlConnectorv2.HowManyPlaces(Vehicle[i]);
            }
            return Howmany;
        }


       
        public static string Mount(int Mount)
        {
            if (Mount == 1)
            {
                return "Styczeń";
            }
            else if (Mount == 2)
            {
                return "Luty";
            }
            else if (Mount == 3)
            {
                return "Marzec";
            }
            else if (Mount == 4)
            {
                return "Kwiecień";
            }
            else if (Mount == 5)
            {
                return "Maj";
            }
            else if (Mount == 6)
            {
                return "Czerwiec";
            }
            else if (Mount == 7)
            {
                return "Lipiec";
            }
            else if (Mount == 8)
            {
                return "Sierpień";
            }
            else if (Mount == 9)
            {
                return "Wrzesień";
            }
            else if (Mount == 10)
            {
                return "Październik";
            }
            else if (Mount == 11)
            {
                return "Listopad";
            }
            else
            {
                return "Grudzień";
            }
        }

    }
}
