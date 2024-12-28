using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankappado.Dto;

namespace bankappado.Interface.Service
{
    public interface IAccountService
    {
        AccountDto Create(CreateAccountRequestModel model,int cusID);
        AccountDto Update(int id, UpdateAccountRequestModel model);
        AccountDto Get(int id);
        IList<AccountDto> GetAll();
        void Delete(int id);
        AccountDto Login(LoginAccountRequestModel model);
        AccountResponseModel CheckBalance (string accountnumber, int pin);
    }
}