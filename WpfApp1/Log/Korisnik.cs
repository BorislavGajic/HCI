﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Log
{
    public class Korisnik
    {
        private string korisnickoIme;
        private string lozinka;

        public Korisnik()
        {

        }

        public Korisnik(string k, string l)
        {
            this.korisnickoIme = k;
            this.lozinka = l;
        }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }

    }
}
