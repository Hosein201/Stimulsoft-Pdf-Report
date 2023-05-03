using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Export;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            GetReport();
            Console.WriteLine("by, World!");
        }

        private static void GetReport()
        {
            var fileName = @"D:\GitHub\ConsoleApp2\Report.mrt";

            using Stream fs = File.OpenRead(fileName);
            var report = new StiReport();
            report.Load(fs);


            var x = new List<Ticket> {new Ticket
            {
                Destination = "تهران",
                FullFamily = "حسین گل محمدی",
       
                Origin = "مشهد",
                OriginMoveTime = "16:15",
                WagonNumber = "11",
                SeatNumber = "5",
                TrainNumber = "197",
                WagonTypeName = "5 ستاره فدک - سلامت",
                TimeOfArrivalToDestination = "03:45",
                TariffName = "تمام-مسافرین عادی",
                StationPrice = "88.000",
                TicketPrice = "5.912.000",
                Price = "6.000.000",
                TicketDate = "1402/02/06",
            
                MoveDate = "1402/02/06 چهار شنبه",
                SecurityNumber = "425198188",
                TicketSeries = "1",
                TicketNumber = "635100440"
            } ,
            new Ticket
            {
                Destination = "تهران",
                FullFamily = "حسین گل محمدی2",
         
                Origin = "مشهد",
                OriginMoveTime = "16:15",
                WagonNumber = "11",
                SeatNumber = "5",
                TrainNumber = "197",
                WagonTypeName = "5 ستاره فدک - سلامت",
                TimeOfArrivalToDestination = "03:45",
                TariffName = "تمام-مسافرین عادی",
                StationPrice = "88.000",
                TicketPrice = "5.912.000",
                Price = "6.000.000",
                TicketDate = "1402/02/06",
             
                MoveDate = "1402/02/06 چهار شنبه",
                SecurityNumber = "425198188",
                TicketSeries = "1",
                TicketNumber = "635100440"
            }};


            report.Dictionary.Clear();
            report.RegData("Ticket",x);
            report.RegData("TicketFooter", new fo { FullPrice ="100000" , TotalRows ="2"});
            report.Dictionary.Synchronize();      
            report.Compile();
            report.Render();


            var setting = new StiPdfExportSettings
            {
                ImageQuality = 2f,
                ImageResolution = 300,
                EmbeddedFonts = false,
                UseUnicode = true,
                ImageFormat = StiImageFormat.Color,
                StandardPdfFonts = true,
                Compressed=true
            };

            //report.NeedsCompiling = false;
            //report.IsRendered = true;

            //foreach (StiPage page in report.RenderedPages.Items)
            //{
            //    report.RenderedPages.Add(page);
            //}

            report.ExportDocument(StiExportFormat.Pdf, "D:\\GitHub\\ConsoleApp2\\Report.pdf", setting);
        }
    }

    class Ticket
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string OriginMoveTime { get; set; }
        public string FullFamily { get; set; }
        public string WagonNumber { get; set; }
        public string SeatNumber { get; set; }
        public string TrainNumber { get; set; }
        public string WagonTypeName { get; set; }
        public string TimeOfArrivalToDestination { get; set; }
        public string TariffName { get; set; }
        public string StationPrice { get; set; }
        public string TicketPrice { get; set; }
        public string Price { get; set; }
        public string TicketDate { get; set; }

        public string MoveDate { get; set; }
        public string SecurityNumber { get; set; }
        public string TicketSeries { get; set; }
        public string TicketNumber { get; set; }
    }

     class fo
    {
        public string TotalRows { get; set; }
        public string FullPrice { get; set; }
    }
         
}