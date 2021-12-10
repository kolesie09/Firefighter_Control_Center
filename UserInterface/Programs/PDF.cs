using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Imaging;
using Tekla.Structures.Model;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface
{
    class PDF
    {
     
        public static void CreatePDF (int NumberDepartureCard, string DateDepartureCard, int MountDepartureCard, int YearDepartureCard, string HourDepartureCard, string HourArrivalCard, string TimeDeparture, string PCity, string PStreet, string Reason, string CommanderD, string D499z01, string D499z15, string D499z18, string D499z19, string C499z01, string C499z15, string C499z18, string C499z19, string F499z011, string F499z012, string F499z013, string F499z014, string F499z151, string F499z152, string F499z153, string F499z154, string F499z181, string F499z182, string F499z183, string F499z191, string F499z192, string F499z193, string F499z194)
        {
            Font nameFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 7);
            Font nameFontT = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 7, Font.BOLD);
            try
            {

                var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                try
                {
                    string pathintake = "";
                    if (PStreet == "")
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + Mount(MountDepartureCard) + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + PCity + " - " + Reason + ".pdf";
                    }
                    else
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + Mount(MountDepartureCard) + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + PCity + ", ul. " + PStreet + " - " + Reason + ".pdf";
                    }
                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }
                catch
                {
                    string path = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + Mount(MountDepartureCard) + " Miesiąc";
                    System.IO.Directory.CreateDirectory(path);
                    string pathintake = "";
                    if (PStreet == "")
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + Mount(MountDepartureCard) + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + PCity + " - " + Reason + ".pdf";
                    }
                    else
                    {
                        pathintake = $"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + Mount(MountDepartureCard) + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + PCity + ", ul. " + PStreet + " - " + Reason + ".pdf";
                    }
                    
                    PdfWriter.GetInstance(pdfDoc, new FileStream(pathintake, FileMode.OpenOrCreate));
                }

                pdfDoc.Open();

                var imagepath = @"C:\OSP\logo.png";
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
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
                

                
                var PdfNumberDepartureCard = new Paragraph(NumberDepartureCard + "/" + YearDepartureCard + "              ", nameFontT);
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

                var BasicInformation = new Paragraph("Udział w działaniach ratowniczych w dniu " + DateDepartureCard + " w godzinach " + HourDepartureCard + " - "+HourArrivalCard, nameFont);
                BasicInformation.Alignment = Element.ALIGN_CENTER;
                BasicInformation.Font.Size = 12;
                BasicInformation.SpacingBefore = 10;
                pdfDoc.Add(BasicInformation);

                var PlaceandReasonInformation = new Paragraph(PCity + ", ul. " + PStreet + " - " + Reason, nameFontT);
                if (PStreet == "")
                {
                    PlaceandReasonInformation = new Paragraph(PCity + " - " + Reason, nameFontT);
                }
                else
                {
                    PlaceandReasonInformation = new Paragraph(PCity + ", ul. " + PStreet + " - " + Reason, nameFontT);
                }
                
                PlaceandReasonInformation.Alignment = Element.ALIGN_CENTER;
                PlaceandReasonInformation.Font.Size = 12;
                pdfDoc.Add(PlaceandReasonInformation);

                //var Test = new Paragraph("Potwierdzenie");
                //Test.Alignment = Element.ALIGN_CENTER;
                //Test.Font.Size = 20;
                //pdfDoc.Add(Test);

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

                int NumberFF = 0;
                int NumberC = 0;
                int HeightTime()
                {
                    int i = 0;
                    
                    if(D499z01 != "")
                    {
                        if (D499z15 != "")
                        {
                            if (D499z18 != "")
                            {
                                if (D499z19 != "")
                                {
                                    i = 210;
                                }
                                else
                                {
                                    i = 155;
                                }
                                
                            }
                            else
                            {
                                i = 100;
                            }
                            
                        }
                        else
                        {
                            i = 45;
                        }
                        
                    }
                    else if(D499z15 != "")
                    {
                        if (D499z18 != "")
                        {
                            if (D499z19 != "")
                            {
                                i = 155;
                            }
                            else
                            {
                                i = 100;
                            }

                        }
                        else
                        {
                            i = 45;
                        }
                    }
                    else if(D499z18 != "")
                    {
                        if (D499z19 != "")
                        {
                            i = 100;
                        }
                        else
                        {
                            i = 45;
                        };
                    }
                    else if(D499z19 != "")
                    {
                        i = 45;
                    }
                    
                    return i;
                }
                // 1 = 45 2 = 100 3=155 4 = 210
                int Time = 0;
                int HowManyPepole = 0;
                #region 499z01
                if(D499z01 != "")
                {
                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("499z01", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Rowspan = 6;
                    cell.PaddingTop = 45;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("K", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(D499z01, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    NumberC++;
                    table.AddCell(cell);
                    if(Time == 0)
                    {
                        cell = new PdfPCell(new Phrase(TimeDeparture + " h", nameFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingTop = HeightTime();
                        cell.Rowspan = 24;
                        table.AddCell(cell);
                        Time++;
                    }
                    

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("D", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(C499z01, nameFont));
                    cell.PaddingBottom = 4;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z011, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z012, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z013, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z014, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                }
                    
                #endregion
                #region 499z15
                if(D499z15 != "")
                {
                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("499z15", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Rowspan = 6;
                    cell.PaddingTop = 45;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("K", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(D499z15, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    if (Time == 0)
                    {
                        cell = new PdfPCell(new Phrase(TimeDeparture + " h", nameFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingTop = HeightTime();
                        cell.Rowspan = 24;
                        table.AddCell(cell);
                        Time++;
                    }


                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("D", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(C499z15, nameFont));
                    cell.PaddingBottom = 4;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z151, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z152, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z153, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z154, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                }
                
                #endregion
                #region 499z18
                if(D499z18 != "")
                {
                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("499z18", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Rowspan = 5;
                    cell.PaddingTop = 35;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("K", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(D499z18, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    if (Time == 0)
                    {
                        cell = new PdfPCell(new Phrase(TimeDeparture + " h", nameFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingTop = HeightTime();
                        cell.Rowspan = 24;
                        table.AddCell(cell);
                        Time++;
                    }


                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("D", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(C499z18, nameFont));
                    cell.PaddingBottom = 4;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z181, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z182, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z183, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                }

                #endregion
                #region 499z19
                if(D499z19 != "")
                {
                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("499z19", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Rowspan = 6;
                    cell.PaddingTop = 45;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("K", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(D499z19, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    if (Time == 0)
                    {
                        cell = new PdfPCell(new Phrase(TimeDeparture + " h", nameFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingTop = HeightTime();
                        cell.Rowspan = 24;
                        table.AddCell(cell);
                        Time++;
                    }


                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("D", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(C499z19, nameFont));
                    cell.PaddingBottom = 4;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z191, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 3;
                    cell.PaddingTop = -1;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z192, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z193, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);

                    HowManyPepole++;
                    cell = new PdfPCell(new Phrase(HowManyPepole.ToString(), nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("R", nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(F499z194, nameFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 4;
                    table.AddCell(cell);
                }
                #endregion

                pdfDoc.Add(table);

                var SummaryInformation = new Paragraph("Liczba pojazdów ratowniczych : "+NumberC+"         Liczba ratoników : "+ HowManyPepole, nameFont);
                SummaryInformation.Alignment = Element.ALIGN_CENTER;
                SummaryInformation.Font.Size = 12;
                SummaryInformation.SpacingBefore = 10;
                
                pdfDoc.Add(SummaryInformation);
                pdfDoc.Add(spacer10);
                var Commander = new Paragraph(CommanderD+"                                            ", nameFont);
                Commander.Alignment = Element.ALIGN_RIGHT;
                Commander.Font.Size = 12;
                Commander.Font.Color = BaseColor.GRAY;

                
                pdfDoc.Add(Commander);

                var CommanderInfo = new Paragraph("(Podpis kierującego działaniami ratowniczymi)                   ", nameFont);
                CommanderInfo.Alignment = Element.ALIGN_RIGHT;
                CommanderInfo.Font.Size = 12;
                CommanderInfo.Font.Color = BaseColor.BLACK;

                pdfDoc.Add(CommanderInfo);

                
                HowManyPepole = 0;
                
                
                
                pdfDoc.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Coś poszło nie tak");
                MessageBox.Show(e.ToString());
            }
        }

        private int HeightTime()
        {
            int i = 0;

            return i;
        }

        public static string Mount(int Mount)
        {
            if(Mount == 1)
            {
                return "Styczeń";
            }
            else if(Mount == 2)
            {
                return "Luty";
            }
            else if(Mount == 3)
            {
                return "Marzec";
            }
            else if(Mount == 4)
            {
                return "Kwiecień";
            }
            else if(Mount == 5)
            {
                return "Maj";
            }
            else if(Mount == 6)
            {
                return "Czerwiec";
            }
            else if(Mount == 7)
            {
                return "Lipiec";
            }
            else if(Mount == 8)
            {
                return "Sierpień";
            }
            else if(Mount == 9)
            {
                return "Wrzesień";
            }
            else if(Mount == 10)
            {
                return "Październik";
            }
            else if(Mount == 11)
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
