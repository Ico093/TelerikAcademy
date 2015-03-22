using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kino.Interfaces;
using System.Threading;
using System.Globalization;
using System.IO;

namespace Kino.Classes
{
    class Accountant : IStorable
    {
        //Static constructor
        static Accountant()
        {
            soldTickets = new List<Ticket>();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
        //Instance singleton
        private static Accountant instance;

        public static Accountant Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Accountant();
                }
                return instance;
            }
            private set { instance = value; }
        }

        //File text devidors, helping spliting the text after reading
        private readonly char[] charDevidors = { '#', '\n', '\r' };

        //soldTickets
        private static List<Ticket> soldTickets;

        public static List<Ticket> SoldTickets
        {
            get { return soldTickets; }
            set { soldTickets = value; }
        }

        public void AddTicket(int ticketsCount, string projectionHour, string purchaseDay, double totalPrice)
        {
            Accountant.Instance.GetInformation();
            SoldTickets.Add(new Ticket(ticketsCount, projectionHour, purchaseDay, totalPrice));
        }

        //Total Statistic
        private TotalStatistic totalStatistic;

        public TotalStatistic TotalStatistic
        {
            get { return totalStatistic; }
            set { totalStatistic = value; }
        }
        //Discounted Statistic
        private DiscountStatistic discountedStatistic;

        public DiscountStatistic DiscountedStatistic
        {
            get { return discountedStatistic; }
            set { discountedStatistic = value; }
        }
        //Loyal Statistic
        private LoyalStatistic loyalStatistic;

        public LoyalStatistic LoyalStatistic
        {
            get { return loyalStatistic; }
            set { loyalStatistic = value; }
        }

        public void GetInformation()
        {
            try
            {
                StreamReader fileReader = new StreamReader("DataFiles/AccountantDataBase.txt");
                if (fileReader != null)
                {
                    using (fileReader)
                    {
                        List<Ticket> tickets = new List<Ticket>();
                        //Total Statistic
                        string[] firstRowElements = fileReader.ReadLine().Split(new char[] { charDevidors[0] }, StringSplitOptions.RemoveEmptyEntries);
                        TotalStatistic = new TotalStatistic(double.Parse(firstRowElements[0]), firstRowElements[1], firstRowElements[2]);
                        //Discounted Statistic
                        DiscountedStatistic = new DiscountStatistic(int.Parse(fileReader.ReadLine()));
                        //Loyal Statistic
                        string[] thirdRowElements = fileReader.ReadLine().Split(new char[] { charDevidors[0] }, StringSplitOptions.RemoveEmptyEntries);
                        LoyalStatistic = new LoyalStatistic
                        {
                            LoyalCount = ulong.Parse(thirdRowElements[0]),
                            LoyalTicketsCount = ulong.Parse(thirdRowElements[1])
                        };

                        //Tickets
                        string[] restFileContent = fileReader.ReadToEnd().Split(new char[] { charDevidors[1], charDevidors[2] }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var currentTicket in restFileContent)
                        {
                            string[] ticketElements = currentTicket.Split(new char[] { charDevidors[0] }, StringSplitOptions.RemoveEmptyEntries);
                            tickets.Add(new Ticket(int.Parse(ticketElements[0]), ticketElements[1], ticketElements[2], double.Parse(ticketElements[3])));
                        }
                        SoldTickets = tickets;
                    }
                }
            }
            catch (Exception)
            {
                this.TotalStatistic = new TotalStatistic(0, "", "");
                this.DiscountedStatistic = new DiscountStatistic(0);
                this.LoyalStatistic = new LoyalStatistic()
                {
                    LoyalCount = 0,
                    LoyalTicketsCount = 0
                };
            }
        }

        public void SetInformation()
        {
            StringBuilder fileContent = new StringBuilder();

            if (SoldTickets != null)
            {
                //Total statistic
                fileContent.Append(this.TotalStatistic.TotalIncome + charDevidors[0].ToString() + this.TotalStatistic.BusiestDay + charDevidors[0]
                                 + this.TotalStatistic.BusiestHour + Environment.NewLine);
                //Discounted statistic
                fileContent.Append(this.DiscountedStatistic.DiscountedTicketsCount + Environment.NewLine);
                //Loyal statistic
                fileContent.Append(this.LoyalStatistic.LoyalCount + charDevidors[0].ToString() + this.LoyalStatistic.LoyalTicketsCount + Environment.NewLine);
                //Sold Tickets
                foreach (Ticket currentTicket in SoldTickets)
                {
                    fileContent.Append(currentTicket.TicketsCount + charDevidors[0].ToString() +
                                       currentTicket.ProjectionHour + charDevidors[0] +
                                       currentTicket.PurchaseDay + charDevidors[0] +
                                       currentTicket.TotalPrice + Environment.NewLine);
                }

                //Writing to file
                StreamWriter fileWriter = new StreamWriter("DataFiles/AccountantDataBase.txt", false);

                if (fileWriter != null)
                {
                    using (fileWriter)
                    {
                        fileWriter.Write(fileContent);
                    }
                }

            }
            else
            {

            }
        }

        //Calculate Loyal statistic
        public void CalculateLoyalStatistic(ulong loyalTicketsCount)
        {

            this.LoyalStatistic = new LoyalStatistic()
            {
                LoyalCount = 1 + LoyalStatistic.LoyalCount,
                LoyalTicketsCount = loyalTicketsCount + LoyalStatistic.LoyalTicketsCount
            };
        }
        //Calculate Discounted statistic
        public void CalculateDiscountedStatistic(int discountedTicketsCount)
        {
            this.DiscountedStatistic = new DiscountStatistic(discountedTicketsCount + DiscountedStatistic.DiscountedTicketsCount);
            Accountant.Instance.SetInformation();
        }
        //Calculate Total statistic
        public void CalculateTotalStatistic(int totalIncome)
        {
            this.TotalStatistic = new TotalStatistic(totalIncome + this.TotalStatistic.TotalIncome, GetBusiestDay(), GetBusiestHour());
        }

        public static string GetBusiestDay()
        {
            if (SoldTickets.Count > 0)
            {
                List<int> business = new List<int>
                {
                    0,0,0,0,0,0,0
                };
                foreach (Ticket currentTicket in SoldTickets)
                {
                    switch (currentTicket.PurchaseDay)
                    {
                        case "Monday": business[0]++; break;
                        case "Tuesday": business[1]++; break;
                        case "Wednesday": business[2]++; break;
                        case "Thursday": business[3]++; break;
                        case "Friday": business[4]++; break;
                        case "Saturday": business[5]++; break;
                        case "Sunday": business[6]++; break;
                        default:
                            break;
                    }
                }
                int maxIndex = business.IndexOf(business.Max());
                switch (maxIndex)
                {
                    case 0: return "Monday";
                    case 1: return "Tuesday";
                    case 2: return "Wednesday";
                    case 3: return "Thursday";
                    case 4: return "Friday";
                    case 5: return "Saturday";
                    case 6: return "Sunday";
                    default: return null;
                }
            }
            else
            {
                return "No Statistic";
            }
        }

        public static string GetBusiestHour()
        {
            Dictionary<string, int> business = new Dictionary<string, int>();

            foreach (Ticket currentTicket in SoldTickets)
            {
                if (business.ContainsKey(currentTicket.ProjectionHour))
                {
                    var element = business.Where(x => x.Key == currentTicket.ProjectionHour).Select(x => x).FirstOrDefault();
                    business.Remove(element.Key);
                    business.Add(element.Key, element.Value + 1);
                }
                else
                {
                    business.Add(currentTicket.ProjectionHour, 1);
                }
            }
            
            return business.Count > 0 ? business.Keys.Max() : "No bought tickest!";
        }

    }
}
