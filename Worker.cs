using System.Data.SqlTypes;
using System;
using System.Numerics;
using System.DateTime;

using Capgemini.Invent.DeliveryPulse.Intranet.Business.EMonitoring;
using Capgemini.Invent.DeliveryPulse.Intranet.Entity.DTO;
using Capgemini.Invent.DeliveryPulse.Intranet.Entity.Persistence;
using Capgemini.Invent.DeliveryPulse.Intranet.Interface.Data;
using Capgemini.Invent.DeliveryPulse.Intranet.Interface.Data.Repository;
using Capgemini.Invent.DeliveryPulse.Intranet.Interface.EMonitoring;


namespace Capgemini.Invent.DeliveryPulse.Intranet.Job.MasterDataSync
{
    public class Worker : BackgroundService
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly ILogger<Worker> _logger;
        private readonly IEMonitoringWebApi _eMonitoringWebApi;
        private readonly IRepository<Engagement> _repositoryEngagement;
        private readonly IRepository<Country> _repositoryCountry;
        private readonly IRepository<Industry> _repositoryIndustry;
        private readonly IUnitOfWork _unitOfWork;
#pragma warning restore IDE0052 // Remove unread private members

        public Worker(ILogger<Worker> logger, IEMonitoringWebApi eMonitoringWebApi,
            IRepository<Engagement> repositoryEngagement,
            IRepository<Country> repositoryCountry,
            IRepository<Industry> repositoryIndustry,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _eMonitoringWebApi = eMonitoringWebApi;
            _repositoryEngagement = repositoryEngagement;
            _repositoryCountry = repositoryCountry;
            _repositoryIndustry = repositoryIndustry;
            _unitOfWork = unitOfWork;
        }

        public object EngagementId { get; private set; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Leggere engagements tramite API _eMonitoringWebApi --> GetEngagementsChangesAsync(DatTime)

            //EngagementId ==> E3DID

            //Per ogni engagement inserire o aggiornare il relativo record su tabella Engagements tramite IRepository<Engagement>
            //Per inserire un engagement recuperare id chiave esterna delle entities Country e Industry tramite i relativi IRepository

            //Query di esempio
            var query = new ReadOnlySpecification<Country>();
            query.AddFilter(t => t.Iso31661Alpha2 == "IT");
            var tipoCountry = await IRepository<Country>.FindOneAsync(query, stoppingToken);

            var queryIndustry = new ReadOnlySpecification<Industry>();
            queryIndustry.AddFilter(t => t.Name == "IN");
            var tipoIndustry = await IRepository<Industry>.FindOneAsync(queryIndustry, stoppingToken);

            var EngagementId = new ReadOnlySpecification<Engagement>();
            EngagementId.AddFilter(t => t.EngName == "BU");
            var EngagementId = await IRepository<Engagement>.FindOneAsync(EngagementId, stoppingToken);
            //Chiedere per l'inserimento dell'engagement
           
                EngagementId = EngagementId.GetInt();
            int Industry = tipoIndustry.GetValue();
            int Country =  tipoCountry.GetValue();
            //       account character varying(256) COLLATE pg_catalog."default" NOT NULL,
            int budget = int.GetInt();
            Varying em_usernamev = em_Usernamev.GetVarying();
            //character varying(128) COLLATE pg_catalog."default" NOT NULL,
            Varying em_name = em_name.GetVarying32();
            //character varying(256) COLLATE pg_catalog."default" NOT NULL,
            Varying em_mail = em_mail.GetVarying32();
            //character varying(128) COLLATE pg_catalog."default" NOT NULL,
            Varying delivery_executive_username = delivery_executive_username.getVarying32();
            //character varying(128) COLLATE pg_catalog."default" NOT NULL,
            Varying delivery_executive_name = delivery_executive_name.getVarying32();
            //character varying(256) COLLATE pg_catalog."default" NOT NULL,
            Varying delivery_executive_mail = delivery_executive_mail.getVarying32();
            //character varying(128) COLLATE pg_catalog."default" NOT NULL,
            varying account_manager_username = account_manager_username.getVarying32();
            //character varying(128) COLLATE pg_catalog."default" NOT NULL,
            varying account_manager_name = account_manager_name.getVarying32();
            //character varying(256) COLLATE pg_catalog."default" NOT NULL,
            varying account_manager_mail = account_manager_mail.getVarying32();
            //character varying(128) COLLATE pg_catalog."default" NOT NULL,
            IRepository<Engagement>.Equals(IEMonitoringWebApi.GetEngagementsChangesAsync(Now.DateTime, tipoCountry, tipoIndustry));

            foreach (_repositoryEngagement in IEMonitoringWebApi)
            {
                
                IRepository<Engagement>.Add(EngagementId,
                                          Industry,
                                          Country,
                                          em_usernamev,
                                          em_name,
                                          em_mail,
                                          delivery_executive_username,
                                          delivery_executive_name,
                                          delivery_executive_mail,
                                          account_manager_name,
                                          account_manager_username,
                                          account_manager_mail,
                                          budget);
            }
            IRepository<Engagement>.Equals(IEMonitoringWebApi.GetEngagementsChangesAsync(Now.DateTime, tipoCountry, tipoIndustry));

            foreach (_repositoryEngagement in IEMonitoringWebApi)
            {
                IRepository<Engagement>.Update(EngagementId,
                                          Industry,
                                          Country,
                                          em_usernamev,
                                          em_name,
                                          em_mail,
                                          delivery_executive_username,
                                          delivery_executive_name,
                                          delivery_executive_mail,
                                          account_manager_name,
                                          account_manager_username,
                                          account_manager_mail,
                                          budget);
            }

        });
            await _unitOfWork.CompleteAsync(stoppingToken);
    }
}
 