﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int positionId { get; set; }
        public string email { get; set; }
        public int companyId { get; set; }

        public UserDTO(int id, string name, string surname, int positionId, string email, int companyId)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.positionId = positionId;
            this.email = email;
            this.companyId = companyId;
        }
    }
}
