using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary.Models
{
    public class Note
    {
        public string header;
        public string description;

        public Note(string _header, string _description)
        {
            header = _header;
            description = _description;
        }

        public string Header
        {
            get => header;
            set => header = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }
    }
}
