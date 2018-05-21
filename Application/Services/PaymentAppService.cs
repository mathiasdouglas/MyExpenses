﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.ViewModels;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Models;

    public class PaymentAppService : AppServiceBase<Payment, PaymentDto>, IPaymentAppService
    {
        private readonly IExpenseAppService _expenseAppService;

        public PaymentAppService(IPaymentService service, IExpenseAppService expenseAppService, IPaymentAdapter adapter, IUnitOfWork unitOfWork)
            : base(service, adapter, unitOfWork)
        {
            _expenseAppService = expenseAppService;
        }

        public IEnumerable<PaymentViewModel> GetAll(DateTime starDateTime, DateTime endDateTime)
        {
            IEnumerable<ExpenseDto> allExpenses = _expenseAppService.GetAll().Where(x => x.Data >= starDateTime && x.Data <= endDateTime);

            return GetAll().GroupJoin(
                    allExpenses,
                    payment => payment.Id,
                    expense => expense.PaymentId,
                    (payment, expenses) => new { payment, expenses })
                .Select(x => new PaymentViewModel
                {
                    Payment = x.payment,
                    QuantityOfExpenses = x.expenses.Count(),
                    Value = x.expenses.Sum(y => y.Value)
                });
        }
    }
}
