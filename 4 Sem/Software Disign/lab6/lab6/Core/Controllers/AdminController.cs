using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Core.Models;

namespace lab6.Core.Controllers
{
    class ElementIsExistException : Exception
    {
        public ElementIsExistException() : base("Данный элемент уже существует в базе данных.")
        {

        }
    }

    class AdminController
    {
        public static void AddNewSession(Session session)
        {
            CinemaContext.context.Sessions.Add(session);
            CinemaContext.context.SaveChanges();
                
            for (int i = 0; i < 16; i++)
            {
                CinemaContext.context.Tickets.Add(new Ticket
                (
                    session.FilmName,
                    session.BeginTime,
                    session.LoungeNum,
                    session.CinemaID,
                    i+1,
                    session.Cost,
                    session.ID
                ));
            }

            CinemaContext.context.SaveChanges();
        }

        public static void AddCinema(Cinema cinema)
        {
            if (CinemaContext.context.Cinemas.FirstOrDefault(x=>x.Name == cinema.Name) != null)
                throw new ElementIsExistException();

            CinemaContext.context.Cinemas.Add(cinema);
            CinemaContext.context.SaveChanges();
        }
    }
}
