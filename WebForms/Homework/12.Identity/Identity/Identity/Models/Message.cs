﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Text { get; set; }
    }
}