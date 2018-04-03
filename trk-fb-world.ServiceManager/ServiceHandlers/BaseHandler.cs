using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.Logger;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class BaseHandler
    {
        protected Loader WebServiceLoader { get { return Loader.GetInstance(); } }
        protected LogService Logger { get { return LogService.GetInstance(); } }

        public string PageToken
        {
            get
            {
                return Loader.GetInstance().PageToken;
            }

            set
            {
                Loader.GetInstance().PageToken = value;
            }
        }

        public string TcellSession
        {
            get
            {
                return Loader.GetInstance().Sid;
            }

            set
            {
                Loader.GetInstance().Sid = value;
            }
        }
    }
}
