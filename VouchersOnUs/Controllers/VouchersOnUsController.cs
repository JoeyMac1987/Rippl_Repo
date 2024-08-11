using System;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.Interfaces;
using VouchersOnUs.API.DTO;
using VouchersOnUs.API.Repositories;
using System.Net.Http;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VouchersOnUs.API.Controllers
{
    [Route("api/{controller}/{action}")]
    public class VouchersOnUsController : Controller
    {

        private VouchersOnUsDBContext _repository;
        private IUnitOfWork _unitofWork;
        private IConfiguration _config;

        static HttpClient client = new HttpClient();
        private string providerURL = "";

        //Method of tracking issues
        private readonly ILogger<VouchersOnUsController> _logger;
                
        public VouchersOnUsController(VouchersOnUsDBContext repository, IUnitOfWork unitofWork, IConfiguration config, ILogger<VouchersOnUsController> logger)
        {
            _repository = repository;
            _config = config;
            _unitofWork = unitofWork;

            _logger = logger;
        }

        public string TESTAPI()
        {
            return "API IS RUNNING";
        }

        [HttpGet]
        public List<VouchersDTO> GetAllVouchers()
        {
            VouchersRepository voucherRepo = new VouchersRepository(_repository,_unitofWork, _config,_logger);
            List<VouchersDTO> returnValues = voucherRepo.GetAllVouchers();

            return returnValues;
        }

        [HttpGet]
        public List<VouchersDTO> ListVouchers( string providerName )
        {
            List<VouchersDTO> returnValues = new List<VouchersDTO>();
            ProvidersRepository providersRepo = new ProvidersRepository(_repository, _unitofWork, _config, _logger);

            providerURL = providersRepo.GetProviderApiUrl(providerName);

            if (providerURL == "error")
            {
                throw new ArgumentException("Error with Provider Name");
            }

            string apiParms= "ExternalProvider/ListVouchers";
            returnValues = GetAllVouchersAPICall(apiParms);

            return returnValues;
        }




        public VoucherApiDTO SelectVoucherAndAmount(string voucherName, int amount)
        {
            VoucherApiDTO returnDTO = new VoucherApiDTO();

            string apiParms = "ExternalProvider/DetailVoucher/" + voucherName ;
            var detailedVoucher = GetDetailedVoucherAPICall(apiParms);

            returnDTO.VouchersList.Add(detailedVoucher);
            returnDTO.Amount = amount;

            return returnDTO;
        }

        [HttpPost]
        public HttpResponseMessage AddToCart([FromBody] string voucherName, int amount, bool Add = true)
        {
            HttpResponseMessage recordResult = new();
            VoucherApiDTO returnDTO = new VoucherApiDTO();
            bool apiReponse = false;


            returnDTO = SelectVoucherAndAmount(voucherName, amount);

            if (Add)
            {
                string apiParms = "ExternalProvider/CreateCart/" + returnDTO.OrdersList; //refinement required
                apiReponse = ProcessOrderAPICall(apiParms);
                
            }
            else //Update Cart
            {
                string apiParms = "ExternalProvider/UpdateCart/" + returnDTO.OrdersList;
                apiReponse = ProcessOrderAPICall(apiParms);
                
            }

            if (apiReponse)
            {
                recordResult = new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                recordResult = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return recordResult;
            
        }
        public HttpResponseMessage CheckOut([FromBody] OrdersDTO order)
        {
            OrdersRepository ordersRepo = new OrdersRepository(_repository, _unitofWork, _config, _logger);
            HttpResponseMessage recordResult = new();
            bool apiReponse = false;


            String apiParms = "ExternalProvider/CheckOut/" + order.OrderId.ToString();
            apiReponse = ProcessOrderAPICall(apiParms);

            if (apiReponse)
            {
                var test = ordersRepo.GetUserOrder(2);
            }


            return recordResult;
        }
        





            private List<VouchersDTO> GetAllVouchersAPICall(string url)
        {
            List<VouchersDTO> returnValues = new List<VouchersDTO>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(providerURL);
                
                var result = client.GetAsync(url).Result;
                result.EnsureSuccessStatusCode();
                string resultContentString = result.Content.ReadAsStringAsync().Result;
                VoucherApiDTO resultContent = JsonConvert.DeserializeObject<VoucherApiDTO>(resultContentString);

                returnValues = resultContent.VouchersList;
            }

            return returnValues;
        }

        private VouchersDTO GetDetailedVoucherAPICall(string url)
        {
            VouchersDTO returnValues = new VouchersDTO();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(providerURL);
                var result = client.GetAsync(url).Result;
                result.EnsureSuccessStatusCode();
                string resultContentString = result.Content.ReadAsStringAsync().Result;
                returnValues = JsonConvert.DeserializeObject<VouchersDTO>(resultContentString);;
            }

            return returnValues;
        }


        private bool ProcessOrderAPICall(string url)
        {
            bool outcome = true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(providerURL);
                var result = client.GetAsync(url).Result;
                result.EnsureSuccessStatusCode();
                string resultContentString = result.Content.ReadAsStringAsync().Result;

                if(!result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    outcome = false;
                }
            }
            return outcome;
        }

    }
}

