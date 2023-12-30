using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Repositories;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Transactions;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ICompanyRepository _companyRepository;

    public AccountController(IAccountRepository accountRepository, IRoleRepository roleRepository, ICompanyRepository companyRepository)
    {
        _accountRepository = accountRepository;
        _roleRepository = roleRepository;
        _companyRepository = companyRepository;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterAccountDto registerAccountDto)
    {
        using var transaction = new TransactionScope();
        {
            try
            {

                if (registerAccountDto.Password != registerAccountDto.ConfirmPassword)
                {
                    // Mengembalikan respons BadRequest jika Password dan ConfirmPassword tidak cocok.
                    return BadRequest(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "NewPassword and ConfirmPassword do not match"
                    });
                }

                //Create Account 
                Account toCreateAcc = registerAccountDto;
                toCreateAcc.Password = HashingHandler.HashPassword(registerAccountDto.Password);
                toCreateAcc.RoleGuid = _roleRepository.GetDefaultRoleGuid();

                _accountRepository.Create(toCreateAcc);



                //CreateCompany
                // Membuat objek Employee dari data registrasi.
                Company toCreateComp = registerAccountDto;
                toCreateComp.AccountGuid = toCreateAcc.Guid;
                _companyRepository.Create(toCreateComp);


                //CreateVendor
                Vendor vendor = new Vendor
                {
                    Guid = toCreateComp.Guid,
                    CompanyField = "Not Defined",
                    CompanyType = "Not Defined",
                    ApprovalStatus = ApprovalStatusLevel.WaitingApproval
                };

                transaction.Complete();

                // Mengembalikan respons sukses jika registrasi berhasil.
                return Ok(new ResponseOKHandler<string>("Registration successfully"));
            }
            catch (Exception ex)
            {
                // Mengembalikan respons dengan kode status 500 dan pesan error jika terjadi kesalahan.
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed Registration Account",
                    Error = ex.Message
                });
            }
        }
    }


}