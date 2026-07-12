using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public  class ListTundishStandard : ORM.TundishStandard
    {
        public string tsNombreCompleto
        {
            get
            {
                return tsId.ToString() + "    [" + tsCierre1.Trim() + " - " + tsCierre2.Trim() + " - " + tsCierre3.Trim() + " - " + tsCierre4.Trim() + " - " + tsCierre5.Trim() + " - " + tsCierre6.Trim() + "]";
            }
        }

    }
}
