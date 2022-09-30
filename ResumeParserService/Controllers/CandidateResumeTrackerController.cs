using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeParserService.Context;
using ResumeParserService.Entities;
using ResumeParserService.Services;
using ResumeParserService.ViewModels;
using System;
using System.Linq;

namespace ResumeParserService.Controllers
{
    [Route("api/CandidateResumeTracker")]
    public class CandidateResumeTrackerController : Controller
    {
        ICandidateResumeTrackerService _candidateResumeTrackerService;
        public CandidateResumeTrackerController(ICandidateResumeTrackerService candidateResumeTrackerService)
        {
            _candidateResumeTrackerService = candidateResumeTrackerService;
        }
        // GET: CandidateResumeTrackerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CandidateResumeTrackerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidateResumeTrackerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateResumeTrackerController/Create
        [Route("~/api/CandidateResumeTrackerAdd")]
        [HttpPost]
        public ActionResult Create([FromBody] CandidateResumeTrackerViewModel model)
        {
            try
            {
                // model validation
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var crt = _candidateResumeTrackerService.Create(model);
                return Ok(new { message = "success", StatusCode = Response.StatusCode, MemberList = crt });
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateResumeTrackerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidateResumeTrackerController/Edit/5
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

        // GET: CandidateResumeTrackerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidateResumeTrackerController/Delete/5
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
