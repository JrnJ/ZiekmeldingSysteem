using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiekmeldingSysteem.Classes
{
    public class MailData
    {
        [JsonProperty("Mail")]
        public string Mail { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
