﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models.Clients
{
    public class ClientAccessInfo : Client
    {
        public string PassportSerie { get; set; }
        public string PassportNumber { get; set; }

        public ClientAccessInfo()
        {

        }
        public ClientAccessInfo(Client client)
            : base(client.Firstname, client.Lastname, client.Patronymic, client.PhoneNumber, client.SeriesAndNumberOfPassport, client.TimeOfChanging, client.WorkerMakedChange)
        {
            PassportSerie = SeriesAndNumberOfPassport.Serie.ToString();
            PassportNumber = SeriesAndNumberOfPassport.Number.ToString();
            Id = client.Id;
        }
    }
}
