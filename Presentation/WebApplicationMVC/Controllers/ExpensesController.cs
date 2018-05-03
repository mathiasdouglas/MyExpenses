﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;
    using MyExpenses.WebApplicationMVC.Models;

    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _service;
        private readonly ILabelRepository _labelRepository;
        private readonly IPaymentRepository _paymentRepository;

        public ExpensesController(
            IExpenseAppService service,
            ILabelRepository labelRepository,
            IPaymentRepository paymentRepository)
        {
            _service = service;

            _labelRepository = labelRepository;
            _paymentRepository = paymentRepository;
        }

        // GET: Expenses
        public IActionResult Index()
        {
            var allIncoming = _service.GetAllIncoming();
            var allOutComing = _service.GetAllOutcoming();

            IndexExpenseViewModel viewModel = new IndexExpenseViewModel
            {
                Incoming = allIncoming.ToList(),
                Outcoming = allOutComing.ToList(),
                TotalIncoming = allIncoming.Sum(x => x.Value),
                TotalOutcoming = allOutComing.Sum(x => x.Value)
            };
            viewModel.TotalLeft = viewModel.TotalIncoming - viewModel.TotalOutcoming;

            return View(viewModel);
        }

        // GET: Expenses/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _service.GetById(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            CreateSelectLists();

            return View(new ExpenseDto { Data = DateTime.Today });
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseDto expense)
        {
            if (ModelState.IsValid)
            { 
                _service.AddOrUpdate(expense);
                return RedirectToAction(nameof(Index));
            }

            CreateSelectLists(expense.LabelId, expense.PaymentId);

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _service.GetById(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            CreateSelectLists(expense.LabelId, expense.PaymentId);

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, ExpenseDto expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddOrUpdate(expense);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _service.GetById(id.Value);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(long id)
        {
            return _service.GetById(id) != null;
        }

        private void CreateSelectLists(long? labelId = null, long? paymentId = null)
        {
            IEnumerable<Label> lables = _labelRepository.GetAll();
            IEnumerable<Payment> payments = _paymentRepository.GetAll();

            Label[] l = { new Label { Id = -1, Name = string.Empty } };
            lables = lables.Concat(l).OrderBy(x => x.Id);

            Payment[] p = { new Payment { Id = -1, Name = string.Empty } };
            payments = payments.Concat(p).OrderBy(x => x.Id);

            ViewData["Labels"] = new SelectList(lables, "Id", "Name", labelId);
            ViewData["Payments"] = new SelectList(payments, "Id", "Name", paymentId);
        }
    }
}
