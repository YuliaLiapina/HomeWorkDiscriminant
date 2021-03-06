﻿using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDal
{
    public class Equation
    {
        [Key]
        public int Id { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Discriminant { get; set; }
        public double? FirstRoot { get; set; }
        public double? SecondRoot { get; set; }
    }
}
