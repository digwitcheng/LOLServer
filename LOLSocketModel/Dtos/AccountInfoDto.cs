using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLSocketModel.Dtos
{
    [Serializable]
    public class AccountInfoDto
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
