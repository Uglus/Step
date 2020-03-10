﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;

namespace ProjectCinema
{
    public partial class formTickets : Form
    {
        DataManager dm = new DataManager();
        public formTickets()
        {
            InitializeComponent();
            LoadSessions();
        }

        public void LoadSessions()
        {
            foreach (var s in dm.sessions)
            {
                boxSessions.Items.Add(s.DateTime);
            }
        }

        private void boxSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryName = "SELECT h.Name " +
                               "FROM Session s " +
                               "JOIN Hall h on s.HallId = h.Id";


        }
    }
}
