using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamTest
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set;  }
        public string Author { get; set;  }
    }
}
