using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDomain.Interface;
using InfraStructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DomainModels;
using Models.ViewModels;

namespace EBankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase

    {
        private readonly ICustomerDetails _customerDetails;
        public CustomerDetailsController(ICustomerDetails customerDetails)
        {
            _customerDetails = customerDetails;
        }
        #region CustomerDetails
        [HttpGet("ValidateEmailId/{emailId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public  IActionResult  CustomerDetails(string emailId)
        {
            SingleResponse<bool> response = new SingleResponse<bool>();
            try
            {
                //string enterpriseId = emailId;
                response.Model = _customerDetails.ValidateEmailId(emailId);
                
            }
            catch (Exception ex)
            {
                //_logger?.HandleException(response, nameof(GetAdminlogs), ex);
            }
            return response.ToHttpResponse();
        }
        
        [HttpGet("ValidateExistingEmailId/{emailId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult ValidateExistingEmailId(string emailId)
        {
            SingleResponse<bool> response = new SingleResponse<bool>();
            try
            {
                //string enterpriseId = emailId;
                response.Model = _customerDetails.ValidateExistingEmailId(emailId);

            }
            catch (Exception ex)
            {
                //_logger?.HandleException(response, nameof(GetAdminlogs), ex);
            }
            return response.ToHttpResponse();
        }
        
        [HttpPost("SaveCustomerDetails")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SaveCustomerDetails(CustomerViewModel data)
        {
            SingleResponse<bool> response = new SingleResponse<bool>();
            try
            {
                response.Model = await _customerDetails.SaveCustomerDetails(data);

            }
            catch (Exception ex)
            {
                //_logger?.HandleException(response, nameof(saveLogs), ex);
            }
            return response.ToHttpResponse();
        }
    }
    #endregion
}