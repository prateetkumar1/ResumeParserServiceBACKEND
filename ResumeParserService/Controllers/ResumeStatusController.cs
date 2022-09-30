using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeParserService.Context;
using ResumeParserService.Entities;
using ResumeParserService.Services;
using ResumeParserService.ViewModels;
using System;
using System.Linq;

namespace ResumeParserService.Controllers
{
    [Route("api/ResumeStatus")]
    public class ResumeStatusController : Controller
    {
        private IResumeStatusService _resumeStatusService;
        public ResumeStatusController(IResumeStatusService resumeStatusService)
        {
            _resumeStatusService = resumeStatusService;
        }
        // GET: ResumeStatusController
        [HttpGet]
        public ActionResult Index()
        {
            var rs = _resumeStatusService.GetAll();
            return Ok(new { message = "success", StatusCode = Response.StatusCode, MemberList = rs });
        }

        // GET: ResumeStatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResumeStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeStatusController/Create
        [Route("~/api/ResumeStatusAdd")]
        [HttpPost]
        public ActionResult Create([FromBody] ResumeStatusViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _resumeStatusService.Create(model);
                return Ok(new { message = "success", StatusCode = Response.StatusCode, MemberList = "success" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: ResumeStatusController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResumeStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResumeStatusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResumeStatusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
