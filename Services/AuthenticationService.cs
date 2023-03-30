using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Enum;
using Web_Api_Computer_Shop.Helper;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services
{
    public class AuthenticationService : IAuthenticationReponsitory
    {
        private ComputerShopDBContext context;
        private AESHelper _AESHelper = new AESHelper();
        private GenerateToken _generateToken = new GenerateToken();
        public AuthenticationService(ComputerShopDBContext context)
        {
            this.context = context;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var acc = context.Account.SingleOrDefault(x => x.User_Name == model.Username && x.Password == _AESHelper.encryptdata(model.Password));
            if (acc != null)
            {
                var cus = context.Customer.SingleOrDefault(x => x.Account_Id == acc.Id);
                return new AuthenticateResponse(cus, _generateToken.generateJwtToken(cus));
            }
            else return null;

            // return null if user not found
            //if (user == null) return null;

            // authentication successful so generate jwt token
            //var token = generateJwtToken(user);

            //return new AuthenticateResponse(user, token);
            //return new AuthenticateResponse(new Customer(), "ádgasidbgaisd");
        }

        public AuthenticateResponse SignUp(SignUpRequest model)
        {
            //Create Account to add DB
            var _Account = new Account();
            _Account.Password = _AESHelper.encryptdata(model.Password);
            _Account.User_Name = model.Username;
            _Account.Role = (int)ERole.EMPLOYEE;
            _Account.Created_Date = DateTime.Now;
            context.Account.Add(_Account);

            Guid id_account = _Account.Id;
            //Create Customer to add DB
            var _customerAdd = new Customer();
            _customerAdd.Id = Guid.NewGuid();
            _customerAdd.Phone = model.PhoneNumber;
            _customerAdd.Full_Name = model.Name;
            _customerAdd.Account_Id = id_account;
            _customerAdd.Created_Date = DateTime.Now;
            context.Customer.Add(_customerAdd);

            context.SaveChanges();

            // return null if user not found
            if (_customerAdd == null) return null;

            // authentication successful so generate jwt token
            var token = _generateToken.generateJwtToken(_customerAdd);

            return new AuthenticateResponse(_customerAdd, token);
        }

        public AuthenticateResponse ForgotPassword(ForgotPasswordRequest model)
        {
            //Create Account to add DB
            var _Account = context.Account.Where(x => x.User_Name == model.Username).FirstOrDefault();
            var _customerAdd = context.Customer.Where(x => x.Account_Id == _Account.Id).FirstOrDefault();
            // return null if user not found
            if (_customerAdd == null) throw new Exception($"Customer have phone {model.Phone} don't not exist");
            if (_Account != null && _customerAdd.Phone == model.Phone)
            {
                var _accountUpdate = _Account;
                _accountUpdate.Password = _AESHelper.encryptdata(model.New_Password);
                _accountUpdate.Modified_Date = DateTime.Now;
                context.Entry(_Account).CurrentValues.SetValues(_accountUpdate);
                context.SaveChanges();
            } else
            {
                if (_Account == null)
                {
                    throw new Exception($"Account have phone {model.Phone} don't not exist");
                }
                if (_customerAdd.Phone != model.Phone)
                {
                    throw new Exception($"Phone {model.Phone} number don't match");
                }
            }
            // authentication successful so generate jwt token
            var token = _generateToken.generateJwtToken(_customerAdd);
            return new AuthenticateResponse(_customerAdd, token);
        }

        public AuthenticateResponse ChangePassword(ChangePasswordRequest model, Guid Id)
        {
            //Create Account to add DB
            var _customer = context.Customer.Where(x => x.Id == Id).FirstOrDefault();
            var _Account = context.Account.Where(x => _customer.Id == Id).FirstOrDefault();
            if (_Account != null && _Account.Password == _AESHelper.encryptdata(model.Old_Password))
            {
                var _accountUpdate = _Account;
                _accountUpdate.Password = _AESHelper.encryptdata(model.New_Password);
                _accountUpdate.Modified_Date = DateTime.Now;
                context.Entry(_Account).CurrentValues.SetValues(_accountUpdate);
                context.SaveChanges();
            }
            else
            {
                if (_Account == null)
                {
                    throw new Exception($"Account don't not exist");
                }
            }
            // authentication successful so generate jwt token
            var token = _generateToken.generateJwtToken(_customer);

            return new AuthenticateResponse(_customer, token);
        }
    }
}
