using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Repositories;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Claims;
using System.Transactions;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ITokenHandler _tokenHandler;
    private readonly IEmployeeRepository _employeeRepository;

    public AccountController(IAccountRepository accountRepository, IRoleRepository roleRepository, ICompanyRepository companyRepository, ITokenHandler tokenHandler, IEmployeeRepository employeeRepository)
    {
        _accountRepository = accountRepository;
        _roleRepository = roleRepository;
        _companyRepository = companyRepository;
        _tokenHandler = tokenHandler;
        _employeeRepository = employeeRepository;
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


    [HttpPost("Login")]
    public IActionResult Login(LoginDto loginDto)
    {
        try
        {
            
            var account = _accountRepository.GetByEmail(loginDto.Email);

            if (account is null)
            {
                // Mengembalikan respons NotFound jika email tidak valid.
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email was not registered"
                });
            }

            if (!HashingHandler.VerifyPassword(loginDto.Password, account!.Password))
            {
                // Mengembalikan respons BadRequest jika password tidak valid.
                return BadRequest(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Password is invalid!"
                });
            }

            /*            string? stringPhoto = "";
                        if (!(employees.Photo is null))
                        {
                            stringPhoto = Convert.ToBase64String(employees.Photo);
                        }
            */


            // Membuat daftar claims untuk otentikasi.
            var claims = new List<Claim>();
            var name = "";
            var role = _roleRepository.GetByGuid(account.RoleGuid);

            if (role.Name is "VendorCompany"){
                var company = _companyRepository.GetByAccountGuid(account.Guid);
                name = company.Name;
                claims.Add(new Claim("CompanyStatus", company.ApprovalStatus.ToString(), ClaimValueTypes.String));
            }
            else
            {
                var employee = _employeeRepository.GetByAccountGuid(account.Guid);
                name = employee.FirstName+" "+employee.LastName;
            }

            claims.Add(new Claim("Guid", account.Guid.ToString(), ClaimValueTypes.String));
            claims.Add(new Claim("Role", role.Name, ClaimValueTypes.String));
            claims.Add(new Claim("Email", account.Email, ClaimValueTypes.String));
            claims.Add(new Claim("Name", name, ClaimValueTypes.String));
            claims.Add(new Claim(ClaimTypes.Role, role.Name));


            // Menghasilkan token otentikasi.
            var generateToken = _tokenHandler.Generate(claims);

            // Mengembalikan respons sukses dengan token otentikasi.
            return Ok(new ResponseOKHandler<object>("Login Success", new TokenDto { Token = generateToken }));
        }
        catch (Exception ex)
        {
            // Mengembalikan respons dengan kode status 500 dan pesan error jika terjadi kesalahan.
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Password is invalid!",
                Error = ex.Message
            });
        }

    }

}