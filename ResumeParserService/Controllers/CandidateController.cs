using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeParserService.Context;
using ResumeParserService.Entities;
using ResumeParserService.Services;
using ResumeParserService.ViewModels;
using System;
//using ResumeParserModel;
using System.Linq;

namespace ResumeParserService.Controllers
{
    [Route("api/Candidate")]
    public class CandidateController : Controller
    {
        private ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: CandidateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CandidateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateController/Create
        [Route("~/api/CandidateDetailsSave")]
        [HttpPost]
        public ActionResult Create([FromBody] CandidateViewModel model)
        {
            try
            {
                // validate the incomming model
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var cs = _candidateService.Create(model);
                return Ok(new {message = "success", StatusCode = Response.StatusCode, MemberList = cs });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server error" + ex.Message);
            }
        }

        // GET: CandidateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidateController/Edit/5
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

        // GET: CandidateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidateController/Delete/5
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

    //private bool isExisting(int id)
    //{

    //}
}
