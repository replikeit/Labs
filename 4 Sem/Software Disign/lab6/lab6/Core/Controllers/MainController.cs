using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Core.Models;

namespace lab6.Core.Controllers
{
    static class MainController 
    {
        public static User CurrentUser { get; private set; }

        public static Ticket[] GetAllTickets()=>
            CinemaContext.context.Tickets.Where(x => x.BeginTime > DateTime.Now).ToArray();

        public static Session[] GetAvailableSessions()=>
            CinemaContext.context.Sessions.Where(x => x.BeginTime > DateTime.Now).ToArray();

        public static Cinema GetCinemaByName(string name)
        {
            var item = CinemaContext.context.Cinemas.FirstOrDefault(x => x.Name == name);
            if (item == null)
                throw new NullReferenceException();

            return item;
        }

        public static void SetTicketsStatus(Ticket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].StatusOfTicket == Ticket.TicketStatus.OnlineAvailable)
                {
                    if ((tickets[i].BeginTime - DateTime.Now).TotalMinutes < 30)
                        tickets[i].StatusOfTicket = Ticket.TicketStatus.OfflineAvailable;
                }
            }

            CinemaContext.context.SaveChanges();
        }

        public static void SetUserClientLevel()
        {
            if (CurrentUser.AmountSpent < 5000)
                CurrentUser.LevelOfClient = User.ClientLevel.Common;
            else if (CurrentUser.AmountSpent < 15000)
                CurrentUser.LevelOfClient = User.ClientLevel.Regular;
            else
                CurrentUser.LevelOfClient = User.ClientLevel.VIP;

            CinemaContext.context.SaveChanges();
        }

        public static Cinema[] GetAllCinemas() =>
            CinemaContext.context.Cinemas.ToArray();

        public static Cinema GetCinemaByID(int id) => CinemaContext.context.Cinemas.Find(id);

        public static bool AddNewUser(User user)
        {
            if (CinemaContext.context.Users.FirstOrDefault(x =>
                x.Login == user.Login) != null)
                return false;

            CinemaContext.context.Users.Add(user);
            CinemaContext.context.SaveChanges();
            CurrentUser = user;

            return true;
        }

        public static Ticket[] GetTickets(Session session) =>
            CinemaContext.context.Tickets.Where(x=>x.SessionID == session.ID).ToArray();

        public static User AuthenticationUser(string login, string password)
        {
            CurrentUser = CinemaContext.context.Users.FirstOrDefault(x =>
                x.Login == login && x.Password == password);
            return CurrentUser;
        }

        public static void SetTicketsStatus(Ticket.TicketStatus status, Ticket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
                tickets[i].StatusOfTicket = status;
            CinemaContext.context.SaveChanges();
        }
    }
}
