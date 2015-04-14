﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class AdminGUI : Form
    {

        private bool FirstTime = true;
        private CampingLogic campingLogic ;
        private EventManagment eventManagment;

        
        

        public AdminGUI()
        {
            InitializeComponent();
            eventManagment = new EventManagment();
            eventManagment.EventCreated += addEvent;


        }

       private void btnAddUser_Click(object sender, EventArgs e)
        {
            lbUser.Items.Add(txtGebruikers.Text);
                txtGebruikers.Text = "";
            }

        private void addEvent(UserEvent userEvent)
        {
            flowEvent.Controls.Add(userEvent);
        }

        public class EventManagment
        {
            public delegate void EventCreatedEventHandeler(UserEvent userEvent);

            public event EventCreatedEventHandeler EventCreated;
            public EventManagment()
            {
                CreateDummyData();
            }
            public void CreateDummyData()
            {
                for (int i = 0; i < 10; i++)
                {
                    UserEvent userEvent = new UserEvent("EventName","Sjaak","Camping Reeendaal","Een social media event");
                    if (EventCreated != null)
                    {
                        EventCreated(userEvent);
                    }
                }
            }
        }
        public class CampingLogic
        {
            private List<string> guests;
            private decimal amount;
            private int[] Bungalows;
            private int[] Blokhutten;
            private int[] Bungalinos;
            private int[] ComfortPlaatsen;
            private int[] EigenTenten;
            private int[] Huurtentjes;
            private int[] StaCaravan;
            private int[] Invalidenaccomodatie;
            private int[] AllPlaces;
            private List<string> userList;

            public List<string> UserList { get { return userList; } }

            public CampingLogic(List<string> Guests, decimal Amount)
            {
                guests = Guests;
                amount = Amount;
                userList = new List<string>();
                EigenTenten = EigenTentenArray();
                Bungalows = BungalowArray();
                Blokhutten = BlokHuttenArray();
                Bungalinos = BungalinosArray();
                ComfortPlaatsen = ComfortPlaatsenArray();
                StaCaravan = StaCaravanArray();
                Invalidenaccomodatie = Enumerable.Range(85, 6).ToArray();
                Huurtentjes = Enumerable.Range(643, 36).ToArray();
                AllPlaces = AllPlacesArray();
                FillAllPlaces();
            }

            public void AddUser(string user)
            {
                userList.Add(user);
            }

            public bool CheckPlaceSize(decimal place, int amountofusers)
            {
                place = Convert.ToInt32(place);

                foreach (int p in Bungalows)
                {
                    if (p == place)
                    {
                        if (amountofusers > 8)
                        {
                            MessageBox.Show("Er mogen maximaal 8 personen in een bungalow verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in Bungalinos)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een bungalino verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in EigenTenten)
                {
                    if (p == place)
                    {
                        if (amountofusers > 5)
                        {
                            MessageBox.Show("Er mogen maximaal 5 personen in een eigen tent verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in Blokhutten)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een blokhut verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in ComfortPlaatsen)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen op een comfortplaats verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in Huurtentjes)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een huurtentje verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in StaCaravan)
                {
                    if (p == place)
                    {
                        if (amountofusers > 6)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een stacaravan verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (int p in Invalidenaccomodatie)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een invalidenaccomodatie verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                MessageBox.Show("Plaats niet gevonden.");
                return false;
            }

            private void FillAllPlaces()
            {
                foreach (int place in AllPlaces)
                {
            
                }
            }

            private int[] EigenTentenArray()
            {
                int[] Tenten1 = Enumerable.Range(101, 23).ToArray();
                int[] Tenten2 = Enumerable.Range(200, 14).ToArray();
                int[] Tenten3 = Enumerable.Range(401, 19).ToArray();
                int[] Tenten4 = Enumerable.Range(314, 10).ToArray();
                int[] Tenten5 = { 544, 431 };
                int[] Tenten = Tenten1.Concat(Tenten2).Concat(Tenten3).Concat(Tenten4).Concat(Tenten5).ToArray();
                return Tenten;
            }

            private int[] BungalowArray()
            {
                int[] Bungalows1 = Enumerable.Range(2, 11).ToArray();
                int[] Bungalows2 = Enumerable.Range(14, 2).ToArray();
                int[] Bungalows3 = Enumerable.Range(17, 4).ToArray();
                int[] Bungalows4 = Enumerable.Range(23, 4).ToArray();
                int[] Bungalows = Bungalows1.Concat(Bungalows2).Concat(Bungalows3).Concat(Bungalows4).ToArray();
                return Bungalows;
            }

            private int[] BlokHuttenArray()
            {
                int[] Blokhutten1 = Enumerable.Range(72, 10).ToArray();
                int[] Blokhutten2 = Enumerable.Range(91, 2).ToArray();
                int[] Blokhutten3 = Enumerable.Range(95, 2).ToArray();
                int[] Blokhutten4 = Enumerable.Range(138, 5).ToArray();
                int[] Blokhutten5 = Enumerable.Range(143, 8).ToArray();
                int[] Blokhutten6 = { 124 };
                int[] Blokhutten = Blokhutten1.Concat(Blokhutten2).Concat(Blokhutten3).Concat(Blokhutten4).Concat(Blokhutten5).Concat(Blokhutten6).ToArray();
                return Blokhutten;
            }

            private int[] BungalinosArray()
            {
                int[] Bungalinos1 = Enumerable.Range(50, 6).ToArray();
                int[] Bungalinos2 = Enumerable.Range(60, 12).ToArray();
                int[] Bungalinos3 = Enumerable.Range(101, 5).ToArray();
                int[] Bungalinos = Bungalinos1.Concat(Bungalinos2).Concat(Bungalinos3).ToArray();
                return Bungalinos;
            }

            private int[] ComfortPlaatsenArray()
            {
                int[] Comfortplaats1 = Enumerable.Range(601, 26).ToArray();
                int[] Comfortplaats2 = Enumerable.Range(432, 4).ToArray();
                int[] ComfortPlaats = Comfortplaats1.Concat(Comfortplaats2).ToArray();
                return ComfortPlaats;
            }

            private int[] StaCaravanArray()
            {
                int[] StaCaravan1 = Enumerable.Range(34, 8).ToArray();
                int[] StaCaravan2 = Enumerable.Range(125, 3).ToArray();
                int[] StaCaravan3 = Enumerable.Range(93, 2).ToArray();
                int[] StaCaravan4 = Enumerable.Range(97, 4).ToArray();
                int[] StaCaravan = StaCaravan1.Concat(StaCaravan2).Concat(StaCaravan3).Concat(StaCaravan4).ToArray();
                return StaCaravan;
            }

            private int[] AllPlacesArray()
            {
                Bungalows.Concat(Blokhutten)
                    .Concat(Bungalinos)
                    .Concat(ComfortPlaatsen)
                    .Concat(EigenTenten)
                    .Concat(Huurtentjes)
                    .Concat(StaCaravan)
                    .Concat(Invalidenaccomodatie)
                    .ToArray();
                return null;
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {/*
            List<string> userList = new List<string>();
            foreach (string s in lbUser.Items)
            {
                userList.Add(s);
            }
            campingLogic = new CampingLogic(userList, nmrPlaats.Value);
            int lines = userList.Count();
            if (campingLogic.CheckPlaceSize(nmrPlaats.Value, lines))
            {
                nmrPlaats.Value = 0;
                txtGebruikers.Text = "";
            } */
        }

        private void btnReserve_Click()
        {

        }

      
       
    
    }
    
}