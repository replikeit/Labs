using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace lab6.Core.Models
{
    
 
    [Table("Tickets")]
    public class Ticket
    {
        
        public enum TicketStatus
        {
            OnlineAvailable,
            BoughtOut,
            Selected,
            OfflineAvailable
        }
        
        [Key]
        public int ID { get; set; }

        public int OwnerID { get; set; }
        public string FilmName { get; set; }
        public DateTime BeginTime { get; set; }
        public double LoungeNum { get; set; }
        public int CinemaID { get; set; }
        public int SessionID { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public double Cost { get; set; }
        public TicketStatus StatusOfTicket { get; set; }

        public Ticket() { }
        public Ticket
        (
            string filmName, DateTime beginTime, double loungeNum, int cinemaID,
             int place, double cost, int sessionID
        )
        {
            SessionID = sessionID;
            FilmName = filmName;
            BeginTime = beginTime;
            LoungeNum = loungeNum;
            StatusOfTicket = TicketStatus.OnlineAvailable;
            CinemaID = cinemaID;
            Place = place;
            Cost = cost;
            OwnerID = -1;
            if (place > 11)
            {
                Row = 4;
            }
            else if (place > 7)
            {
                Row = 3;
            }
            else if (place > 3)
            {
                Row = 2;
            }
            else
            {
                Row = 1;
            }
        }
    }
}
