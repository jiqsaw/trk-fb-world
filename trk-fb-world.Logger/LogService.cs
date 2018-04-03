using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.EF;

namespace TurkcellFacebookDunyasi.Logger
{
    public class LogService
    {
        private static LogService _instance;
        
        private TurkcellFacebookDunyasiDb _context;
        private readonly WebServiceLogRepository _webServiceLogRepository;
        private readonly TransactionLogRepository _transactionLogRepository;

        private LogService()
        {
            _context = new TurkcellFacebookDunyasiDb();
            _webServiceLogRepository = new WebServiceLogRepository(_context);
            _transactionLogRepository = new TransactionLogRepository(_context);
        }

        public static LogService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LogService();
            }

            return _instance;
        }

        public void Log<T>(T logData) where T : class, ILog
        {
            var t = typeof(T);
            try
            {
                switch (t.Name)
                {
                    case "WebServiceLog":
                        _webServiceLogRepository.SaveAndCommit(logData as WebServiceLog);
                        break;

                    case "TransactionLog":
                        _transactionLogRepository.SaveAndCommit(logData as TransactionLog);
                        break;
                }
            }
            catch (Exception) { }
        }

        public enum LogStatus
        {
            Success,
            Failure
        }

        //Web Servis Loglari icin Naming, Cagirilan web servisin Namingi ile ayni
        //Diger loglar icin gerekirse buraya giris yapilacak.
        public enum LogDefinitions
        {
            WebServiceCall,
            ActionCall,
            Exception
        }
    }
}
