using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Core.Models;

namespace lab6.Core.Controllers
{
    static class BankController
    {
        public static void BuyTickets(Ticket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                tickets[i].OwnerID = MainController.CurrentUser.ID;
                MainController.CurrentUser.AmountSpent += tickets[i].Cost;
            }
            MainController.SetTicketsStatus(Ticket.TicketStatus.BoughtOut, tickets);
            MainController.SetUserClientLevel();
            CinemaContext.context.SaveChanges();
        }

        public static void ReturnTickets(Ticket ticket)
        {
            ticket.OwnerID = -1;
            MainController.CurrentUser.AmountSpent -= ticket.Cost;
            MainController.SetTicketsStatus(Ticket.TicketStatus.OnlineAvailable, new Ticket[]{ticket});
            MainController.SetUserClientLevel();
            CinemaContext.context.SaveChanges();
        }
    }
}
