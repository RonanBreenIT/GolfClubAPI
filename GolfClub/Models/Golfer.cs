using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GolfClub.Models
{
    public enum MemberType { Youth, FullTime, PartTime, Patron, Student };
    public class Golfer
    {
        [Key]
        public int GUI { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public MemberType Membership { get; set; }

        private int handicap;
        public int Handicap
        {
            get
            {
                return this.handicap;
            }
            set
            {
                if (value > 28)
                {
                    this.handicap = 28;
                }
                else if (value < 0)
                {
                    this.handicap = 0;
                }
                else
                {
                    this.handicap = value;
                }
            }
        }
        

        public DateTime DateJoined { get; set; }

        public int YearlyFees { get; set; }

        public Golfer()
        {
        }

        public Golfer(int _GUI, string _firstname, string _surname, int _hcap, DateTime _joined, MemberType _type)
        {
            this.GUI = _GUI;
            this.FirstName = _firstname;
            this.Surname = _surname;
            this.Handicap = _hcap;
            this.DateJoined = _joined;
            this.Membership = _type;
        }
    }
}