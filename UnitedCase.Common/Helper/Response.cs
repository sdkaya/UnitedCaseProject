﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedCase.Common.Helper
{

    public class Response<T>
    {
        public int Status { get; set; }
        public bool isSuccess { get; set; }
        public string Message { get; set; } = "";
        public T Data { get; set; }
        public List<T> List { get; set; }


    }
}
