using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab6.Core.Models
{
    [Table("Sessions")]
    public class Session
    {
        public enum MovieType
        {
            _3D,
            _2D
        }

        [Key]
        public int ID { get; set; }
        public string FilmName { get; set; }
        public DateTime BeginTime { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public double LoungeNum { get; set; }
        public int CinemaID { get; set; }
        public bool OnStock { get; set; }
        public double Cost { get; set; }

        public Session() { }
        public Session
        (
            string filmName, DateTime beginTime, double loungeNum, int cinemaID,
            string description, int duration,  double cost
        )
        {
            OnStock = true;
            FilmName = filmName;
            BeginTime = beginTime;
            LoungeNum = loungeNum;
            CinemaID = cinemaID;
            Duration = duration;
            Description = description;
            Cost = cost;
        }
    }
}
